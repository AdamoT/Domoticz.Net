using DomoticzNet.Models;

using System.Collections.Generic;

namespace DomoticzNet.Parser.Traits
{
    public class ModeTrait : TraitBase
    {
        public Dictionary<int, string> AvailableModes { get; }
        public int CurrentMode { get; set; }

        public ModeTrait(DomoticzDeviceModel propertyModel, Dictionary<int, string> modes) : base(propertyModel)
        {
            AvailableModes = modes;
        }
    }
}
