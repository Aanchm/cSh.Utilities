
using cSh.Utilities.Files;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Enumeration;
using System.Runtime.InteropServices;

string filePath = "C:\\Users\\Aanchal Mittal\\OneDrive\\Documents\\Professional\\repos\\cSh.Utilities\\TestFiles";

var directory = new DirectoryInfo(filePath);
//var fileSort = new FileSort(filePath);



//Console.WriteLine(fileSort.UniqueCSVFiles);
//Console.WriteLine(fileSort.UniqueJsonFiles);

string fileName1 = "C:\\Users\\Aanchal Mittal\\OneDrive\\Documents\\Professional\\repos\\cSh.Utilities\\TestFiles\\Dict_1.json";
var fileInfo1 = new FileInfo(fileName1);
string fileName2 = "C:\\Users\\Aanchal Mittal\\OneDrive\\Documents\\Professional\\repos\\cSh.Utilities\\TestFiles\\Dict_2.json";
var fileInfo2 = new FileInfo(fileName2);

var expectedData = new List<DataFormat>();

var jsonData1 = new Dictionary<string, string>()
{
    ["Name"] = "JSON1",
    ["Current"] = "2.0",
    ["Vel"] = "10.0",
    ["Acc"] = "3.0",
    ["StartPos"] = "10",
};

var jsonData2 = new Dictionary<string, string>()
{
    ["Name"] = "JSON1",
    ["Current"] = "2.0",
    ["Vel"] = "10.0",
    ["Dec"] = "3.0",
    ["StartPos"] = "10",
};

expectedData.AddRange(new List<DataFormat>
{
    new DataFormat{File = fileInfo1, Data = jsonData1},
    new DataFormat{File = fileInfo2, Data = jsonData2}
});

//var actual = /*fileSort*///.UniqueJsonFiles.ToList();
//Console.WriteLine(actual);

//if (expectedData == actual){
//    Console.WriteLine("HI");
//}

//Console.WriteLine(actual[0].File);
//Console.WriteLine(expectedData[0].File);