using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Clockify.Net.Configuration;
using Clockify.Net.Models.Clients;
using Clockify.Net.Models.Projects;
using Clockify.Net.Models.Tags;
using Clockify.Net.Models.Users;
using Clockify.Net.Models.Workspaces;
using RestSharp;
using RestSharp.Validation;

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

		#region User

		/// <summary>
		/// Find all users on workspace
		/// </summary>
		public Task<IRestResponse<List<UserDto>>> FindAllUsersOnWorkspaceAsync(string workspaceId) {
			var request = new RestRequest($"workspaces/{workspaceId}/users");
			return _client.ExecuteGetTaskAsync<List<UserDto>>(request);
		}

		/// <summary>
		/// Get currently logged in user's info
		/// </summary>
		public Task<IRestResponse<CurrentUserDto>> GetCurrentUserAsync() {
			var request = new RestRequest("user");
			return _client.ExecuteGetTaskAsync<CurrentUserDto>(request);
		}

		#endregion

		#region Workspace

		/// <summary>
		/// Find workspaces for currently logged in user
		/// </summary>
		public Task<IRestResponse<List<WorkspaceDto>>> GetWorkspacesAsync() {
			var request = new RestRequest("workspaces");
			return _client.ExecuteGetTaskAsync<List<WorkspaceDto>>(request);
		}


		/// <summary>
		/// Creates new workspace.
		/// </summary>
		public Task<IRestResponse<WorkspaceDto>> CreateWorkspaceAsync(WorkspaceRequest workspaceRequest) {
			var request = new RestRequest("workspaces", Method.POST);
			request.AddJsonBody(workspaceRequest);
			return _client.ExecutePostTaskAsync<WorkspaceDto>(request);
		}

		/// <summary>
		/// Delete workspace with Id.
		/// </summary>
		public Task<IRestResponse> DeleteWorkspaceAsync(string id) {
			var request = new RestRequest($"workspaces/{id}", Method.DELETE);
			return _experimentalClient.ExecuteTaskAsync(request);
		}

		#endregion

		#region Client

		/// <summary>
		/// Find clients on workspace
		/// </summary>
		public Task<IRestResponse<List<ClientDto>>> FindAllClientsOnWorkspaceAsync(string workspaceId) {
			var request = new RestRequest($"workspaces/{workspaceId}/clients");
			return _client.ExecuteGetTaskAsync<List<ClientDto>>(request);
		}

		/// <summary>
		/// Add a new client to workspace.
		/// </summary>
		public Task<IRestResponse<ClientDto>> CreateClientAsync(string workspaceId, ClientRequest clientRequest) {
			if (clientRequest == null) throw new ArgumentNullException(nameof(clientRequest));
			var request = new RestRequest($"workspaces/{workspaceId}/clients", Method.POST);
			request.AddJsonBody(clientRequest);
			return _client.ExecutePostTaskAsync<ClientDto>(request);
		}

		#endregion

		#region Projects

		/// <summary>
		/// Find projects on workspace.
		/// </summary>
		public Task<IRestResponse<List<ProjectDtoImpl>>> FindAllProjectsOnWorkspaceAsync(string workspaceId) {
			var request = new RestRequest($"workspaces/{workspaceId}/projects");
			return _client.ExecuteGetTaskAsync<List<ProjectDtoImpl>>(request);
		}

		/// <summary>
		/// Add a new client to workspace.
		/// </summary>
		public Task<IRestResponse<ProjectDtoImpl>> CreateProjectAsync(string workspaceId, ProjectRequest projectRequest) {
			if (projectRequest == null) throw new ArgumentNullException(nameof(projectRequest));
			Require.Argument(nameof(projectRequest.Name), projectRequest.Name);
			Require.Argument(nameof(projectRequest.Color), projectRequest.Color);
			var request = new RestRequest($"workspaces/{workspaceId}/projects", Method.POST);
			request.AddJsonBody(projectRequest);
			return _client.ExecutePostTaskAsync<ProjectDtoImpl>(request);
		}

		/// <summary>
		/// Delete project with Id.
		/// </summary>
		public Task<IRestResponse> DeleteProjectAsync(string workspaceId, string id) {
			var request = new RestRequest($"workspaces/{workspaceId}/projects/{id}", Method.DELETE);
			return _experimentalClient.ExecuteTaskAsync(request);
		}

		#endregion

		#region Tags


		/// <summary>
		/// Find tags on workspace.
		/// </summary>
		public Task<IRestResponse<List<TagDto>>> FindAllTagsOnWorkspaceAsync(string workspaceId) {
			var request = new RestRequest($"workspaces/{workspaceId}/tags");
			return _client.ExecuteGetTaskAsync<List<TagDto>>(request);
		}

		/// <summary>
		/// Add a new client to workspace.
		/// </summary>
		public Task<IRestResponse<TagDto>> CreateTagAsync(string workspaceId, TagRequest projectRequest) {
			if (projectRequest == null) throw new ArgumentNullException(nameof(projectRequest));
			Require.Argument(nameof(projectRequest.Name), projectRequest.Name);
			var request = new RestRequest($"workspaces/{workspaceId}/tags", Method.POST);
			request.AddJsonBody(projectRequest);
			return _client.ExecutePostTaskAsync<TagDto>(request);
		}

		#endregion

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