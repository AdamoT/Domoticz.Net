using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Text.Json;
using System.Memory;

namespace DomoticzNet.Service
{
    public class DomoticzService : IDomoticzService
    {
        #region IDomoticzService

        //public Task<InstanceInfo> GetInstanceInfo()
        //{
        //    NameValueCollection query = HttpUtility.ParseQueryString("");
        //    query["type"] = "command";
        //    query["param"] = "getversion";

        //    return InvokeApiCall<InstanceInfo>(query);
        //}

        //public async Task GetProperties(ICollection<DomoticzProperty> result, DeviceFilters filter = DeviceFilters.all, bool used = true, bool favorite = false)
        //{
        //    if (result is null)
        //        throw new ArgumentNullException(nameof(result));

        //    NameValueCollection query = HttpUtility.ParseQueryString("");
        //    query["type"] = "devices";
        //    query["filter"] = filter.ToString();
        //    query["used"] = used.ToString();
        //    query["favorite"] = favorite ? "1" : "0";

        //    var response = await InvokeApiCall<GetPropertiesResponse>(query)
        //        .ConfigureAwait(false);

        //    if(response.result == null)
        //        return;

        //    for (int i = 0; i < response.result.Length; ++i)
        //        result.Add(response.result[i]);
        //}

        //public async Task<DomoticzProperty> GetProperty(int idx)
        //{
        //    NameValueCollection query = HttpUtility.ParseQueryString("");
        //    query["type"] = "devices";
        //    query["rid"] = idx.ToString();

        //    return (await InvokeApiCall<GetPropertiesResponse>(query)
        //        .ConfigureAwait(false))?.result.FirstOrDefault();
        //}

        //public Task<SunriseSunsetInfo> GetSunriseSunsetInfo()
        //{
        //    NameValueCollection query = HttpUtility.ParseQueryString("");
        //    query["type"] = "command";
        //    query["param"] = "getSunRiseSet";

        //    return InvokeApiCall<SunriseSunsetInfo>(query);
        //}

        //public Task SetLightSwitchState(int idx, bool state)
        //{
        //    NameValueCollection query = HttpUtility.ParseQueryString("");
        //    query["type"] = "command";
        //    query["param"] = "switchlight";
        //    query["idx"] = idx.ToString();
        //    query["switchcmd"] = state ? "On" : "Off";

        //    return InvokeApiCall<CommandResponse>(query);
        //}

        //public Task SetDimmLevel(int idx, int level)
        //{
        //    NameValueCollection query = HttpUtility.ParseQueryString("");
        //    query["type"] = "command";
        //    query["param"] = "switchlight";
        //    query["idx"] = idx.ToString();
        //    query["switchcmd"] = "Set Level";
        //    query["level"] = level.ToString();

        //    return InvokeApiCall<CommandResponse>(query);
        //}

        //public Task SetThermostatSetPoint(int idx, float setPoint)
        //{
        //    //json.htm?type=command&param=setsetpoint&idx=&setpoint=
        //    NameValueCollection query = HttpUtility.ParseQueryString("");
        //    query["type"] = "command";
        //    query["param"] = "setsetpoint";
        //    query["idx"] = idx.ToString();
        //    query["setpoint"] = setPoint.ToString(System.Globalization.CultureInfo.InvariantCulture);

        //    return InvokeApiCall<CommandResponse>(query);
        //}

        #endregion IDomoticzService

        #region Fields

        private IDomoticzAuthorizationProvider _AuthorizationProvider = null;
        private JsonSerializerOptions _SerializerOptions = new JsonSerializerOptions
        {
            AllowTrailingCommas = true,
        };

        #endregion Fields

        #region Constructors

        //public DomoticzService(IHttpEndPoint endPoint, ISerializer serializer, IPEndPoint domoticzAddress)
        //{
        //    EndPoint = endPoint ?? throw new ArgumentNullException(nameof(endPoint));
        //    Serializer = serializer ?? throw new ArgumentNullException(nameof(serializer));
        //    DomoticzAddress = domoticzAddress ?? throw new ArgumentNullException(nameof(domoticzAddress));
        //}

        #endregion Constructors

        #region Properties

        //public ISerializer Serializer { get; }
        //public IHttpEndPoint EndPoint { get; }
        public IPEndPoint DomoticzAddress { get; }

        //public string UserName { get; set; }
        //public string Password { get; set; }

        #endregion Properties

        #region Private Methods

        private async Task<T> InvokeApiCall<T>(NameValueCollection query) where T : class
        {
            var uri = new UriBuilder("http", DomoticzAddress.Address.ToString(), DomoticzAddress.Port, "json.htm");
            uri.Query = query.ToString();

            using (MemoryPool.AquireAsDisposable<MemoryStream>(out var stream))
            {
                var authorizationString = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{UserName}:{Password}"));
                EndPoint.Headers[HttpRequestHeader.Authorization] = $"Basic {authorizationString}";
                await EndPoint.GetIntoStream(uri.ToString(), stream)
                    .ConfigureAwait(false);

                stream.Position = 0;

                var serialized = new StreamReader(stream, Encoding.UTF8, true, 4096).ReadToEnd();
                stream.Position = 0;
                Console.WriteLine(serialized);

                var response = Serializer.Deserialize<T>(stream);

                if (response is CommandResponse commandResponse)
                {
                    if (commandResponse.Status == ResponseStatus.Ok)
                        return response;
                    else throw new DomoticzException(commandResponse.Message);
                }
                else return response;
            }
        }

        #endregion Private Methods
    }
}
