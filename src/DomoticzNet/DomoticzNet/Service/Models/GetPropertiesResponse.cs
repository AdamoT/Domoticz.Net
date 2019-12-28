using Newtonsoft.Json;

using System.Collections.Generic;

namespace DomoticzNet.Service.Models
{
    public partial class GetPropertiesResponse : SunriseSunsetInfoResponse
    {
        [JsonProperty("ActTime")]
        public long ActTime { get; set; }

        [JsonProperty("app_version")]
        public string AppVersion { get; set; }

        [JsonProperty("result")]
        public List<DomoticzPropertyModel> Result { get; } = new List<DomoticzPropertyModel>();
    }
}
