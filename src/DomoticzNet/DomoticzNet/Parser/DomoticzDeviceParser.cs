using DomoticzNet.Models;
using DomoticzNet.Parser.Parsers;
using DomoticzNet.Parser.Traits;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DomoticzNet.Parser
{
    public class DomoticzDeviceParser
    {
        public void ParseTraits(IReadOnlyList<DomoticzDeviceModel> models, ICollection<IDomoticzTrait> traits, ICollection<DomoticzDeviceModel> unusedOrFailedDevices = null)
        {
            if (models is null)
                throw new System.ArgumentNullException(nameof(models));
            if (traits is null)
                throw new System.ArgumentNullException(nameof(traits));

            for (int modelI = 0; modelI < models.Count; ++modelI)
            {
                var model = models[modelI];
                int startTraitsCount = traits.Count;
                for (int parserI = 0; parserI < _Parsers.Count; ++parserI)
                {
                    try
                    {
                        _Parsers[parserI].ParseProperties(model, traits);
                    }
#pragma warning disable CA1031 // Do not catch general exception types
                    catch
#pragma warning restore CA1031 // Do not catch general exception types
                    {
                        unusedOrFailedDevices?.Add(model);
                    }
                }

                if (traits.Count == startTraitsCount)
                {//No trait added for this model
                    unusedOrFailedDevices?.Add(model);
                }
            }
        }

        public List<DomoticzHardware> ParseDeviceHierarchy(IReadOnlyList<DomoticzDeviceModel> models, ICollection<DomoticzDeviceModel> unusedOrFailedDevices = null)
        {
            var result = new List<DomoticzHardware>();
            var byDeviceModels = new List<DomoticzDeviceModel>();
            foreach (var byHardware in models.GroupBy(x => x.HardwareId))
            {
                var hardwareExample = byHardware.First();
                var hardware = new DomoticzHardware()
                {
                    Id = byHardware.Key,
                    Type = hardwareExample.HardwareTypeVal,
                    TypeName = hardwareExample.HardwareType,
                    Name = hardwareExample.HardwareName,
                };
                result.Add(hardware);

                foreach (var byDevice in GroupByDevices(hardware, byHardware))
                {
                    var device = new DomoticzDevice
                    {
                        Id = byDevice.Key,
                    };
                    hardware.Devices.Add(device);

                    byDeviceModels.Clear();
                    byDeviceModels.AddRange(byDevice);

                    ParseTraits(byDeviceModels, device.Traits, unusedOrFailedDevices);

                    RemoveDuplicatedBatteryTraits(device.Traits);
                }
            }

            return result;
        }

        private static void RemoveDuplicatedBatteryTraits(IList<IDomoticzTrait> traits)
        {
            var traitFound = false;
            for (int i = 0; i < traits.Count; ++i)
            {
                if (traits[i] is BatteryTrait)
                {
                    if (traitFound)
                        traits.RemoveAt(i--);
                    else traitFound = true;
                }
            }
        }

        private static IEnumerable<IGrouping<int, DomoticzDeviceModel>> GroupByDevices(DomoticzHardware hardware, IEnumerable<DomoticzDeviceModel> models)
        {
            switch (hardware.Type)
            {
                case HardwareTypeValue.OpenZwaveUSB:
                {//Second byte specifies Z-Wave node index, e.g. 00000E32 is node 0x0E
                    return models.GroupBy(x =>
                    {
                        return (int)((x.Id & 0xFF00) >> 8);
                    });
                }
                default:
                {//Dunno
                    return models.GroupBy(x => x.Id);
                }
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
    }
}
