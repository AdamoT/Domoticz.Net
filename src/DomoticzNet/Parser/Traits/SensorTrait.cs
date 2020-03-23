using DomoticzNet.Models;

namespace DomoticzNet.Parser.Traits
{
	public class SensorTrait : TraitBase
	{
		public SensorTrait(DomoticzDeviceModel propertyModel) : base(propertyModel)
		{
		}

		public float Value { get; set; }
		public SensorType SensorType { get; set; }
		public UnitType Unit { get; set; }

		public override string ToString()
		{
			return $"{SourceModel.Name} [{GetType().Name} - {Unit.ToString()}] ({SourceModel.Idx})";
		}
	}
}