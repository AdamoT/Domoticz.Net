using Newtonsoft.Json;

using System;
using System.Linq;

namespace DomoticzNet.Models
{
    public enum DeviceFilter
    {
        [JsonProperty("all")]
        All,
        [JsonProperty("light")]
        Light,
        [JsonProperty("weather")]
        Weather,
        [JsonProperty("temp")]
        Temperature,
        [JsonProperty("utility")]
        Utility,
        [JsonProperty("wind")]
        Wind,
        [JsonProperty("rain")]
        Rain,
        [JsonProperty("uv")]
        UV,
        [JsonProperty("baro")]
        Baromether,
        [JsonProperty("zwavealarms")]
        ZWaveAlarms,
    }

    public static class DeviceFilterExtensions
    {
        public static string GetQueryName(this DeviceFilter filter)
        {
            var type = typeof(DeviceFilter);
            return type.GetMember(filter.ToString())
                .FirstOrDefault()
                ?.GetCustomAttributes(typeof(JsonPropertyAttribute), true)
                .Cast<JsonPropertyAttribute>()
                .FirstOrDefault()
                ?.PropertyName
                ?? throw new InvalidOperationException($"Filter is missing {nameof(JsonPropertyAttribute)}");
        }
    }

}
