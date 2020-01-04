using DomoticzNet.Models;

using System.Collections.Generic;

namespace DomoticzNet.Parser
{
    public class DomoticzHardware
    {
        public int Id { get; set; }
        public HardwareTypeValue Type { get; set; }
        public string TypeName { get; set; }
        public string Name { get; set; }

        public List<DomoticzDevice> Devices { get; } = new List<DomoticzDevice>();
    }
}
