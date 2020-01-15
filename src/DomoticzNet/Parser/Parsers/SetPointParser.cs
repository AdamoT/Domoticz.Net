using DomoticzNet.Models;
using DomoticzNet.Parser.Traits;

using System.Collections.Generic;

namespace DomoticzNet.Parser.Parsers
{
    public class SetPointParser : ITraitParser
    {
        public void ParseProperties(DomoticzDeviceModel model, ICollection<IDomoticzTrait> traits)
        {
            if (model is null)
                throw new System.ArgumentNullException(nameof(model));
            if (traits is null)
                throw new System.ArgumentNullException(nameof(traits));

            if (model.SubType == DeviceSubType.SetPoint
                && model.SetPoint.HasValue)
            {
                traits.Add(new SetPointTrait(model)
                {
                    SetPoint = (float)model.SetPoint.Value,
                });
            }
        }
    }
}
