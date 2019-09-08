using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ConfigApplication
{
    class Program
    {
        
        
        static void Main(string[] args)
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
                IConfig config = new Config();
                AppConfig _AppConfig = config.LoadConfig(_filePath);
                Console.WriteLine($"Name: {_AppConfig.Name}");
                Console.WriteLine($"Surname: {_AppConfig.Surname}");
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
                config.EditConfig(_filePath, data);
            }
            else if (choice.Equals(3))
            {
                Environment.Exit(1);
            }
        }
    }
}