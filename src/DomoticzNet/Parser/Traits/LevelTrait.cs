using DomoticzNet.Models;

namespace DomoticzNet.Parser.Traits
{
	public class LevelTrait : TraitBase
	{
		public LevelTrait(DomoticzDeviceModel propertyModel) : base(propertyModel)
		{
		}

		public int Level { get; set; }
		public int MaxLevel { get; set; }
		public bool IsReadOnly { get; set; }
	}
}