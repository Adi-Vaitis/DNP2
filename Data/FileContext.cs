using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using DNP2.Models;

namespace DNP2.Data
{
    public class FileContext
    {
        public IList<Family> Families { get; private set; }
        public IList<Adult> Adults { get; private set; }
        public int index { get; }

        private readonly string familiesFile = "families.json";
        private readonly string adultsFile = "adults.json";

        public FileContext()
        {
            Families = File.Exists(familiesFile) ? ReadData<Family>(familiesFile) : new List<Family>();
            Adults = File.Exists(adultsFile) ? ReadData<Adult>(adultsFile) : new List<Adult>();
            index = 1;
            foreach (var f in Families)
            {
                f.Id = index;
                index++;
            }
        }

        private IList<T> ReadData<T>(string s)
        {
            using (var jsonReader = File.OpenText(familiesFile))
            {
                return JsonSerializer.Deserialize<List<T>>(jsonReader.ReadToEnd());
            }
        }

        public void SaveChanges()
        {
            string jsonFamilies = JsonSerializer.Serialize(Families, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            using (StreamWriter outputFile = new StreamWriter(familiesFile, false))
            {
                outputFile.Write(jsonFamilies);
            }

            string jsonAdults = JsonSerializer.Serialize(Adults, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            using (StreamWriter outputFile = new StreamWriter(adultsFile, false))
            {
                outputFile.Write(jsonAdults);
            }
        }
    }
}
