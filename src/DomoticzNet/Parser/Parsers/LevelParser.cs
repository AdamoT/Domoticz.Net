using System;
using System.Collections.Generic;
using DomoticzNet.Models;
using DomoticzNet.Parser.Traits;

namespace DomoticzNet.Parser.Parsers
{
	public class LevelParser : ITraitParser
	{
		public void ParseProperties(DomoticzDeviceModel model, ICollection<IDomoticzTrait> traits)
		{
			if (model is null)
				throw new ArgumentNullException(nameof(model));
			if (traits is null)
				throw new ArgumentNullException(nameof(traits));

			if (model.HaveDimmer.HasValue
				&& model.HaveDimmer.Value
				&& !string.IsNullOrEmpty(model.DimmerType)
				&& (model.DimmerType != DimmerType.None
					|| model.SwitchType == SwitchType.BlindsPercentageInverted
					|| model.SwitchType == SwitchType.BlindsPercentage))
			{
				var level = model.Level.HasValue
					? model.Level.Value
					: throw new InvalidOperationException("Failed to get level, no level data");

				var maxLevel = model.MaxDimLevel.HasValue
					? model.MaxDimLevel.Value
					: 100;

				var isReadOnly = string.IsNullOrEmpty(model.DimmerType)
								|| model.DimmerType == DimmerType.None;

				traits.Add(new LevelTrait(model)
				{
					Level = level,
					MaxLevel = maxLevel
				});
			}
		}

		//#region Fields

		//private Regex _SetLevelRegEx = new Regex(@"Set Level: (\d{1,3}) %");

		//#endregion Fields

		//#region Private Methods

		//private int GetLevel(DomoticzPropertyModel model, out int maxBrightness)
		//{
		//    maxBrightness = model.MaxDimLevel.HasValue
		//        ? (int)model.MaxDimLevel
		//        : 100;

		//    if (model.Data == Consts.Off)
		//        return 0;
		//    else if (model.Data == Consts.On)
		//        return maxBrightness;
		//    else if (model.Data.StartsWith(Consts.SetLevel))
		//    {
		//        var match = _SetLevelRegEx.Match(model.Data);
		//        if (match.Success && int.TryParse(match.Value, out var value))
		//            return value;
		//    }

		//    throw new NotSupportedException($"Cannot evaluate data {model.Data} for {nameof(LevelParser)}");
		//}

		//#endregion Private Methods
	}
}