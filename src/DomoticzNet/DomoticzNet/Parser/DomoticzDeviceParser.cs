using DomoticzNet.Parser.Parsers;
using DomoticzNet.Parser.Traits;
using DomoticzNet.Service.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

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

        private List<ITraitParser> _Parsers = null;

        #endregion Fields

        #region Constructors

        public DomoticzDeviceParser()
        {
            var parserTypes = Assembly.GetExecutingAssembly().GetTypes()
                .Where(x => typeof(ITraitParser).IsAssignableFrom(x)
                    && !x.IsInterface
                    && !x.IsAbstract
                    && x.GetConstructors().Any(c => c.GetParameters().Length == 0));

            _Parsers = new List<ITraitParser>(parserTypes.Select(x => Activator.CreateInstance(x) as ITraitParser));
        }

        #endregion Constructors

        #region Private Methods

        private DomoticzDevice ParseProperties(IReadOnlyList<DomoticzPropertyModel> models)
        {
            var properties = new List<IDomoticzTrait>();
            for (int i = 0; i < _Parsers.Count; ++i)
            {
                _Parsers[i].ParseProperties(models, properties);
            }

            return new DomoticzDevice(properties)
            {
                Id = models.First().Id,
            };
        }

        #endregion Private Methods
    }
}
