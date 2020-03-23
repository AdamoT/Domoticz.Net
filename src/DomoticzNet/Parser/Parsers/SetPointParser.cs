using System;
using System.Collections.Generic;
using DomoticzNet.Models;
using DomoticzNet.Parser.Traits;

namespace DomoticzNet.Parser.Parsers
{
	public class SetPointParser : ITraitParser
	{
		public void ParseProperties(DomoticzDeviceModel model, ICollection<IDomoticzTrait> traits)
		{
			if (model is null)
				throw new ArgumentNullException(nameof(model));
			if (traits is null)
				throw new ArgumentNullException(nameof(traits));

			if (model.SubType == DeviceSubType.SetPoint
				&& model.SetPoint.HasValue)
				traits.Add(new SetPointTrait(model)
				{
					SetPoint = model.SetPoint.Value
				});
		}
	}
}