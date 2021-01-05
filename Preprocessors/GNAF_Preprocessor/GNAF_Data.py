import os
import sys
import pandas as pd

gnafDirectory = os.path.join(os.getcwd(), "data")
typeCheck = {
    "street": ["NSW_STREET_LOCALITY_psv.psv", "NSW_STREET_LOCALITY_POINT_psv.psv"],
    "address": ["NSW_ADDRESS_DETAIL_psv.psv", "NSW_ADDRESS_DEFAULT_GEOCODE_psv.psv"],
    "locality": ["NSW_LOCALITY_POINT_psv.psv", "NSW_LOCALITY_psv.psv"],
}


def checkGNAFDirectory():
    global gnafDirectory
    if os.path.exists(gnafDirectory) is False:
        print("Directory not found")
        exit()


def checkFiles(type):
    global gnafDirectory
    typeCheck = {
        "street": ["NSW_STREET_LOCALITY_psv.psv", "NSW_STREET_LOCALITY_POINT_psv.psv"],
        "address": [
            "NSW_ADDRESS_DETAIL_psv.psv",
            "NSW_ADDRESS_DEFAULT_GEOCODE_psv.psv",
        ],
        "locality": ["NSW_LOCALITY_POINT_psv.psv", "NSW_LOCALITY_psv.psv"],
    }
    # Check Files Exist
    filesToCheck = typeCheck[type]
    fileList = os.listdir(gnafDirectory)
    for fileToCheck in filesToCheck:
        if fileToCheck not in fileList:
            print(fileToCheck, "Does not exist")
            exit()


def handleLocalityCreation():
    global gnafDirectory, typeCheck
    checkFiles("locality")
    fileList = typeCheck["locality"]

    LocalityPoint = os.path.join(gnafDirectory, fileList[0])
    LocalityData = os.path.join(gnafDirectory, fileList[1])
    localityDataCleaned = []
    with open(LocalityData, "r") as data:
        lines = data.readlines()
        for line in lines:
            splitLine = line.split("|")
            localityDataCleaned.append(
                "{}".format(",").join([splitLine[0], splitLine[3]]) + "\n"
            )

    saveToFile("localityData", localityDataCleaned)

    localityGeocode = []
    with open(LocalityPoint, "r") as pointData:
        lines = pointData.readlines()
        for line in lines:
            splitLine = line.split("|")
            localityGeocode.append(
                "{}".format(",").join([splitLine[3], splitLine[5], splitLine[6][:-1]])
                + "\n"
            )

    saveToFile("localityGeoCode", localityGeocode)


def handleStreetLocality():
    checkFiles("street")
    fileList = typeCheck["street"]

    SLocality = os.path.join(gnafDirectory, fileList[0])
    SLocalityGeocode = os.path.join(gnafDirectory, fileList[1])
    StreetLocality = []
    with open(SLocality, "r") as data:
        lines = data.readlines()
        for line in lines:
            splitLine = line.split("|")
            StreetLocality.append(
                "{}".format(",").join(
                    [
                        splitLine[0],
                        splitLine[4],
                        splitLine[5],
                        splitLine[6],
                        splitLine[7],
                    ]
                )
                + "\n"
            )
            # print('PID', splitLine[0]
            # , 'Street Name', splitLine[4]
            # , 'Street Type', splitLine[5]
            # , 'Street Suffix', splitLine[6]
            # , 'LocalityPID', splitLine[7])
    saveToFile("SLocality", StreetLocality)

    SLocalityGeoCodeClean = []
    with open(SLocalityGeocode, "r") as data:
        lines = data.readlines()
        for line in lines:
            splitLine = line.split("|")
            SLocalityGeoCodeClean.append(
                "{}".format(",").join([splitLine[3], splitLine[6], splitLine[7][:-1]])
                + "\n"
            )

    saveToFile("SLocalityGeoCode", SLocalityGeoCodeClean)


def handleAddressData():
    checkFiles("address")
    fileList = typeCheck["address"]

    AddressDetail = os.path.join(gnafDirectory, fileList[0])
    AddressGeocode = os.path.join(gnafDirectory, fileList[1])
    AddressData = []
    with open(AddressDetail, "r") as data:
        lines = data.readlines()
        for line in lines:
            splitLine = line.split("|")
            AddressData.append(
                "{}".format(",").join(
                    [
                        splitLine[0],
                        splitLine[24],
                        splitLine[5],
                        splitLine[6],
                        splitLine[7],
                        splitLine[8],
                        splitLine[9],
                        splitLine[10],
                        splitLine[11],
                        splitLine[12],
                        splitLine[13],
                        splitLine[14],
                        splitLine[15],
                        splitLine[16],
                        splitLine[17],
                        splitLine[18],
                        splitLine[19],
                        splitLine[20],
                        splitLine[21],
                        splitLine[26],
                        splitLine[22],
                    ]
                )
                + "\n"
            )
            # print('PID', splitLine[0], 'LocalityPID', splitLine[24],
            #       'LotNumberPrefix', splitLine[5], 'LotNumber', splitLine[6],
            #       'LotNumberSuffix', splitLine[7], 'FlatType', splitLine[8],
            #       'FlatNumberPrefix', splitLine[9], 'FlatNumber',
            #       splitLine[10], 'FlatNUmberSuffix', splitLine[11],
            #       'LevelType', splitLine[12], 'LevelNumberPrefix',
            #       splitLine[13], 'LevelNumber', splitLine[14],
            #       'LevlNumberSuffix', splitLine[15], 'number_first_suffix',
            #       splitLine[16], 'number_first', splitLine[17],
            #       'number_first_prefix', splitLine[18], 'number_last_prefix',
            #       splitLine[19], 'number_last', splitLine[20],
            #       'number_last_prefix', splitLine[21], 'postcode',
            #       splitLine[26], 'streetLocalityPid', splitLine[22])
    saveToFile("AddressData", AddressData)

    AddressGeoCode = []
    with open(AddressGeocode, "r") as pointData:
        lines = pointData.readlines()
        for line in lines:
            splitLine = line.split("|")
            AddressGeoCode.append(
                "{}".format(",").join([splitLine[3], splitLine[5], splitLine[6][:-1]])
                + "\n"
            )
            # print('PID', splitLine[3], 'Longitude', splitLine[11], 'Latitude',
            #       splitLine[12][:-1])
    saveToFile("AddressGeoCode", AddressGeoCode)


def saveToFile(fileName, data):
    with open("{}.csv".format(fileName), "w+") as cleanedData:
        for line in data:
            cleanedData.write(line)


def mergeLocality():
    print("Locality Merge")
    data = pd.read_csv("localityData.csv")
    geoCode = pd.read_csv("localityGeoCode.csv")
    addressData = pd.read_csv("AddressData.csv")[["LOCALITY_PID", "POSTCODE"]]

    localityMerge = (
        data.merge(geoCode, on="LOCALITY_PID")
        .merge(addressData, on="LOCALITY_PID")
        .drop_duplicates()
    )

    localityMerge.to_csv("localityGeocode.csv", mode="w", index=False)


def mergeStreetLocality():
    sl = pd.read_csv("SLocality.csv")
    SLGeo = pd.read_csv("SLocalityGeoCode.csv")

    SLMerge = sl.merge(SLGeo, on="STREET_LOCALITY_PID")

    SLMerge.to_csv("SLMerge.csv", mode="w", index=False)


def AddressDataMerge():
    AD = pd.read_csv(
        "AddressData.csv",
        dtype={
            "ADDRESS_DETAIL_PID": str,
            "LOCALITY_PID": str,
            "LOT_NUMBER_PREFIX": str,
            "LOT_NUMBER": str,
            "LOT_NUMBER_SUFFIX": str,
            "FLAT_TYPE_CODE": str,
            "FLAT_NUMBER_PREFIX": str,
            "FLAT_NUMBER": "Int64",
            "FLAT_NUMBER_SUFFIX": str,
            "LEVEL_TYPE_CODE": str,
            "LEVEL_NUMBER_PREFIX": str,
            "LEVEL_NUMBER": "Int64",
            "LEVEL_NUMBER_SUFFIX": str,
            "NUMBER_FIRST_PREFIX": str,
            "NUMBER_FIRST": "Int64",
            "NUMBER_FIRST_SUFFIX": str,
            "NUMBER_LAST_PREFIX": str,
            "NUMBER_LAST": "Int64",
            "NUMBER_LAST_SUFFIX": str,
            "POSTCODE": "Int64",
            "STREET_LOCALITY_PID": str,
        },
    )
    ADGeo = pd.read_csv("AddressGeoCode.csv")
    mergedfull = AD.merge(ADGeo, on="ADDRESS_DETAIL_PID", suffixes=("", "_"))

    mergedfull.to_csv("GNAF_AddressMerge.csv", mode="w", index=False)


def main():
    print("File Directory Check")
    # checkGNAFDirectory()

    print("Create LocalityDetails")
    handleLocalityCreation()

    print("Create StreetLocality")
    handleStreetLocality()

    print("Create AddressData")
    handleAddressData()

    mergeLocality()
    mergeStreetLocality()
    AddressDataMerge()
    exit()


if __name__ == "__main__":
    main()