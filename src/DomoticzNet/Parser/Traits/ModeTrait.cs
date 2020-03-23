using System.Collections.Generic;
using DomoticzNet.Models;

namespace DomoticzNet.Parser.Traits
{
	public class ModeTrait : TraitBase
	{
		public ModeTrait(DomoticzDeviceModel propertyModel, Dictionary<int, string> modes) : base(propertyModel)
		{
			AvailableModes = modes;
		}

		public Dictionary<int, string> AvailableModes { get; }
		public int CurrentMode { get; set; }
	}
}