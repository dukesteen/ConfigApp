using System;
using System.Collections.Generic;
using Ninject;

namespace ConfigApplication
{
    public class ConfigApp
    {
        private readonly IConfig _config;

        public ConfigApp(IConfig config)
        {
            _config = config;
        }

        public void Run()
        {

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
                Dictionary<string, string> config = _config.appConfig.data;
                
                foreach (var item in config)
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }
            }
            else if (choice.Equals((2)))
            {
                var userInput = 0;
                while (userInput == 0)
                {
                    Console.Clear();
                    Console.Write("Key: ");
                    var key = Console.ReadLine();
                    Console.Write("\n");
                
                    Console.Write("Value: ");
                    var value = Console.ReadLine();
                    Console.Write("\n");

                    KeyValuePair<string, string> data = new KeyValuePair<string, string>(key, value);
                    _config.AddPair(data);
                    Console.WriteLine("Pair added!");
                    Console.Write("Would you like to add another pair? (Y/N): ");
                    var userChoice = Console.ReadLine();
                    
                    if (userChoice.Equals("Y"))
                    {
                        userInput = 0;
                        continue;
                    }
                    else
                    {
                        userInput = 1;
                        break;
                    }
                }
            }
            else if (choice.Equals(3))
            {
                Environment.Exit(1);
            }
        }
    }
}