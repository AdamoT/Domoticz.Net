using System.Collections.Generic;
using Newtonsoft.Json;

namespace DomoticzNet.Models
{
	public class GetDevicesResponse : SunriseSunsetInfoResponse
	{
		[JsonProperty("ActTime")]
		public long ActTime { get; set; }

		[JsonProperty("app_version")]
		public string AppVersion { get; set; }

		[JsonProperty("result")]
		public List<DomoticzDeviceModel> Devices { get; } = new List<DomoticzDeviceModel>();
	}
}