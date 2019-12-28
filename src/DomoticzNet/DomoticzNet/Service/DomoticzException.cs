using System;

namespace DomoticzNet.Service
{
    public class DomoticzException : Exception
    {
        public DomoticzException()
        {
        }

        public DomoticzException(string message) : base(message)
        {
        }

        public DomoticzException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
