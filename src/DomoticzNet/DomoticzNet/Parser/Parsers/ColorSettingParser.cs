using DomoticzNet.Parser.Traits;
using DomoticzNet.Service.Models;

using System.Collections.Generic;

namespace DomoticzNet.Parser.Parsers
{
    public class ColorSettingParser : ITraitParser
    {
        public void ParseProperties(IReadOnlyList<DomoticzPropertyModel> models, ICollection<IDomoticzTrait> properties)
        {
            if (models is null)
                throw new System.ArgumentNullException(nameof(models));
            if (properties is null)
                throw new System.ArgumentNullException(nameof(properties));

            for (int i = 0; i < models.Count; ++i)
            {
                var model = models[i];
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
}
