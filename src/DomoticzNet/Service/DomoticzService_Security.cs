using System.Threading.Tasks;
using System.Web;
using DomoticzNet.Models;

namespace DomoticzNet.Service
{
	public partial class DomoticzService
	{
		public Task<SecurityStatusResponse> GetSecurityState()
		{
			//json.htm?type=command&param=getsecstatus

			var query = HttpUtility.ParseQueryString("");
			query[_QueryType] = _QueryTypeCommand;
			query[_QueryParam] = "getsecstatus";

			return InvokeApiCall<SecurityStatusResponse>(query);
		}
	}
}