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
		private const string ExperimentalApiUrl = "https://api.clockify.me/api/";
		private const string ApiKeyHeaderName = "X-Api-Key";
		private const string ApiKeyVariableName = "CAPI_KEY";
		private IRestClient _client;
		private IRestClient _experimentalClient;

		public ClockifyClient(string apiKey) {
			InitClients(apiKey);
		}

		/// <summary>
		/// Creates new <see cref="ClockifyClient"/>.
		/// Uses value from environment variable named "CAPI_KEY"
		/// </summary>
		public ClockifyClient() {
			var apiKey = Environment.GetEnvironmentVariable(ApiKeyVariableName);
			if (apiKey == null) throw new ArgumentException($"Environment variable {ApiKeyVariableName} is not set.");
			InitClients(apiKey);
		}

		/// <summary>
		/// Find workspaces for currently logged in user
		/// </summary>
		public async Task<IRestResponse<List<WorkspaceDto>>> GetWorkspaces() {
			var request = new RestRequest("workspaces");
			var response = await _client.ExecuteGetTaskAsync<List<WorkspaceDto>>(request);
			return response;
		}

		/// <summary>
		/// Creates new workspace.
		/// </summary>
		public async Task<IRestResponse<WorkspaceDto>> CreateWorkspace(WorkspaceRequest workspaceRequest) {
			var request = new RestRequest("workspaces", Method.POST);
			request.AddJsonBody(workspaceRequest); 
			var response = await _client.ExecutePostTaskAsync<WorkspaceDto>(request);
			return response;
		}

		/// <summary>
		/// Delete workspace with Id.
		/// </summary>
		public async Task<IRestResponse> DeleteWorkspace(string id) {
			var request = new RestRequest($"workspaces/{id}", Method.DELETE);
			var response = await _experimentalClient.ExecuteTaskAsync(request);
			return response;
		}

		#region Private methods

		private void InitClients(string apiKey) {
			_client = new RestClient(BaseUrl);
			_client.AddDefaultHeader(ApiKeyHeaderName, apiKey);
			_experimentalClient = new RestClient(ExperimentalApiUrl);
			_experimentalClient.AddDefaultHeader(ApiKeyHeaderName, apiKey);
			SimpleJson.CurrentJsonSerializerStrategy = new CamelCaseSerializerStrategy();
		}

		#endregion
	}
}