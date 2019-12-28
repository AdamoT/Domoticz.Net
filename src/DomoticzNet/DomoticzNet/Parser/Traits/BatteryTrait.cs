using DomoticzNet.Service.Models;

namespace DomoticzNet.Parser.Traits
{
    public class BatteryTrait : TraitBase
    {
        public byte BatteryPercentage { get; }

        public BatteryTrait(DomoticzPropertyModel model, byte batteryPercentage) : base(model)
        {
            BatteryPercentage = batteryPercentage;
        }
    }
}
