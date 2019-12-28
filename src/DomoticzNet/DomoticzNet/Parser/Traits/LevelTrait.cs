using DomoticzNet.Service.Models;

namespace DomoticzNet.Parser.Traits
{
    public class LevelTrait : TraitBase
    {
        public int Level { get; set; }
        public int MaxLevel { get; set; }
        public bool IsReadOnly { get; set; }

        public LevelTrait(DomoticzPropertyModel propertyModel) : base(propertyModel)
        {
        }
    }
}
