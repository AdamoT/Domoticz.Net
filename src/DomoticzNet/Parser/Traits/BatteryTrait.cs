using DomoticzNet.Models;

namespace DomoticzNet.Parser.Traits
{
	public class BatteryTrait : TraitBase
	{
		public BatteryTrait(DomoticzDeviceModel model, byte batteryPercentage) : base(model)
		{
			BatteryPercentage = batteryPercentage;
		}

		public byte BatteryPercentage { get; }
	}
}