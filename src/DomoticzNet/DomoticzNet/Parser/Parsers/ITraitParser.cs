using DomoticzNet.Parser.Traits;
using DomoticzNet.Service.Models;

using System.Collections.Generic;

namespace DomoticzNet.Parser.Parsers
{
    public interface ITraitParser
    {
        void ParseProperties(IReadOnlyList<DomoticzPropertyModel> models, ICollection<IDomoticzTrait> traits);
    }
}
