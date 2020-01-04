using DomoticzNet.Models;

using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace DomoticzNet.Service
{
    public partial class DomoticzService
    {
        public async Task<List<DomoticzDeviceModel>> GetDevices(DeviceFilter filter = DeviceFilter.All, bool used = true, bool favorite = false, bool hidden = false)
        {
            var query = HttpUtility.ParseQueryString("");
            query[_QueryType] = _QueryTypeDevices;
            query["filter"] = filter.GetQueryName();
            query["used"] = used.ToString(CultureInfo.InvariantCulture);
            query["favorite"] = favorite ? "1" : "0";
            query["displayhidden"] = hidden ? "1" : "0";

            var response = await InvokeApiCall<GetDevicesResponse>(query)
                .ConfigureAwait(false);

            return response.Devices;
        }

        public async Task<DomoticzDeviceModel> GetDevice(int idx)
        {
            var query = HttpUtility.ParseQueryString("");
            query[_QueryType] = _QueryTypeDevices;
            query["rid"] = idx.ToString(CultureInfo.InvariantCulture);

            return (await InvokeApiCall<GetDevicesResponse>(query)
                .ConfigureAwait(false))?.Devices.FirstOrDefault();
        }
    }
}
