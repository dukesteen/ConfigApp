using System;
using System.Collections.Generic;
using Ninject;

namespace ConfigApplication
{
    public class ConfigApp
    {
        public IConfig _config;

        public ConfigApp(IConfig config)
        {
            _config = config;
        }

        //private AppConfig _appconfig = _config.LoadConfig("Config.json");
        
        public void Run()
        {
            string _filePath = "Config.json";
            Console.WriteLine("What would you like to do today?");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("[1] ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Load from config\n");
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("[2] ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Edit Config\n");
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("[3] ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Exit\n");
            
            Console.Write("Choice: ");
            var choice = Convert.ToInt32(Console.ReadLine());
            
            if (choice.Equals(1))
            {
                Dictionary<string, string> config = _config.LoadConfig(_filePath).data;
                
                foreach (var item in config)
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }
            }
            else if (choice.Equals((2)))
            {
                Console.Clear();
                Console.Write("Key: ");
                var key = Console.ReadLine();
                Console.Write("\n");
                
                Console.Write("Value: ");
                var value = Console.ReadLine();
                Console.Write("\n");
                
                Dictionary<string, string> data = new Dictionary<string, string>();
                data.Add(key, value);
                
                IConfig config = new Config();
                config.EditConfig(_filePath, data, InversionOfControl.Kernel.Get<Config>().appConfig);
            }
            else if (choice.Equals(3))
            {
                Environment.Exit(1);
            }
        }
    }
}