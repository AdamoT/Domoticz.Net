using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using DomoticzNet.Models;
using DomoticzNet.Parser.Traits;

namespace DomoticzNet.Parser.Parsers
{
	public class SensorParser : ITraitParser
	{
		#region Fields

		private readonly Regex _SensorValueWithUnitRegex = new Regex(@"([\d.]+) ([\w%]+)");

		#endregion Fields

		#region ITraitParser

		public void ParseProperties(DomoticzDeviceModel model, ICollection<IDomoticzTrait> traits)
		{
			if (model is null)
				throw new ArgumentNullException(nameof(model));
			if (traits is null)
				throw new ArgumentNullException(nameof(traits));

			if (model.Type == DeviceType.TemperatureSensor
				|| model.Type == DeviceType.BrightnessSensor
				|| model.Type == DeviceType.Usage && model.SubType == DeviceSubType.Electric
				|| model.Type == DeviceType.General && model.SubType == DeviceSubType.Voltage
				|| model.Type == DeviceType.Current
			)
			{
				if (!TryGetSingleSensorValue(model.Data, out var value, out var unitType))
					throw new InvalidOperationException($"Failed to parse sensor data from {model.Data} of type {model.Type} subtype {model.SubType}");

				traits.Add(new SensorTrait(model)
				{
					Unit = unitType,
					Value = value,
					SensorType = RecognizeSensorType(model, unitType)
				});
			}
			else if (model.Type == DeviceType.TemperatureAndHumiditySensor)
			{
				var items = model.Data.Split(',');
				for (var i = 0; i < items.Length; ++i)
				{
					if (!TryGetSingleSensorValue(items[i], out var value, out var unitType))
						throw new InvalidOperationException($"Failed to parse sensor data from {model.Data} of type {model.Type} subtype {model.SubType}");

					traits.Add(new SensorTrait(model)
					{
						Unit = unitType,
						Value = value,
						SensorType = RecognizeSensorType(model, unitType)
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
						SensorType = RecognizeSensorType(model, unitType)
					});
				}

				if (!string.IsNullOrEmpty(model.Usage))
				{
					if (!TryGetSingleSensorValue(model.Usage, out var value, out var unitType))
						throw new InvalidOperationException($"Failed to parse sensor Usage from {model.Usage} of type {model.Type} subtype {model.SubType}");

					traits.Add(new SensorTrait(model)
					{
						Value = value,
						Unit = unitType,
						SensorType = RecognizeSensorType(model, unitType)
					});
				}
			}
		}

		#endregion ITraitParser

		#region Private Methods

		private static SensorType RecognizeSensorType(DomoticzDeviceModel model, UnitType unit)
		{
			if (unit == UnitType.Unknown || unit == UnitType.NotApplicable)
				return SensorType.Unknown;
			if (unit > UnitType.ClassStartTemperature && unit < UnitType.ClassEndTemperature)
				return SensorType.Temperature;
			if (unit > UnitType.ClassStartLightBrightness && unit < UnitType.ClassEndLightBrightness)
				return SensorType.LightIntensity;
			if (unit > UnitType.ClassStartVoltage && unit < UnitType.ClassEndVoltage)
				return SensorType.Voltage;
			if (unit > UnitType.ClassStartPower && unit < UnitType.ClassEndPower)
				return SensorType.Power;
			if (unit > UnitType.ClassStartPowerConsumption && unit < UnitType.ClassEndPowerConsumption)
				return SensorType.PowerConsumption;
			if (unit > UnitType.ClassStartPowerCurrent && unit < UnitType.ClassEndPowerCurrent)
				return SensorType.Current;
			if (unit == UnitType.Percentage && model.Type == DeviceType.TemperatureAndHumiditySensor)
				return SensorType.Humidity;
			return SensorType.Unknown;
		}

		public bool TryGetSingleSensorValue(string data, out float value, out UnitType unitType)
		{
			unitType = UnitType.Unknown;
			value = 0;
			var match = _SensorValueWithUnitRegex.Match(data);
			if (match.Success && match.Groups.Count >= 3)
			{
				value = float.Parse(match.Groups[1].Value, NumberStyles.Any, CultureInfo.InvariantCulture);
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
						unitType = UnitType.Percentage;
						break;
				}
			}

			if (unitType == UnitType.Unknown)
				return false;
			return true;
		}

		#endregion Private Methods
	}
}