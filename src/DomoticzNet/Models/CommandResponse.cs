using Newtonsoft.Json;

namespace DomoticzNet.Models
{
	public class CommandResponse
	{
		[JsonProperty("title")]
		public string Title { get; set; }

		[JsonProperty("status")]
		public ResponseStatus Status { get; set; }

		[JsonProperty("message")]
		public string Message { get; set; }
	}
}