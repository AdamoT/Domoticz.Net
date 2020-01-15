using DomoticzNet.Models;
using DomoticzNet.Parser.Traits;

using System;
using System.Collections.Generic;

namespace DomoticzNet.Parser.Parsers
{
    public class BatteryParser : ITraitParser
    {
        public void ParseProperties(DomoticzDeviceModel model, ICollection<IDomoticzTrait> properties)
        {
            if (model is null)
                throw new ArgumentNullException(nameof(model));

            if (properties is null)
                throw new ArgumentNullException(nameof(properties));

            if (model.BatteryLevel <= 100)
                properties.Add(new BatteryTrait(model, model.BatteryLevel));
        }
    }
}
