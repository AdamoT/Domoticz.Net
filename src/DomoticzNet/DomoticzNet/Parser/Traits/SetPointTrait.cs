using DomoticzNet.Service.Models;

namespace DomoticzNet.Parser.Traits
{
    public class SetPointTrait : TraitBase
    {
        public float SetPoint { get; set; }

        public SetPointTrait(DomoticzPropertyModel propertyModel) : base(propertyModel)
        {
        }
    }
}
