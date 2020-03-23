using System;
using Newtonsoft.Json;

namespace DomoticzNet.Models
{
	public class SunriseSunsetInfoResponse : CommandResponse
	{
		[JsonProperty("AstrTwilightEnd")]
		public DateTime AstrTwilightEnd { get; set; }

		[JsonProperty("AstrTwilightStart")]
		public DateTime AstrTwilightStart { get; set; }

		[JsonProperty("CivTwilightEnd")]
		public DateTime CivTwilightEnd { get; set; }

		[JsonProperty("CivTwilightStart")]
		public DateTime CivTwilightStart { get; set; }

		[JsonProperty("DayLength")]
		public TimeSpan DayLength { get; set; }

		[JsonProperty("NautTwilightEnd")]
		public DateTime NautTwilightEnd { get; set; }

		[JsonProperty("NautTwilightStart")]
		public DateTime NautTwilightStart { get; set; }

		[JsonProperty("ServerTime")]
		public DateTime ServerTime { get; set; }

		[JsonProperty("SunAtSouth")]
		public DateTime SunAtSouth { get; set; }

		[JsonProperty("Sunrise")]
		public DateTime Sunrise { get; set; }

		[JsonProperty("Sunset")]
		public DateTime Sunset { get; set; }
	}
}