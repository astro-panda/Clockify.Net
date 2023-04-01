using System;
using Clockify.Net.Api.Balance;
using Clockify.Net.Api.Client;
using Clockify.Net.Json;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

namespace Clockify.Net; 

public class ClockifyClient2 : IDisposable{
	private const string ApiUrl = "https://api.clockify.me/api/v1";
	private const string ExperimentalApiUrl = "https://api.clockify.me/api/";
	private const string ReportsApiUrl = "https://reports.api.clockify.me/v1";
	private const string PtoApiUrl = "https://pto.api.clockify.me/v1";
	private const string ApiKeyHeaderName = "X-Api-Key";
	private const string ApiKeyVariableName = "CAPI_KEY";
	private readonly RestClient _client;
	private readonly RestClient _experimentalClient;
	private readonly RestClient _ptoClient;
	private readonly RestClient _reportsClient;

	public ClockifyClient2(string apiKey, string apiUrl = ApiUrl, string experimentalApiUrl = ExperimentalApiUrl,
	                       string reportsApiUrl = ReportsApiUrl, string ptoApiUrl = PtoApiUrl) {
		
		_client = CreateClient(apiKey, apiUrl);
		_experimentalClient = CreateClient(apiKey, experimentalApiUrl);
		_reportsClient = CreateClient(apiKey, reportsApiUrl);
		_ptoClient = CreateClient(apiKey, ptoApiUrl);

		Balance = new ClockifyBalanceApi(_ptoClient);
		Client = new ClockifyClientApi(_client);
	}

	/// <summary>
	/// Creates new <see cref="ClockifyClient"/>.
	/// Uses value from environment variable named "CAPI_KEY"
	/// </summary>
	public ClockifyClient2() : this(GetApiKeyFromEnv()) { }

	public virtual IClockifyBalanceApi Balance { get; }
	public virtual IClockifyClientApi Client { get; }
	
	private static string GetApiKeyFromEnv() {
		var apiKey = Environment.GetEnvironmentVariable(ApiKeyVariableName);
		if (apiKey is null) {
			throw new ArgumentException($"Environment variable {ApiKeyVariableName} is not set.");
		}

		return apiKey;
	}

	private static RestClient CreateClient(string apiKey, string apiUrl) {
		var client = new RestClient(apiUrl);
		client.AddDefaultHeader(ApiKeyHeaderName, apiKey);
		client.UseNewtonsoftJson(DefaultJsonSettings.Settings);
		return client;
	}

	public void Dispose() {
		_client.Dispose();
		_experimentalClient.Dispose();
		_ptoClient.Dispose();
		_reportsClient.Dispose();
	}
}