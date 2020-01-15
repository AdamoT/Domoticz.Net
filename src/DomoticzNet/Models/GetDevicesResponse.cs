using Newtonsoft.Json;

using System.Collections.Generic;

namespace DomoticzNet.Models
{
    public partial class GetDevicesResponse : SunriseSunsetInfoResponse
    {
        [JsonProperty("ActTime")]
        public long ActTime { get; set; }

        [JsonProperty("app_version")]
        public string AppVersion { get; set; }

        [JsonProperty("result")]
        public List<DomoticzDeviceModel> Devices { get; } = new List<DomoticzDeviceModel>();
    }
}
