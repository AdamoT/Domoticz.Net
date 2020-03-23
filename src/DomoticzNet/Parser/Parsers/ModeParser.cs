using System;
using System.Collections.Generic;
using DomoticzNet.Models;
using DomoticzNet.Parser.Traits;

namespace DomoticzNet.Parser.Parsers
{
	public class ModeParser : ITraitParser
	{
		#region Fields

		private readonly char[] _ModesSeparators = {';'};

		#endregion Fields

		#region ITraitParser

		public void ParseProperties(DomoticzDeviceModel model, ICollection<IDomoticzTrait> traits)
		{
			if (model is null)
				throw new ArgumentNullException(nameof(model));
			if (traits is null)
				throw new ArgumentNullException(nameof(traits));

			if (!string.IsNullOrEmpty(model.Modes)
				&& model.Mode.HasValue)
			{
				var modes = model.Modes.Split(_ModesSeparators, StringSplitOptions.RemoveEmptyEntries);
				if (modes.Length % 2 != 0)
					throw new InvalidOperationException("Modes should have even number of items");

				var modesMap = new Dictionary<int, string>();
				for (var i = 0; i < modes.Length; i += 2)
				{
					var modeIdx = int.Parse(modes[i]);
					modesMap.Add(modeIdx, modes[i + 1]);
				}

				traits.Add(new ModeTrait(model, modesMap)
				{
					CurrentMode = model.Mode.Value
				});
			}
		}

		#endregion ITraitParser
	}
}