using DomoticzNet.Parser.Properties;
using DomoticzNet.Service.Models;

using System.Collections.Generic;

namespace DomoticzNet.Parser.Parsers
{
    public interface IPropertyParser
    {
        void ParseProperties(IReadOnlyList<DomoticzPropertyModel> models, ICollection<IDomoticzProperty> properties);
    }
}
