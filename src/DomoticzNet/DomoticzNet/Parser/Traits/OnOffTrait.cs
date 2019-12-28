
using DomoticzNet.Service.Models;

namespace DomoticzNet.Parser.Traits
{
    public class OnOffTrait : TraitBase
    {
        public bool IsOn { get; set; }
        public bool IsReadOnly { get; set; }

        public OnOffTrait(DomoticzPropertyModel propertyModel) : base(propertyModel)
        {
        }
    }
}
