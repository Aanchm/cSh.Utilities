using DeepEqual.Syntax;
using System.Linq;
using Xunit;
using Xunit.Sdk;

namespace cSh.Utilities.Files.UnitTests
{
    public class FileSortTests
    {
        FileSort fileSort;
        string fileLocation = "C:\\Users\\Aanchal Mittal\\OneDrive\\Documents\\Professional\\repos\\cSh.Utilities\\src\\TestFiles\\";

        [Fact]
        public void GoodInput_ReturnsCorrectJsonFiles()
        {
            //Arrange
            fileSort = new FileSort(fileLocation);
            string fileName1 = "C:\\Users\\Aanchal Mittal\\OneDrive\\Documents\\Professional\\repos\\cSh.Utilities\\src\\TestFiles\\Dict_1.json";
            var fileInfo1 = new FileInfo(fileName1);
            string fileName2 = "C:\\Users\\Aanchal Mittal\\OneDrive\\Documents\\Professional\\repos\\cSh.Utilities\\srcTestFiles\\Dict_2.json";
            var fileInfo2 = new FileInfo(fileName2);

            var fileInfo = new List<FileInfo>() {fileInfo1, fileInfo2};

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

            var jsonData = new List<Dictionary<string, string>>() { jsonData1, jsonData2 };
    
            for (int i = 0; i == 1; i++)
            {
                var expectedFileInfo = fileInfo[i];
                var actualFileInfo = fileSort.UniqueJsonFiles.ToList()[i].File;
                var expectedData = jsonData[i];
                var actualData = fileSort.UniqueJsonFiles.ToList()[i].Data;
            }
        }

    }
}