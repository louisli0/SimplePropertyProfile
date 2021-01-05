from Process_Dat import process_data
import requests
from bs4 import BeautifulSoup
from os import path
import zipfile as zf
import os
import sys
import shutil

# Globals
isAnnualSelected = False
isLatestSingleWeek = False
seperatorOption = '|'

# TODO: Get Archived Data
# Get All (>2001 + Current Year) - 0
# Get Latest Single Week - 1


def retrieve_online_data(isAnnualSelected):
    
    link = ""
    if not link:
        print('Missing Link to NSW VG Property Sales')
        exit()
    
    webPage = requests.get(link)
    soup = BeautifulSoup(webPage.content, features="html.parser")
    annualDataURLS = soup.body.find_all(
        'a', class_="btn btn-primary btn-sales-data", href=True)
    weeklyDataURLS = soup.body.find_all(
        'a', class_="btn btn-primary btn-sales-data btn-sales-data", href=True)

    #Check if folder exists and set working directory.
    if os.path.isdir(os.path.join(os.getcwd(), 'zips')) is False:
        os.mkdir(os.path.join(os.getcwd(), 'zips'))
    os.chdir(os.path.join(os.getcwd(), 'zips'))

    if isAnnualSelected is True:
        download_zip("m", annualDataURLS)
        download_zip("m", weeklyDataURLS)
    elif isAnnualSelected is False:
        if (len(weeklyDataURLS) != 0):
            download_zip("s", weeklyDataURLS[-1]['href'])
        print('No Weekly Data Available')
    os.chdir(os.pardir)
    return


def download_zip(type, urlArray):

    existingFiles = os.listdir(os.getcwd())
    fileName = ""
    # type s - single archive  / l;atest week
    if type == "s":
        fileName = urlArray.rsplit('/', 1)[-1]
        zip = requests.get(urlArray, stream=True)
        if fileName not in existingFiles:
            with open(fileName, 'wb') as fileZip:
                for chunk in zip.iter_content(chunk_size=1024):
                    fileZip.write(chunk)
    else:
        for link in urlArray:
            fileName = link['href'].rsplit('/', 1)[-1]

            if int(fileName.split(".")[0]) < 2001:
                continue
            zip = requests.get(link['href'], stream=True)
            if fileName not in existingFiles:
                print("Downloading", fileName)
                with open(fileName, 'wb') as fileZip:
                    for chunk in zip.iter_content(chunk_size=1024):
                        fileZip.write(chunk)
    return


def handle_arguments():
    global isAnnualSelected, isLatestSingleWeek, seperatorOption

    if len(sys.argv) < 2:
        sys.exit("No Input Parameter")
        for downloadOption, seperator in sys.argv:
            if downloadOption == '0':
                isAnnualSelected = True
            elif downloadOption == '1':
                isLatestSingleWeek = True
            else:
                sys.exit("Invalid Arguments")

            if seperator == 'p':
                seperatorOption = '|'
            elif seperator == 'c':
                seperatorOption = ','
            else:
                sys.exit('Invalid Arguments')


def main():
    global isAnnualSelected, isLatestSingleWeek, seperatorOption
    handle_arguments()
    retrieve_online_data(isAnnualSelected)

    # Extract ZIP Files
    print("Processing Data")
    process_data(seperatorOption)
    #Delete tmp files
    print('Removing tmp files')
    shutil.rmtree('./tmp')
    exit()


if __name__ == "__main__":
    main()