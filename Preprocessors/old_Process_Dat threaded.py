import os
import io
import pyodbc
import sys
import zipfile as zf
import threading
from queue import Queue

threads = []

def extract_downloaded(isAnnualSelected):
    zipDir = os.getcwd()
    yearlyWD = os.path.join(os.getcwd(), 'Yearly')
    weeklyWD = os.path.join(os.getcwd(), 'Weekly')

    if isAnnualSelected is True:
        zipDir = os.listdir(os.path.join(os.getcwd(), 'Yearly'))
        os.chdir(yearlyWD)
    else:
        zipDir = os.listdir(os.path.join(os.getcwd(), 'Weekly'))
        os.chdir(weeklyWD)

    for zipFile in zipDir:
        with zf.ZipFile(zipFile, 'r') as extract:
            os.mkdir(zipFile.split(".")[0])
            extract.extractall("{}".format(zipFile.split(".")[0]))

def extract_singleArchive(zipPath):
    with zf.ZipFile(zipPath, 'r') as extract:
        # If directory exists, assume all is extracted
        if os.path.exists(zipPath.split(".")[0]) is False:
            os.mkdir(zipPath.split(".")[0])
            extract.extractall("{}".format(zipPath.split(".")[0]))
        
def process_zip_data(pathToFolder):
    files = os.listdir(pathToFolder)
    if len(files) == 1:
        files = os.listdir(os.path.join(pathToFolder,files[0]))

    for file in files:
        if file.split(".")[-1] == 'dat':
            read_dat_file(os.path.join(pathToFolder, file))

def process_data(isAnnualSelected):
    yearlyWD = os.path.join(os.getcwd(), 'Yearly')
    weeklyWD = os.path.join(os.getcwd(), 'Weekly')

    #Spawn Threads
    files = ["property", "sales"]
    
    for t in range(0, len(files)):
        q = Queue()
        threads.append(WriterThread(q, args=(files[t],)))
        threads[t].start()

    # Process files
    if isAnnualSelected is True:
        for root, dirs, files in os.walk(yearlyWD, topdown=False):
            for name in files:
                if name.split(".")[-1] != "txt":
                    tmp = os.path.join(root, name)
                    if(os.path.split(tmp)[0] == yearlyWD):
                        pass
                    if name.__contains__("NNME"):
                        read_dat_file(tmp)
                    elif name.__contains__(".zip"):
                        extract_singleArchive(tmp)
                        process_zip_data(os.path.join(root, name.split(".")[0]))
                    else:
                        print("TODO: Archived Format")
    else:
        for root, dirs, files in os.walk(weeklyWD, topdown=False):
            for name in files:
                if name.split(".")[-1] != "txt":
                    tmp = os.path.join(root, name)
                    if(os.path.split(tmp)[0] == weeklyWD):
                        pass
                    if name.__contains__("NNME"):
                        read_dat_file(tmp)
                    elif name.__contains__(".zip"):
                        extract_singleArchive(tmp)
                        process_zip_data(os.path.join(root, name.split(".")[0]))
                    else:
                        print("TODO: Archived Format")

    #print(propertyCounter)
    # End Threads
    for t in threads:
        print("Closing Threads")
        t.join()

def read_dat_file(datFile):
    with open(datFile, 'r') as data:
        text = data.readlines()
        for data1 in text:
            if(data1[0]) == 'B':
                process_Property(data1)

def process_Property(data):
    splited = data.split(";")
    
    tmpSales = [splited[23], splited[2], splited[14], splited[15]]
    tmpProperty = [splited[1], splited[4], splited[2], splited[19], splited[6], splited[7], splited[8], splited[9], splited[10], splited[11], splited[12], splited[23]]
    
    index = [tmpProperty, tmpSales]
    if format_check(splited) is True:
        for t in range(0,len(threads)):
            threads[t].queue.put(index[t])

    
def format_check(line):
    # 1, 2, 4, 19, 6, 7, 8, 9, 10, 11, 12, 23, 14, 15
    isRequired = { 0:True, 1:True, 2:True, 3:True, 4:True, 5:False, 6:False, 7:False, 8:False, 9:False, 10:False, 11:False, 12:False, 13:True, 14:True, 15:True, 16:False, 17:False,18:False, 19:False, 20:False, 21:False, 22:False, 23:True}
    lengthLimits = {0:1, 1:3, 2:10, 3:7, 4:16, 5:40, 6:10, 7:10, 8:38, 9:40, 10:4, 11:11, 12:1, 13:8, 14:8, 15:12, 16:4, 17:1, 18:20, 19:5, 20:3, 21:3, 22:3, 23:10}

    # Iterate 14 values instead of 24
    indexValues = [1, 2, 4, 6, 7, 8, 9, 10, 11, 12, 14, 15, 19, 23]
    
    for index in indexValues:
        textLength = len(line[index])
        if textLength == 0 and isRequired[index] is True:
            #print("Error: Required but empty", line[index], lengthLimits[index], isRequired[index], index)
            # errorProperty.append(line)
            return False
        if  textLength > lengthLimits[index]:
            #print("Limit Exceeded",line[index], lengthLimits[index], index)
            # errorProperty.append(line)
            return False

    return True

class WriterThread(threading.Thread):
    def __init__(self, queue, args=(), kwargs=None):
        threading.Thread.__init__(self, args=(), kwargs=None)
        self.queue = queue
        self.daemon = True
        self.fileName = args[0]
    
    def run(self):
        while True:
            val = self.queue.get()
            self.append_line(self.fileName, val)
    
    def append_line(self, fileName, line):
        with open("{}.psv".format(fileName), 'a+') as file:
            for data_elem in line:
                file.write(data_elem)
                if data_elem != line[-1]:
                    file.write('|')
            file.write('\n')