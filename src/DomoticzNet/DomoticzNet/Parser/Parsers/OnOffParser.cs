using DomoticzNet.Parser.Traits;
using DomoticzNet.Service.Models;

using System.Collections.Generic;

namespace DomoticzNet.Parser.Parsers
{
    public class OnOffParser : ITraitParser
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
                        var isOn = !string.IsNullOrEmpty(model.Data)
                            && (model.Data == Consts.On
                                || model.Data.StartsWith(Consts.SetLevel));

                        var isReadOnly = string.IsNullOrEmpty(model.DimmerType)
                            || model.DimmerType == DimmerType.None;

                        properties.Add(new OnOffTrait(model)
                        {
                            IsOn = isOn,
                        });
                    }
                    break;
                }
            }
        }
    }
}
