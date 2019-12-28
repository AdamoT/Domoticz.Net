using Newtonsoft.Json;

namespace DomoticzNet.Service.Models
{
    public enum ResponseStatus
    {
        [JsonProperty("Ok")]
        OK,
        [JsonProperty("Err")]
        Error,
    }
}
