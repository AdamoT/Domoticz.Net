using DomoticzNet.Service;

using System;

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
            _Address = "192.16.1.29";
            _Port = 8080;

            //TestApis();
            TestParser();

            Console.ReadKey();
        }

        private static void TestParser()
        {
            var authorizationProvider = new BasicAuthorizationService(_UserName, _Password);
            var service = new DomoticzService(_Address, _Port, authorizationProvider);
        }

        private static void TestApis()
        {
            var authorizationProvider = new BasicAuthorizationService(_UserName, _Password);
            var service = new DomoticzService(_Address, _Port, authorizationProvider);

            var instanceInfo = service.GetInstanceInfo().Result;
            var logs = service.GetLogs(TimeSpan.FromSeconds(1000), DomoticzNet.Service.Models.LogLevel.Error).Result;
            var sunInfo = service.GetSunriseSunsetInfo().Result;
            var settings = service.GetSettings().Result;

            var properties = service.GetProperties().Result;
            if (properties.Count > 0)
            {
                var property = service.GetProperty(properties[0].Idx).Result;
            }

            service.AddLog("Hello World").Wait();
        }
    }
}
