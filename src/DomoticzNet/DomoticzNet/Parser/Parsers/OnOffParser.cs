using DomoticzNet.Models;
using DomoticzNet.Parser.Traits;

using System.Collections.Generic;

namespace DomoticzNet.Parser.Parsers
{
    public class OnOffParser : ITraitParser
    {
        public void ParseProperties(DomoticzDeviceModel model, ICollection<IDomoticzTrait> properties)
        {
            if (model is null)
                throw new System.ArgumentNullException(nameof(model));
            if (properties is null)
                throw new System.ArgumentNullException(nameof(properties));

            if (!string.IsNullOrEmpty(model.SwitchType))
            {
                if (model.Idx == 65 || model.Idx == 62)
                {
                    int a = 2;
                }

                bool isReadOnly = true;
                if (!string.IsNullOrEmpty(model.DimmerType))
                {
                    isReadOnly = false;
                }

                var isOn = !string.IsNullOrEmpty(model.Data)
                        && (model.Data == Consts.On
                            || model.Data.StartsWith(Consts.SetLevel));

                properties.Add(new OnOffTrait(model)
                {
                    IsOn = isOn,
                    IsReadOnly = isReadOnly,
                });
            }
        }
    }
}
