using DomoticzNet.Models;

namespace DomoticzNet.Parser.Traits
{
	public class OnOffTrait : TraitBase
	{
		public OnOffTrait(DomoticzDeviceModel propertyModel) : base(propertyModel)
		{
		}

		public bool IsOn { get; set; }
		public bool IsReadOnly { get; set; }
	}
}