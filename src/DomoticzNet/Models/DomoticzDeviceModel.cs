using DomoticzNet.Service.Converters;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;

namespace DomoticzNet.Models
{
    public class DomoticzDeviceModel
    {
        [JsonProperty("AddjMulti")]
        public float AddjMulti { get; set; }

        [JsonProperty("AddjMulti2")]
        public float AddjMulti2 { get; set; }

        [JsonProperty("AddjValue")]
        public float AddjValue { get; set; }

        [JsonProperty("AddjValue2")]
        public float AddjValue2 { get; set; }

        [JsonProperty("BatteryLevel")]
        public byte BatteryLevel { get; set; }

        /// <summary>
        /// Color Value or empty string if not turned on
        /// </summary>
        [JsonProperty("Color", NullValueHandling = NullValueHandling.Ignore)]
        public ColorValue Color { get; set; }

        [JsonProperty("CustomImage")]
        public int CustomImage { get; set; }

        [JsonProperty("Data")]
        public string Data { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <see cref="Models.DimmerType"/>
        [JsonProperty("DimmerType", NullValueHandling = NullValueHandling.Ignore)]
        public string DimmerType { get; set; }

        [JsonProperty("Favorite")]
        public bool Favorite { get; set; }

        [JsonProperty("HardwareID")]
        public int HardwareId { get; set; }

        [JsonProperty("HardwareName")]
        public string HardwareName { get; set; }

        [JsonProperty("HardwareType")]
        public string HardwareType { get; set; }

        [JsonProperty("HardwareTypeVal")]
        public HardwareTypeValue HardwareTypeVal { get; set; }

        [JsonProperty("HaveDimmer", NullValueHandling = NullValueHandling.Ignore)]
        public bool? HaveDimmer { get; set; }

        [JsonProperty("HaveGroupCmd", NullValueHandling = NullValueHandling.Ignore)]
        public bool? HaveGroupCmd { get; set; }

        [JsonProperty("HaveTimeout")]
        public bool HaveTimeout { get; set; }

        [JsonProperty("ID")]
        [JsonConverter(typeof(HexNumberConverter))]
        public int Id { get; set; }

        [JsonProperty("Image", NullValueHandling = NullValueHandling.Ignore)]
        public string Image { get; set; }

        [JsonProperty("IsSubDevice", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsSubDevice { get; set; }

        [JsonProperty("LastUpdate")]
        public DateTime LastUpdate { get; set; }

        [JsonProperty("Level", NullValueHandling = NullValueHandling.Ignore)]
        public int? Level { get; set; }

        [JsonProperty("LevelInt", NullValueHandling = NullValueHandling.Ignore)]
        public int? LevelInt { get; set; }

        [JsonProperty("MaxDimLevel", NullValueHandling = NullValueHandling.Ignore)]
        public int? MaxDimLevel { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Notifications")]
        public bool Notifications { get; set; }

        [JsonProperty("PlanID")]
        public int PlanId { get; set; }

        [JsonProperty("PlanIDs")]
        public List<long> PlanIDs { get; } = new List<long>();

        [JsonProperty("Protected")]
        public bool Protected { get; set; }

        [JsonProperty("ShowNotifications")]
        public bool ShowNotifications { get; set; }

        [JsonProperty("SignalLevel")]
        public string SignalLevel { get; set; }

        [JsonProperty("Status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }

        [JsonProperty("StrParam1", NullValueHandling = NullValueHandling.Ignore)]
        public string StrParam1 { get; set; }

        [JsonProperty("StrParam2", NullValueHandling = NullValueHandling.Ignore)]
        public string StrParam2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <see cref="Models.DeviceSubType"/>
        [JsonProperty("SubType")]
        public string SubType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <see cref="Models.SwitchType"/>
        [JsonProperty("SwitchType", NullValueHandling = NullValueHandling.Ignore)]
        public string SwitchType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <see cref="SwitchTypeVal"/>
        [JsonProperty("SwitchTypeVal", NullValueHandling = NullValueHandling.Ignore)]
        public SwitchTypeVal SwitchTypeVal { get; set; }

        [JsonProperty("Timers")]
        public bool Timers { get; set; }

        /// <summary>
        /// Known values: Color Switch, Light/Switch, Usage, Thermostat, General, Temp, Lux, Lighting 2, Security
        /// </summary>
        /// <see cref="Models.DeviceType"/>
        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("TypeImg")]
        public string TypeImg { get; set; }

        [JsonProperty("Unit")]
        public bool Unit { get; set; }

        [JsonProperty("Used")]
        public bool Used { get; set; }

        [JsonProperty("UsedByCamera", NullValueHandling = NullValueHandling.Ignore)]
        public bool? UsedByCamera { get; set; }

        [JsonProperty("XOffset")]
        public int XOffset { get; set; }

        [JsonProperty("YOffset")]
        public int YOffset { get; set; }

        [JsonProperty("idx")]
        public int Idx { get; set; }

        [JsonProperty("SetPoint", NullValueHandling = NullValueHandling.Ignore)]
        public float? SetPoint { get; set; }

        [JsonProperty("Mode", NullValueHandling = NullValueHandling.Ignore)]
        public int? Mode { get; set; }

        [JsonProperty("Modes", NullValueHandling = NullValueHandling.Ignore)]
        public string Modes { get; set; }

        [JsonProperty("CounterToday", NullValueHandling = NullValueHandling.Ignore)]
        public string CounterToday { get; set; }

        [JsonProperty("Options", NullValueHandling = NullValueHandling.Ignore)]
        public string Options { get; set; }

        [JsonProperty("Usage", NullValueHandling = NullValueHandling.Ignore)]
        public string Usage { get; set; }

        [JsonProperty("Voltage", NullValueHandling = NullValueHandling.Ignore)]
        public float? Voltage { get; set; }

        [JsonProperty("displaytype", NullValueHandling = NullValueHandling.Ignore)]
        public long? Displaytype { get; set; }

        [JsonProperty("DayTime", NullValueHandling = NullValueHandling.Ignore)]
        public string DayTime { get; set; }

        [JsonProperty("Temp", NullValueHandling = NullValueHandling.Ignore)]
        public float? Temp { get; set; }

        [JsonProperty("InternalState", NullValueHandling = NullValueHandling.Ignore)]
        public string InternalState { get; set; }

        [JsonProperty("DewPoint", NullValueHandling = NullValueHandling.Ignore)]
        public double? DewPoint { get; set; }

        [JsonProperty("Humidity", NullValueHandling = NullValueHandling.Ignore)]
        public int? Humidity { get; set; }

        [JsonProperty("HumidityStatus", NullValueHandling = NullValueHandling.Ignore)]
        public string HumidityStatus { get; set; }

        public override string ToString() => $"IDX: {Idx} Name: {Name}";
    }
}
