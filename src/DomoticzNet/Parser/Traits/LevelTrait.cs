using DomoticzNet.Models;

namespace DomoticzNet.Parser.Traits
{
    public class LevelTrait : TraitBase
    {
        public int Level { get; set; }
        public int MaxLevel { get; set; }
        public bool IsReadOnly { get; set; }

        public LevelTrait(DomoticzDeviceModel propertyModel) : base(propertyModel)
        {
        }
    }
}
