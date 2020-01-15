using DomoticzNet.Models;
using DomoticzNet.Parser.Traits;

using System.Collections.Generic;

namespace DomoticzNet.Parser.Parsers
{
    public class ColorSettingParser : ITraitParser
    {
        public void ParseProperties(DomoticzDeviceModel model, ICollection<IDomoticzTrait> properties)
        {
            if (model is null)
                throw new System.ArgumentNullException(nameof(model));
            if (properties is null)
                throw new System.ArgumentNullException(nameof(properties));

            switch (model.Type)
            {
                case DeviceType.ColorSwitch:
                {
                    var color = model.Color ?? default;
                    var supportsWhite = false;

                    switch (model.SubType)
                    {
                        case DeviceSubType.Rgbw:
                            supportsWhite = true;
                            break;
                    }

                    properties.Add(new ColorSettingTrait(model)
                    {
                        Color = color,
                        SupportsWhiteColor = supportsWhite,
                    });
                }
                break;
            }
        }
    }
}
