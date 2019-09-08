using System.Collections.Generic;

namespace ConfigApplication
{
    public interface IConfig
    {
        AppConfig LoadConfig(string filePath);
        AppConfig EditConfig(string filePath, Dictionary<string, string> data, AppConfig config);
    }
}