using DomoticzNet.Parser.Traits;
using DomoticzNet.Service.Models;

using System;
using System.Collections.Generic;
using System.Linq;

namespace DomoticzNet.Parser.Parsers
{
    public class BatteryParser : ITraitParser
    {
        public void ParseProperties(IReadOnlyList<DomoticzPropertyModel> models, ICollection<IDomoticzTrait> properties)
        {
            if (models is null)
                throw new ArgumentNullException(nameof(models));

            if (properties is null)
                throw new ArgumentNullException(nameof(properties));

            var batterySupportingModels = models.Where(x => x.BatteryLevel <= 100);
            var avgBattery = batterySupportingModels
                                .Average(x => x.BatteryLevel);

            if (avgBattery <= 100)
                properties.Add(new BatteryTrait(batterySupportingModels.First(), (byte)Math.Round(avgBattery)));
        }
    }
}
