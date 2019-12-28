using DomoticzNet.Service.Models;

namespace DomoticzNet.Parser.Traits
{
    public class ColorSettingTrait : TraitBase
    {
        public bool SupportsWhiteColor { get; set; }

        public ColorValue Color { get; set; }

        public ColorSettingTrait(DomoticzPropertyModel model) : base(model)
        {
        }
    }
}
