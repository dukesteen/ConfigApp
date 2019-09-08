using System.Collections.Generic;

namespace ConfigApplication
{
    public interface IConfig
    {
        AppConfig LoadConfig(string filePath);
        void EditConfig(string filePath, Dictionary<string, string> data);
    }
}