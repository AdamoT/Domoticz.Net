using DomoticzNet.Parser;
using DomoticzNet.Parser.Traits;
using DomoticzNet.Service;

using System;
using System.Collections.Generic;

namespace DomoticzNetConsole
{
    class Program
    {
        private static string _Address, _UserName, _Password;
        private static int _Port;

        static void Main(string[] args)
        {
            _UserName = args[0];
            _Password = args[1];
            _Address = "192.168.1.29";
            _Port = 8080;

            //TestApis();
            TestParser();

            Console.ReadKey();
        }

        private static void TestParser()
        {
            var authorizationProvider = new BasicAuthorizationService(_UserName, _Password);
            var service = new DomoticzService(_Address, _Port, authorizationProvider);
            var deviceModels = service.GetDevices().Result;

            Console.WriteLine($"Obtained {deviceModels.Count} devices from Domoticz");

            var traits = new List<IDomoticzTrait>();
            var parser = new DomoticzDeviceParser();
            parser.ParseTraits(deviceModels, traits);

            Console.WriteLine($"Parsed {deviceModels.Count} devices from properties");
            foreach (var d in traits)
            {
                Console.WriteLine($"Device {d.Id}, traits:");
                foreach (var trait in traits)
                {
                    Console.WriteLine($" - {trait.GetType().Name} from {trait.SourceModel.Name} ({trait.SourceModel.Idx})");
                }
            }
        }

        private static void TestApis()
        {
            var authorizationProvider = new BasicAuthorizationService(_UserName, _Password);
            var service = new DomoticzService(_Address, _Port, authorizationProvider);

            var instanceInfo = service.GetInstanceInfo().Result;
            var logs = service.GetLogs(TimeSpan.FromSeconds(1000), DomoticzNet.Models.LogLevel.Error).Result;
            var sunInfo = service.GetSunriseSunsetInfo().Result;
            var settings = service.GetSettings().Result;

            var properties = service.GetDevices().Result;
            if (properties.Count > 0)
            {
                var property = service.GetDevice(properties[0].Idx).Result;
            }

            service.AddLog("Hello World").Wait();
        }
    }
}
