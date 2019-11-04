using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Clockify.Net.Models;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Serialization.Json;

namespace Clockify.Net {
	public class ClockifyClient {
		private const string BaseUrl = "https://api.clockify.me/api/v1";
		private const string ApiKeyHeaderName = "X-Api-Key";
		private const string ApiKeyVariableName = "CAPI_KEY";
		private readonly IRestClient _client;

		public ClockifyClient(string apiKey) {
			_client = new RestClient(BaseUrl);
			_client.AddDefaultHeader(ApiKeyHeaderName, apiKey);
		}

		/// <summary>
		/// Creates new <see cref="ClockifyClient"/>.
		/// Uses value from environment variable named "CAPI_KEY"
		/// </summary>
		public ClockifyClient() {
			var apiKey = Environment.GetEnvironmentVariable(ApiKeyVariableName);
			if (apiKey == null) throw new ArgumentException($"Environment variable {ApiKeyVariableName} is not set.");
			_client = new RestClient(BaseUrl);
			_client.AddDefaultHeader(ApiKeyHeaderName, apiKey);
//			_client.AddHandler("application/json", () => {
//				var jsonSerializer = new JsonSerializer();
//				return jsonSerializer;
//			});
		}

		/// <summary>
		/// Find workspaces for currently logged in user
		/// </summary>
		public async Task<IList<WorkspaceDto>> GetWorkspaces() {
			var request = new RestRequest("workspaces");
			var res = _client.Get<List<WorkspaceDto>>(request);
			return res.Data;
		}
	}
}