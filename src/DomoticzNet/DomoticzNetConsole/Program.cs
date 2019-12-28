using DomoticzNet.Service;

using System;
using System.Net;

namespace DomoticzNetConsole
{
    class Program
    {
#pragma warning disable IDE0060 // Remove unused parameter
        static void Main(string[] args)
#pragma warning restore IDE0060 // Remove unused parameter
        {
            var authorizationProvider = new BasicAuthorizationService("Adam", "Buhddt#01At");
            var service = new DomoticzService(IPAddress.Parse("192.168.1.29").ToString(), 8080, authorizationProvider);

            var instanceInfo = service.GetInstanceInfo().Result;
            //Console.WriteLine(JsonConvert.SerializeObject(instanceInfo, Formatting.Indented));

            var logs = service.GetLogs(TimeSpan.FromSeconds(1000), DomoticzNet.Service.Models.LogLevel.Error).Result;

            var sunInfo = service.GetSunriseSunsetInfo().Result;

            var properties = service.GetProperties().Result;
            if (properties.Count > 0)
            {
                var property = service.GetProperty(properties[0].Idx).Result;
            }

            service.AddLog("Hello World").Wait();

            var settings = service.GetSettings().Result;

            Console.ReadKey();
        }
    }
}
