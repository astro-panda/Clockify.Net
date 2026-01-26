using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;
using System;
using System.Collections.Generic;

namespace Clockify.Net;
public partial class ClockifyClient 
{
	
	private RestClient _client;
	public ClockifyClient(string apiKey,
                        string apiUrl = Constants.ApiUrl) {
		InitClients(apiKey, apiUrl);
	}

    /// <summary>
    /// Creates new <see cref="ClockifyClient"/>.
    /// Uses value from environment variable named "CAPI_KEY"
    /// </summary>


    #region Private methods
    private void InitClients(string apiKey, string apiUrl) {
		var jsonSerializerSettings = new JsonSerializerSettings() {
			NullValueHandling = NullValueHandling.Ignore,

			Converters = new List<JsonConverter> {
				new StringEnumConverter(),
				new IsoDateTimeConverter() {
					DateTimeFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'ss'Z'"
				},
			},
			ContractResolver = new CamelCasePropertyNamesContractResolver(),
		};

		_client = new RestClient(apiUrl, configureSerialization: config => config.UseNewtonsoftJson(jsonSerializerSettings));
		_client.AddDefaultHeader(Constants.ApiKeyHeaderName, apiKey);
	}
	#endregion
}