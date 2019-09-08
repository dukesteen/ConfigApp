using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace ConfigApplication
{
    public class Config : IConfig
    {
        public AppConfig LoadConfig(string filePath)
        {
            string json = File.ReadAllText(filePath);
            AppConfig convertedJson = JsonConvert.DeserializeObject<AppConfig>(json);
            return convertedJson;
        }
        
        public void EditConfig(string filePath, Dictionary<string, string> data)
        {
            if (data.ContainsKey("name"))
            {
                string json = File.ReadAllText(filePath);
                AppConfig deserializedJson = JsonConvert.DeserializeObject<AppConfig>(json);
                data.Add("surname", deserializedJson.Surname);
                var convertedJson = JsonConvert.SerializeObject(data);
                File.WriteAllText(filePath, convertedJson.ToString());
            }
            else if (data.ContainsKey("surname"))
            {
                string json = File.ReadAllText(filePath);
                AppConfig deserializedJson = JsonConvert.DeserializeObject<AppConfig>(json);
                data.Add("name", deserializedJson.Name);
                var convertedJson = JsonConvert.SerializeObject(data);
                File.WriteAllText(filePath, convertedJson.ToString());
            }
        }
    }

    public class AppConfig
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}