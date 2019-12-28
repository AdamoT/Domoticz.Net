using DomoticzNet.Parser.Properties;

using System.Collections.Generic;

namespace DomoticzNet.Parser
{
    public class DomoticzDevice
    {
        #region Properties

        public IReadOnlyList<IDomoticzProperty> Properties { get; }

        #endregion Properties

        #region Constructors

        public DomoticzDevice(IReadOnlyList<IDomoticzProperty> properties)
        {
            Properties = properties;
        }

        #endregion Constructors
    }
}
