using DomoticzNet.Parser.Properties;
using DomoticzNet.Service.Models;

using System;
using System.Collections.Generic;
using System.Linq;

namespace DomoticzNet.Parser.Parsers
{
    public class BatteryParser : IPropertyParser
    {
        public void ParseProperties(IReadOnlyList<DomoticzPropertyModel> models, ICollection<IDomoticzProperty> properties)
        {
            if (models is null)
                throw new ArgumentNullException(nameof(models));

            if (properties is null)
                throw new ArgumentNullException(nameof(properties));

            var avgBattery = models.Where(x => x.BatteryLevel <= 100)
                                .Average(x => x.BatteryLevel);

            if (avgBattery <= 100)
                properties.Add(new BatteryProperty(models.First().Idx, (byte)Math.Round(avgBattery)));
        }
    }
}
