using DeepEqual.Syntax;
using Xunit;

namespace cSh.Utilities.Files.UnitTests
{
    public class FileSortTests
    {
        FileSort fileSort;
        string fileLocation = "C:\\Users\\Aanchal Mittal\\OneDrive\\Documents\\Professional\\repos\\cSh.Utilities\\TestFiles";

        [Fact]
        public void GoodInput_ReturnsCorrectJsonFiles()
        {
            //Arrange
            fileSort = new FileSort(fileLocation);

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

            bool result = expectedData.IsDeepEqual(fileSort.UniqueJsonFiles.ToList());
            Assert.True(result);
        }

    }
}