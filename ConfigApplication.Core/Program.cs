using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using Ninject;

namespace ConfigApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = InversionOfControl.Kernel.Get<ConfigApp>();
            config.Run();
        }
    }
}