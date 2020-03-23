using DomoticzNet.Models;

namespace DomoticzNet.Parser.Traits
{
	public class SetPointTrait : TraitBase
	{
		public SetPointTrait(DomoticzDeviceModel propertyModel) : base(propertyModel)
		{
		}

		public float SetPoint { get; set; }
	}
}