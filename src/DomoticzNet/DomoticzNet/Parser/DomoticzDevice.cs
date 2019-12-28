using DomoticzNet.Parser.Traits;

using System.Collections.Generic;

namespace DomoticzNet.Parser
{
    public class DomoticzDevice
    {
        #region Properties

        public string Id { get; set; }
        public IReadOnlyList<IDomoticzTrait> Properties { get; }

        #endregion Properties

        #region Constructors

        public DomoticzDevice(IReadOnlyList<IDomoticzTrait> properties)
        {
            Properties = properties;
        }

        #endregion Constructors
    }
}
