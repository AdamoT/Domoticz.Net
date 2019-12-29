using DomoticzNet.Models;
using DomoticzNet.Parser.Traits;

using System.Collections.Generic;

namespace DomoticzNet.Parser.Parsers
{
    public interface ITraitParser
    {
        void ParseProperties(DomoticzDeviceModel model, ICollection<IDomoticzTrait> traits);
    }
}
