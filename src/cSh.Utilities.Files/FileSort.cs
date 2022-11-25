using CsvHelper;
using CsvHelper.Configuration;
using Newtonsoft.Json;
using System.Globalization;


namespace cSh.Utilities.Files
{
    public class FileSort
    {
        private string _filepath;
        private DirectoryInfo directory;

        private  IEnumerable<FileInfo> allFiles;

        public IEnumerable<DataFormat> UniqueJsonFiles { get; set; }
        public IEnumerable<DataFormat> UniqueCSVFiles { get; set; }

        public FileSort(string filepath)
        {
            _filepath = filepath;
            directory = new DirectoryInfo(_filepath);
            allFiles = directory.GetFiles();
            UniqueJsonFiles = GetUniqueJSONFiles();
            UniqueCSVFiles = GetUniqueCSVFiles();
        }

        private IEnumerable<DataFormat> GetUniqueJSONFiles()
        {
            var jsonFiles = allFiles.Where(item => item.Name.Contains(".json"))
                                    .Select(jsonFile => new DataFormat
                                    {
                                        File = jsonFile,
                                        Data = DeserialiseJsonFile(jsonFile.FullName)
                                    });

            return jsonFiles.Distinct(new DataComparer());
        }

        private IEnumerable<DataFormat> GetUniqueCSVFiles()
        {
            var data = allFiles.Where(item => item.Name.Contains(".csv"))
                                        .Select(data => new DataFormat
                                        {
                                            File = data,
                                            Data = ReadCSVData(data.FullName),
                                        });

            return data.Distinct(new DataComparer());
        }

        private Dictionary<string, string> DeserialiseJsonFile(string fileName)
        {
            string jsonString = File.ReadAllText(fileName);
            var dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonString);

            return dictionary;
        }

        private Dictionary<string, string> ReadCSVData(string fileName)
        {
            CsvConfiguration csvConfiguration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
                Delimiter = ";"
            };

            CsvReader csv = new CsvReader(File.OpenText(fileName), csvConfiguration);

            csv.Read();
            csv.ReadHeader();
            List<string> headers = csv.HeaderRecord.ToList();

            csv.Read();
            string value;
            List<string> data = new List<string>();

            for (int i = 0; csv.TryGetField<string>(i, out value); i++)
            {
                data.Add(value);
            }

            var csvDictionary = Enumerable.Range(0, headers.Count).ToDictionary(i => headers[i], i => data[i]);
            return csvDictionary;
        }
    }
}
