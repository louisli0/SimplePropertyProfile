import os
from io import BytesIO
import zipfile as zf
from queue import Queue
from pathlib import Path
from datetime import datetime
import pandas as pd
import csv

propertyArray = Queue()
incorrectYearQueue = Queue()
errorArray = Queue()
seenArray = []
fileCounter = 0
# Extracting Archives
# From filename, get year, and extrract to year folders.


def yearFolderCheck(path, year):
    yearPath = path.joinpath(year)
    if Path.exists(path.joinpath(year)) is False:
        os.mkdir(yearPath)
    return yearPath


def extractSingleArchive(tmpDir, zipToExamine):

    zipFile = zf.ZipFile(zipToExamine)
    for files in zipFile.infolist():
        if files.filename.lower().endswith('.dat') is True:
            #Get year
            year = files.filename.lower().split('_')[-1:][0][4:-4]
            yearPath = yearFolderCheck(tmpDir, year)
            data = zipFile.read(files.filename)

            extractPath = yearPath / Path(files.filename).name
            extractPath.write_bytes(data)
    zipFile.close()


def extract_archives(zipWD):

    zipFiles = os.listdir(zipWD)
    tmpDir = Path.cwd().joinpath('tmp')

    if Path.exists(tmpDir) is False:
        os.mkdir('tmp')

    for zipPath in zipFiles:
        if zipPath.endswith('zip') is True:
            zip_file = zf.ZipFile(os.path.join(zipWD, zipPath))
            for files in zip_file.infolist():
                if files.filename.lower().endswith('.zip') is True:
                    readZip = BytesIO(zip_file.read(files))
                    extractSingleArchive(tmpDir, readZip)

                if files.filename.lower().__contains__(
                        'sales_data'
                ) and files.filename.lower().endswith('.dat') is True:
                    # Get Year
                    year = files.filename.lower().split('_')[-1:][0][4:-4]
                    yearPath = yearFolderCheck(tmpDir, year)

                    data = zip_file.read(files.filename)
                    extractPath = yearPath / Path(files.filename).name
                    extractPath.write_bytes(data)
            zip_file.close()
    return


def read_dat_file(datFile, year):
    with open(datFile, 'r') as data:
        text = data.readlines()
        for textData in text:
            if textData[0] == "B":
                if format_check(textData.split(";"), year) is True:
                    propertyArray.put(textData)
                else:
                    errorArray.put(textData)
    return


def format_check(line, year):
    isRequired = {
        0: True,
        1: True,
        2: True,
        3: True,
        4: True,
        5: False,
        6: False,
        7: False,
        8: False,
        9: False,
        10: False,
        11: False,
        12: False,
        13: True,
        14: True,
        15: True,
        16: False,
        17: False,
        18: False,
        19: False,
        20: False,
        21: False,
        22: False,
        23: True
    }

    lengthLimits = {
        0: 1,
        1: 3,
        2: 10,
        3: 7,
        4: 16,
        5: 40,
        6: 10,
        7: 10,
        8: 38,
        9: 40,
        10: 4,
        11: 11,
        12: 1,
        13: 8,
        14: 8,
        15: 12,
        16: 4,
        17: 1,
        18: 20,
        19: 5,
        20: 3,
        21: 3,
        22: 3,
        23: 10
    }

    indexValues = [1, 2, 4, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 19, 23]

    for index in indexValues:
        textLength = len(line[index])
        if textLength == 0 and isRequired[index] is True:
            return False
        if textLength > lengthLimits[index]:
            return False

    return True


def process_data(seperatorOption):
    global propertyArray, errorArray, fileCounter
    zipsWD = os.path.join(os.getcwd(), 'zips')
    extract_archives(zipsWD)

    tmpFiles = Path.cwd().joinpath('tmp')
    for yearDirectory in os.listdir(tmpFiles):
        yearDir = tmpFiles.joinpath(yearDirectory)
        for file in yearDir.iterdir():
            fileCounter += 1
            read_dat_file(file, yearDirectory)

        print("Creating record for", yearDirectory)
        append_line(propertyArray, yearDirectory, seperatorOption)
        append_errors(errorArray)
        duplicate_Checker("property_{}.psv".format(yearDirectory))


"""
B - Record
0 - Record Type
1 - District Code
2 - Property Id
3 - Sale Counter
4 - Download Date/Time
5 - Property Name
6 - Unit Number
7 - House Number
8 - Street Name
9 - Locality
10 - Post Code
11 - Area
12 - Area Type
13 - Contract Date
14 - Settlement Date
15 - Price
16 - Zoning
17 - Nature of Property
18 - Purpose
19 - Strata Lot number
20 - Component Code
21 - Sale Code
22 - Interest of Sale
23 - Dealing number
"""


def append_line(queue, year, seperatorOption):
    with open("property_{}.psv".format(year), 'w+') as file:
        while queue.empty() is False:
            data = queue.get()
            splited = data.split(";")

            tmpProperty2 = '{}'.format(';').join([
                splited[23], splited[1], splited[2], splited[6], splited[7],
                splited[8].replace('"', '\''), splited[9], splited[10],
                splited[11], splited[12], splited[14], splited[15],
                splited[17], splited[18], splited[19]
            ]) + '\n'
            file.write(tmpProperty2)


def append_errors(queue):
    with open("errors.psv", 'a+') as file:
        while queue.empty() is False:
            data = queue.get()
            file.write(data)


def duplicate_Checker(filename):
    df = pd.read_csv(filename,
                     dtype={
                         "DealingNumber": object,
                         "DistrictCode": object,
                         "PropertyId": object,
                         "UnitNumber": object,
                         "HouseNumber": "Int64",
                         "Streetname": object,
                         "Locality": object,
                         "PostCode": "Int64",
                         "Area": "float64",
                         "AreaType": object,
                         "SettlementDate": object,
                         "Price": "Int64",
                         "PropertyNature": object,
                         "Purpose": object,
                         "Strata": "Int64"
                     },
                     sep=';',
                     quoting=csv.QUOTE_NONE,
                     encoding='utf-8').drop_duplicates()

    df.to_csv('nDupe_{}'.format(filename), index=False, sep=";")