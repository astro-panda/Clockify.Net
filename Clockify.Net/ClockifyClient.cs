using Clockify.Net.Clients;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;
using System;
using System.Collections.Generic;

namespace Clockify.Net;
public partial class ClockifyClient : IClockifyClient {
	
	private RestClient _client;
	private RestClient _experimentalClient;
	private RestClient _ptoClient;
	private RestClient _reportsClient;

	public ClockifyClient(string apiKey,
                        string apiUrl = Constants.ApiUrl,
                        string experimentalApiUrl = Constants.ExperimentalApiUrl,
                        string reportsApiUrl = Constants.ReportsApiUrl,
                        string ptoApiUrl = Constants.PTOApiUrl) {
		InitClients(apiKey, apiUrl, experimentalApiUrl, reportsApiUrl, ptoApiUrl);
	}

    public IClockifyExperimentalClient Experimental => throw new NotImplementedException();

    public IClockifyReportsClient Reports => throw new NotImplementedException();

    public IClockifyPTOClient PaidTimeOff => throw new NotImplementedException();

    /// <summary>
    /// Creates new <see cref="ClockifyClient"/>.
    /// Uses value from environment variable named "CAPI_KEY"
    /// </summary>


    #region Private methods
    private void InitClients(string apiKey, string apiUrl, string experimentalApiUrl, string reportsApi, string ptoApi) {
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

		_experimentalClient = new RestClient(experimentalApiUrl, configureSerialization: config => config.UseNewtonsoftJson(jsonSerializerSettings));
		_experimentalClient.AddDefaultHeader(Constants.ApiKeyHeaderName, apiKey);		

		_reportsClient = new RestClient(reportsApi, configureSerialization: config => config.UseNewtonsoftJson(jsonSerializerSettings));
		_reportsClient.AddDefaultHeader(Constants.ApiKeyHeaderName, apiKey);		
		
		_ptoClient = new RestClient(ptoApi, configureSerialization: config => config.UseNewtonsoftJson(jsonSerializerSettings));
		_ptoClient.AddDefaultHeader(Constants.ApiKeyHeaderName, apiKey);		
	}
	#endregion
}