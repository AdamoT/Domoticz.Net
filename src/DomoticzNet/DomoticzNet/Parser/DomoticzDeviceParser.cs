using DomoticzNet.Parser.Parsers;
using DomoticzNet.Parser.Properties;
using DomoticzNet.Service.Models;

using System.Collections.Generic;
using System.Linq;

namespace DomoticzNet.Parser
{
    public class DomoticzDeviceParser
    {
        public void ParseDevices(IReadOnlyList<DomoticzPropertyModel> models, ICollection<DomoticzDevice> devices)
        {
            if (models is null)
                throw new System.ArgumentNullException(nameof(models));
            if (devices is null)
                throw new System.ArgumentNullException(nameof(devices));

            var groupedProperties = new List<DomoticzPropertyModel>();
            foreach (var group in models.GroupBy(x => x.Id))
            {
                groupedProperties.Clear();
                groupedProperties.AddRange(group);
                devices.Add(ParseProperties(groupedProperties));
            }
        }

        #region Fields

        private List<IPropertyParser> _Parsers = null;

        #endregion Fields

        #region Constructors

        public DomoticzDeviceParser()
        {
            _Parsers = new List<IPropertyParser>()
            {
                new BatteryParser(),
            };
        }

        #endregion Constructors

        #region Private Methods

        private DomoticzDevice ParseProperties(IReadOnlyList<DomoticzPropertyModel> models)
        {
            var properties = new List<IDomoticzProperty>();
            for (int i = 0; i < _Parsers.Count; ++i)
            {
                _Parsers[i].ParseProperties(models, properties);
            }

            return new DomoticzDevice(properties);
        }

        #endregion Private Methods
    }
}
