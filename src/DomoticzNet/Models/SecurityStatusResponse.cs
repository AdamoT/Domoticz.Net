using Newtonsoft.Json;

namespace DomoticzNet.Models
{
	public class SecurityStatusResponse : CommandResponse
	{
		[JsonProperty("secondelay")]
		public long Secondelay { get; set; }

		[JsonProperty("secstatus")]
		public DomoticzSecurityStatus Secstatus { get; set; }
	}

	public enum DomoticzSecurityStatus
	{
		Disarmed = 0,
		ArmHome = 1,
		ArmAway = 2,
		Unknown = 3
	}
}