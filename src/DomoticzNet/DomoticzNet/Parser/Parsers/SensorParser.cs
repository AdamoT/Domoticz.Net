using DomoticzNet.Models;
using DomoticzNet.Parser.Traits;

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DomoticzNet.Parser.Parsers
{
    public class SensorParser : ITraitParser
    {
        #region ITraitParser

        public void ParseProperties(DomoticzDeviceModel model, ICollection<IDomoticzTrait> traits)
        {
            if (model is null)
                throw new ArgumentNullException(nameof(model));
            if (traits is null)
                throw new ArgumentNullException(nameof(traits));

            if (model.Type == DeviceType.TemperatureSensor
                || model.Type == DeviceType.BrightnessSensor
                || (model.Type == DeviceType.Usage && model.SubType == DeviceSubType.Electric)
                || (model.Type == DeviceType.General && model.SubType == DeviceSubType.Voltage)
                || (model.Type == DeviceType.Current)
                )
            {
                if (!TryGetSingleSensorValue(model.Data, out var value, out var unitType))
                    throw new InvalidOperationException($"Failed to parse sensor data from {model.Data} of type {model.Type} subtype {model.SubType}");

                traits.Add(new SensorTrait(model)
                {
                    Unit = unitType,
                    Value = value,
                });
            }
            else if (model.Type == DeviceType.TemperatureAndHumiditySensor)
            {
                var items = model.Data.Split(',');
                for (int i = 0; i < items.Length; ++i)
                {
                    if (!TryGetSingleSensorValue(items[i], out var value, out var unitType))
                        throw new InvalidOperationException($"Failed to parse sensor data from {model.Data} of type {model.Type} subtype {model.SubType}");

                    traits.Add(new SensorTrait(model)
                    {
                        Unit = unitType,
                        Value = value,
                    });
                }
            }
            else if (model.Type == DeviceType.General && model.SubType == DeviceSubType.kWh)
            {
                if (!string.IsNullOrEmpty(model.CounterToday))
                {
                    if (!TryGetSingleSensorValue(model.Data, out var value, out var unitType))
                        throw new InvalidOperationException($"Failed to parse sensor data from {model.Data} of type {model.Type} subtype {model.SubType}");

                    traits.Add(new SensorTrait(model)
                    {
                        Value = value,
                        Unit = unitType,
                    });
                }
                if (!string.IsNullOrEmpty(model.Usage))
                {
                    if (!TryGetSingleSensorValue(model.Usage, out var value, out var unit))
                        throw new InvalidOperationException($"Failed to parse sensor Usage from {model.Usage} of type {model.Type} subtype {model.SubType}");

                    traits.Add(new SensorTrait(model)
                    {
                        Value = value,
                        Unit = unit,
                    });
                }
            }
        }

        #endregion ITraitParser

        #region Fields

        private Regex _SensorValueWithUnitRegex = new Regex(@"([\d.]+) ([\w%]+)");

        #endregion Fields

        #region Private Methods

        public bool TryGetSingleSensorValue(string data, out float value, out UnitType unitType)
        {
            unitType = UnitType.Unknown;
            value = 0;
            var match = _SensorValueWithUnitRegex.Match(data);
            if (match.Success && match.Groups.Count >= 3)
            {
                value = float.Parse(match.Groups[1].Value, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture);
                var unitStr = match.Groups[2].Value;

                switch (unitStr)
                {
                    case "C":
                        unitType = UnitType.Celcius;
                        break;
                    case "F":
                        unitType = UnitType.Fahrenheit;
                        break;
                    case "K":
                        unitType = UnitType.Kelvin;
                        break;
                    case "V":
                        unitType = UnitType.Volt;
                        break;
                    case "A":
                        unitType = UnitType.Amper;
                        break;
                    case "Watt":
                        unitType = UnitType.Watt;
                        break;
                    case "kWh":
                        unitType = UnitType.KiloWattPerHour;
                        break;
                    case "Lux":
                        unitType = UnitType.Lux;
                        break;
                    case "%":
                        unitType = UnitType.Percent;
                        break;
                }
            }

            if (unitType == UnitType.Unknown)
                return false;
            else return true;
        }

        #endregion Private Methods
    }
}
