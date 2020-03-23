using DomoticzNet.Models;

namespace DomoticzNet.Parser.Traits
{
	public class ColorSettingTrait : TraitBase
	{
		public ColorSettingTrait(DomoticzDeviceModel model) : base(model)
		{
		}

		public bool SupportsWhiteColor { get; set; }

		public ColorValue Color { get; set; }
	}
}