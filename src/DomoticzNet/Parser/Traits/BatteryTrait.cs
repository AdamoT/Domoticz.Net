using DomoticzNet.Models;

namespace DomoticzNet.Parser.Traits
{
    public class BatteryTrait : TraitBase
    {
        public byte BatteryPercentage { get; }

        public BatteryTrait(DomoticzDeviceModel model, byte batteryPercentage) : base(model)
        {
            BatteryPercentage = batteryPercentage;
        }
    }
}
