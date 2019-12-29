
using Newtonsoft.Json;

using System;

namespace DomoticzNet.Models
{
    public class InstanceInfoResponse : CommandResponse
    {
        [JsonProperty("DomoticzUpdateURL")]
        public Uri DomoticzUpdateUrl { get; set; }

        [JsonProperty("HaveUpdate")]
        public bool HaveUpdate { get; set; }

        [JsonProperty("Revision")]
        public long Revision { get; set; }

        [JsonProperty("SystemName")]
        public string SystemName { get; set; }

        [JsonProperty("UseUpdate")]
        public bool UseUpdate { get; set; }

        [JsonProperty("build_time")]
        public DateTime BuildTime { get; set; }

        [JsonProperty("dzvents_version")]
        public string DzventsVersion { get; set; }

        [JsonProperty("hash")]
        public string Hash { get; set; }

        [JsonProperty("python_version")]
        public string PythonVersion { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }
    }
}
