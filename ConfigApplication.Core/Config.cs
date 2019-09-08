using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace ConfigApplication
{
    public class Config : IConfig
    {
        public AppConfig appConfig { get; set; }
        
        public Config()
        {
            string json = File.ReadAllText(Constants.configFile);
            appConfig = JsonConvert.DeserializeObject<AppConfig>(json);
        }

        public void SaveConfig()
        {
            string json = JsonConvert.SerializeObject(appConfig);
            File.WriteAllText(Constants.configFile, json);
        }
        
        public void AddPair(KeyValuePair<string, string> data)
        {
            if (appConfig.data.ContainsKey(data.Key))
            {
                EditPair(data);
            }
            else
            {
                appConfig.data.Add(data.Key, data.Value);
            }
            SaveConfig();
        }

        public void EditPair(KeyValuePair<string, string> data)
        {
            appConfig.data[data.Key] = data.Value;
        }

        



    }
}