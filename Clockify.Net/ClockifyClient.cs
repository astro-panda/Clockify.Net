using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

namespace Clockify.Net
{
    public partial class ClockifyClient
    {
        private const string ApiUrl = "https://api.clockify.me/api/v1";
        private const string ExperimentalApiUrl = "https://api.clockify.me/api/";
        private const string ReportsApiUrl = "https://reports.api.clockify.me/v1";
        private const string ApiKeyHeaderName = "X-Api-Key";
        private const string ApiKeyVariableName = "CAPI_KEY";
        private IRestClient _client;
        private IRestClient _experimentalClient;
        private IRestClient _reportsClient;

        public ClockifyClient(string apiKey, string apiUrl = ApiUrl, string experimentalApiUrl = ExperimentalApiUrl, string reportsApiUrl = ReportsApiUrl)
        {
            InitClients(apiKey, apiUrl, experimentalApiUrl, reportsApiUrl);
        }

        /// <summary>
        /// Creates new <see cref="ClockifyClient"/>.
        /// Uses value from environment variable named "CAPI_KEY"
        /// </summary>
        public ClockifyClient() : this(GetApiKeyFromEnv()) { }

        #region Private methods

        private static string GetApiKeyFromEnv() {
            var apiKey = Environment.GetEnvironmentVariable(ApiKeyVariableName);
            if (apiKey == null) {
                throw new ArgumentException($"Environment variable {ApiKeyVariableName} is not set.");
            }

            return apiKey;
        }

        private void InitClients(string apiKey, string apiUrl, string experimentalApiUrl, string reportsApi)
        {
            var jsonSerializerSettings = new JsonSerializerSettings()
            {
                Converters = new List<JsonConverter>
                {
                    new StringEnumConverter(),
                    new IsoDateTimeConverter()
                    {
                        DateTimeFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'ss'Z'"
                    }
                },
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
            };

            _client = new RestClient(apiUrl);
            _client.AddDefaultHeader(ApiKeyHeaderName, apiKey);
            _client.UseNewtonsoftJson(jsonSerializerSettings);

            _experimentalClient = new RestClient(experimentalApiUrl);
            _experimentalClient.AddDefaultHeader(ApiKeyHeaderName, apiKey);
            _experimentalClient.UseNewtonsoftJson(jsonSerializerSettings);

            _reportsClient = new RestClient(reportsApi);
            _reportsClient.AddDefaultHeader(ApiKeyHeaderName, apiKey);
            _reportsClient.UseNewtonsoftJson(jsonSerializerSettings);
        }

        #endregion
    }
}
