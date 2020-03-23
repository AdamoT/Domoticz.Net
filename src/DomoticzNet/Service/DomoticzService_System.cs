using System;
using System.Threading.Tasks;
using System.Web;
using DomoticzNet.Models;

namespace DomoticzNet.Service
{
	public partial class DomoticzService
	{
		public Task<InstanceInfoResponse> GetInstanceInfo()
		{
			var query = HttpUtility.ParseQueryString("");
			query[_QueryType] = _QueryTypeCommand;
			query[_QueryParam] = "getversion";

			return InvokeApiCall<InstanceInfoResponse>(query);
		}

		public Task<DomoticzSettingsResponse> GetSettings()
		{
			//json.htm?type=settings
			var query = HttpUtility.ParseQueryString("");
			query[_QueryType] = "settings";

			return InvokeApiCall<DomoticzSettingsResponse>(query);
		}

		public Task<SunriseSunsetInfoResponse> GetSunriseSunsetInfo()
		{
			var query = HttpUtility.ParseQueryString("");
			query[_QueryType] = _QueryTypeCommand;
			query[_QueryParam] = "getSunRiseSet";

			return InvokeApiCall<SunriseSunsetInfoResponse>(query);
		}

		public Task<GetLogsResponse> GetLogs(TimeSpan timeSpan = default, LogLevel logLevel = LogLevel.All)
		{
			//json.htm?type=command&param=getlog&lastlogtime=LASTLOGTIME&loglevel=LOGLEVEL 
			var query = HttpUtility.ParseQueryString("");
			query[_QueryType] = _QueryTypeCommand;
			query[_QueryParam] = "getlog";
			query["lastlogtime"] = ((int) Math.Round(timeSpan.TotalSeconds)).ToString();
			query["loglevel"] = ((int) logLevel).ToString();

			return InvokeApiCall<GetLogsResponse>(query);
		}

		public Task AddLog(string message)
		{
			//json.htm?type=command&param=sendnotification&subject=SUBJECT&body=THEBODY
			var query = HttpUtility.ParseQueryString("");
			query[_QueryType] = _QueryTypeCommand;
			query[_QueryParam] = "addlogmessage";
			query["message"] = message;

			return InvokeApiCall<CommandResponse>(query);
		}

		public Task Shutdown()
		{
			//json.htm?type=command&param=system_shutdown

			var query = HttpUtility.ParseQueryString("");
			query[_QueryType] = _QueryTypeCommand;
			query[_QueryParam] = "system_shutdown";

			return InvokeApiCall<CommandResponse>(query);
		}

		public Task Reboot()
		{
			//json.htm?type=command&param=system_reboot

			var query = HttpUtility.ParseQueryString("");
			query[_QueryType] = _QueryTypeCommand;
			query[_QueryParam] = "system_reboot";

			return InvokeApiCall<CommandResponse>(query);
		}
	}
}