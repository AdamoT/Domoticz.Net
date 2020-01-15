using DomoticzNet.Models;

namespace DomoticzNet.Parser.Traits
{
    public class SensorTrait : TraitBase
    {
        public float Value { get; set; }
        public SensorType SensorType { get; set; }
        public UnitType Unit { get; set; }

        public SensorTrait(DomoticzDeviceModel propertyModel) : base(propertyModel)
        {
        }

        public override string ToString() => $"{SourceModel.Name} [{this.GetType().Name} - {Unit.ToString()}] ({SourceModel.Idx})";
    }
}
