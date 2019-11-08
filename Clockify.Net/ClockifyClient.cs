using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Clockify.Net.Configuration;
using Clockify.Net.Models.Workspaces;
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
			SimpleJson.CurrentJsonSerializerStrategy = new CamelCaseSerializerStrategy();
			_client = new RestClient(BaseUrl);
			_client.AddDefaultHeader(ApiKeyHeaderName, apiKey);
		}

		/// <summary>
		/// Find workspaces for currently logged in user
		/// </summary>
		public async Task<IRestResponse<List<WorkspaceDto>>> GetWorkspaces() {
			var request = new RestRequest("workspaces");
			var response = await _client.ExecuteGetTaskAsync<List<WorkspaceDto>>(request);
			return response;
		}

		public async Task<IRestResponse<WorkspaceDto>> CreateWorkspace(WorkspaceRequest workspaceRequest) {
			var request = new RestRequest("workspaces", Method.POST);
			request.AddJsonBody(workspaceRequest);
			var response = await _client.ExecutePostTaskAsync<WorkspaceDto>(request);
			return response;
		}

		public async Task<IRestResponse> DeleteWorkspace(string id) {
			var request = new RestRequest($"workspaces/{id}", Method.DELETE);
			var response = await _client.ExecuteTaskAsync(request);
			return response;
		}
	}
}