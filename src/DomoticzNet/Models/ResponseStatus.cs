using Newtonsoft.Json;

namespace DomoticzNet.Models
{
    public enum ResponseStatus
    {
        [JsonProperty("Ok")]
        OK,
        [JsonProperty("Err")]
        Error,
    }
}
