using System.Collections.Generic;

namespace ConfigApplication
{
    public interface IConfig
    {
        AppConfig appConfig { get; set; }
        void SaveConfig();
        void AddPair(KeyValuePair<string, string> data);
        void EditPair(KeyValuePair<string, string> data);
    }
}