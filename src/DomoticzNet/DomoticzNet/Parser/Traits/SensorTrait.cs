using DomoticzNet.Models;

namespace DomoticzNet.Parser.Traits
{
    public class SensorTrait : TraitBase
    {
        public float Value { get; set; }
        public UnitType Unit { get; set; }

        public SensorTrait(DomoticzDeviceModel propertyModel) : base(propertyModel)
        {
        }
    }
}
