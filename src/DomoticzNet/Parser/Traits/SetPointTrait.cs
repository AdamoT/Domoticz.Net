using DomoticzNet.Models;

namespace DomoticzNet.Parser.Traits
{
    public class SetPointTrait : TraitBase
    {
        public float SetPoint { get; set; }

        public SetPointTrait(DomoticzDeviceModel propertyModel) : base(propertyModel)
        {
        }
    }
}
