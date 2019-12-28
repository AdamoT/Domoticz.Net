using Newtonsoft.Json;

using System.Collections.Generic;

namespace DomoticzNet.Service.Models
{
    public class GetLogsResponse
    {
        [JsonProperty("LastLogTime")]
        public long LastLogTime { get; set; }

        [JsonProperty("result")]
        public List<LogMessage> Result { get; } = new List<LogMessage>();

#pragma warning disable CA1034 // Nested types should not be visible
        public class LogMessage
#pragma warning restore CA1034 // Nested types should not be visible
        {
            [JsonProperty("level")]
            public long Level { get; set; }

            [JsonProperty("message")]
            public string Message { get; set; }

            public override string ToString() => Message;
        }
    }
}
