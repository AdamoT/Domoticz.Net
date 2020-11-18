using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using DomoticzNet.Models;
using DomoticzNet.Service.Converters;
using Newtonsoft.Json;

namespace DomoticzNet.Service
{
    /// <summary>
    ///     Domoticz http service API
    /// </summary>
    /// <see cref="https://www.domoticz.com/wiki/Domoticz_API/JSON_URL%27s" />
    public partial class DomoticzService
	{
		#region Fields

		private readonly IDomoticzAuthorizationProvider _AuthorizationProvider = null;

		#endregion Fields

		#region Constructors

		public DomoticzService(string host, int port, IDomoticzAuthorizationProvider authorizationProvider = null)
		{
			Serializer = JsonSerializer.Create(SerializerSettings);

			Host = string.IsNullOrEmpty(host)
				? throw new ArgumentNullException(nameof(host))
				: host;
			Port = port;
			_AuthorizationProvider = authorizationProvider;
		}

		#endregion Constructors

		#region Properties

		public string Host { get; }
		public int Port { get; }

		public static JsonSerializerSettings SerializerSettings { get; } = new JsonSerializerSettings
		{
			Formatting = Formatting.Indented,
			Converters = new List<JsonConverter>
			{
				new ColorValueConverter()
			},
			MissingMemberHandling = MissingMemberHandling.Ignore,
		};

		public JsonSerializer Serializer { get; }

		#endregion Properties

		#region Consts

		private const string _QueryType = "type";
		private const string _QueryTypeCommand = "command";
		private const string _QueryTypeDevices = "devices";
		private const string _QueryParam = "param";
		private const string _QueryParamSwitchLight = "switchlight";
		private const string _QueryParamSetColor = "setcolbrightnessvalue";
		private const string _QueryIdx = "idx";
		private const string _QuerySwitchCmd = "switchcmd";
		private const string _QuerySwitchCmdToggle = "Toggle";

		private const string _QueryBrightness = "brightness";
		private const string _QueryIsWhite = "isWhite";

		#endregion Consts

		#region Private Methods

		private async Task<T> InvokeApiCall<T>(NameValueCollection query) where T : class
		{
			var uri = new UriBuilder("http", Host, Port, "json.htm");
			uri.Query = query.ToString();
			_AuthorizationProvider?.AuthorizeUri(uri);

			var request = WebRequest.CreateHttp(uri.Uri);
			request.Method = "GET";

			_AuthorizationProvider?.AuthorizeRequest(request);

			using (var response = await request.GetResponseAsync()
				.ConfigureAwait(false))
			{
				using (var responseStream = response.GetResponseStream())
				{
					if (typeof(T) == typeof(string))
						using (var textReader = new StreamReader(responseStream))
						{
							return await textReader.ReadToEndAsync()
								.ConfigureAwait(false) as T;
						}

					using (var jsonReader = new JsonTextReader(new StreamReader(responseStream)))
					{
						var result = Serializer.Deserialize<T>(jsonReader);
						if (result is CommandResponse commandResponse)
							if (commandResponse.Status == ResponseStatus.Error)
								throw new DomoticzException(commandResponse.Message);

						return result;
					}
				}
			}
		}
	}

	#endregion Private Methods
}