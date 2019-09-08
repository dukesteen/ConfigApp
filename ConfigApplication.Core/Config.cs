using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace ConfigApplication
{
    public class Config : IConfig
    {
        public AppConfig appConfig;
        public AppConfig LoadConfig(string filePath)
        {
            string json = File.ReadAllText(filePath);
            appConfig = JsonConvert.DeserializeObject<AppConfig>(json);
            return appConfig;
        }
        
        public AppConfig EditConfig(string filePath, Dictionary<string, string> data, AppConfig config)
        {
            /*
            foreach (KeyValuePair<string, string> item in config.data)
            {
                foreach (KeyValuePair<string, string> item2 in data)
                {
                    if (item.Key == item2.Key)
                    {
                        config.data[item.Value] = item2.Value;
                    }
                }
            }
            */

            foreach(var pair in data)
            {
                if(!config.data.ContainsKey(pair.Key))
                    config.data.Add(pair.Key, pair.Value);
                else
                    config.data[pair.Key] = pair.Value;
            }
            
            appConfig = JsonConvert.DeserializeObject<AppConfig>(data.ToString());
            return appConfig;
        }
    }
}