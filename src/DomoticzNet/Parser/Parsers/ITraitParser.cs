using System.Collections.Generic;
using DomoticzNet.Models;
using DomoticzNet.Parser.Traits;

namespace DomoticzNet.Parser.Parsers
{
	public interface ITraitParser
	{
		void ParseProperties(DomoticzDeviceModel model, ICollection<IDomoticzTrait> traits);
	}
}