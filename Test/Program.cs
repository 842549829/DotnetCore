

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {

            IConfigurationBuilder config = new ConfigurationBuilder();
            IConfigurationSource autofacJsonConfigSource = new JsonConfigurationSource()
            {
                Path = "config.json",
            };
            config.Add(autofacJsonConfigSource);
            var c = config.Build();
            var d = c["ProviderName"];



            Console.ReadLine();
            Console.ReadKey();
        }
    }
}