using System;
using System.Collections.Generic;
using System.Text;

namespace DomoticzIntegration.Service.Models
{
    public class CommandResponse
    {
        public ResponseStatus Status { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
    }
}
