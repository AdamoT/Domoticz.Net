using System;

namespace DomoticzNet.Service
{
	[Serializable]
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