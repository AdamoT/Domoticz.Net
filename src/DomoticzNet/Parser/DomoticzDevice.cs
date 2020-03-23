using System.Collections.Generic;
using DomoticzNet.Parser.Traits;

namespace DomoticzNet.Parser
{
	public class DomoticzDevice
	{
		public DomoticzHardware Hardware { get; set; }

		public int Id { get; set; }

		public List<IDomoticzTrait> Traits { get; } = new List<IDomoticzTrait>();
	}
}