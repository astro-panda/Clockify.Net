using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Clockify.Net.Configuration;
using Clockify.Net.Models.Clients;
using Clockify.Net.Models.Projects;
using Clockify.Net.Models.Tags;
using Clockify.Net.Models.Templates;
using Clockify.Net.Models.Tasks;
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

		#region Tasks

		/// <summary>
		/// Find tasks on project.
		/// </summary>
		public Task<IRestResponse<List<TaskDto>>> FindAllTasksAsync(string workspaceId, string projectId,
			bool? isActive = null, string name = null, int page = 1, int pageSize = 50) {
			var request = new RestRequest($"workspaces/{workspaceId}/projects/{projectId}/tasks");
			request.AddQueryParameter("is-active", isActive.ToString());
			request.AddQueryParameter(nameof(name), name);
			request.AddQueryParameter(nameof(page), page.ToString());
			request.AddQueryParameter("page-size", pageSize.ToString());
			return _client.ExecuteGetTaskAsync<List<TaskDto>>(request);
		}

		/// <summary>
		/// Add a new client to workspace.
		/// </summary>
		public Task<IRestResponse<TaskDto>> CreateTaskAsync(string workspaceId, string projectId, TaskRequest taskRequest) {
			if (taskRequest == null) throw new ArgumentNullException(nameof(taskRequest));
			Require.Argument(nameof(taskRequest.Name), taskRequest.Name);
			var request = new RestRequest($"workspaces/{workspaceId}/projects/{projectId}/tasks", Method.POST);
			request.AddJsonBody(taskRequest);
			return _client.ExecutePostTaskAsync<TaskDto>(request);
		}

		#endregion

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
		public Task<IRestResponse<ProjectDtoImpl>>
			CreateProjectAsync(string workspaceId, ProjectRequest projectRequest) {
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

		#region Timesheet templates

		/// <summary>
		/// Get templates for current user on specified workspace. See Clockify docs for query params explanation.
		/// </summary>
		public Task<IRestResponse<List<TemplateDto>>> FindAllTemplatesOnWorkspaceAsync(string workspaceId,
			string name = "", bool cleansed = false, bool hydrated = false, int page = 1, int pageSize = 1) {
			var request = new RestRequest($"workspaces/{workspaceId}/templates");
			request.AddQueryParameter(nameof(name), name);
			request.AddQueryParameter(nameof(cleansed), cleansed.ToString());
			request.AddQueryParameter(nameof(hydrated), hydrated.ToString());
			request.AddQueryParameter(nameof(page), page.ToString());
			request.AddQueryParameter("page-size", pageSize.ToString());
			return _client.ExecuteGetTaskAsync<List<TemplateDto>>(request);
		}

		/// <summary>
		/// Get template from workspace. See Clockify docs for query params explanation.
		/// </summary>
		public Task<IRestResponse<TemplateDto>> GetTemplatesOnWorkspaceAsync(string workspaceId, string templateId, bool cleansed = false, bool hydrated = false) {
			var request = new RestRequest($"workspaces/{workspaceId}/templates/{templateId}");
			request.AddQueryParameter(nameof(cleansed), cleansed.ToString());
			request.AddQueryParameter(nameof(hydrated), hydrated.ToString());
			return _client.ExecuteGetTaskAsync<TemplateDto>(request);
		}

		/// <summary>
		/// Save templates to workspace.
		/// </summary>
		public Task<IRestResponse<List<TemplateDto>>> CreateTemplatesAsync(string workspaceId, params TemplateRequest[] projectRequests) {
			if (projectRequests == null) throw new ArgumentNullException(nameof(projectRequests));
			foreach (var templateRequest in projectRequests) {
				Require.Argument(nameof(templateRequest.Name), templateRequest.Name);
				Require.Argument(nameof(templateRequest.ProjectsAndTasks), templateRequest.ProjectsAndTasks);
				foreach (var projectsAndTask in templateRequest.ProjectsAndTasks) {
					Require.Argument(nameof(projectsAndTask.ProjectId), projectsAndTask.ProjectId);
					Require.Argument(nameof(projectsAndTask.TaskId), projectsAndTask.TaskId);
				}
			}
			var request = new RestRequest($"workspaces/{workspaceId}/templates", Method.POST);
			request.AddJsonBody(projectRequests);
			return _client.ExecutePostTaskAsync<List<TemplateDto>>(request);
		}

		/// <summary>
		/// Delete template with id.
		/// </summary>
		public Task<IRestResponse<TemplateDto>> DeleteTemplateAsync(string workspaceId, string templateId) {
			var request = new RestRequest($"workspaces/{workspaceId}/templates/{templateId}", Method.DELETE);
			return _client.ExecuteTaskAsync<TemplateDto>(request);
		}

		/// <summary>
		/// Delete template with id.
		/// </summary>
		public Task<IRestResponse<TemplateDto>> UpdateTemplateAsync(string workspaceId, string templateId, TemplatePatchRequest templatePatchRequest) {
			if (templatePatchRequest == null) throw new ArgumentNullException(nameof(templatePatchRequest));
			Require.Argument(nameof(templatePatchRequest.Name), templatePatchRequest.Name);
			var request = new RestRequest($"workspaces/{workspaceId}/templates/{templateId}", Method.PATCH);
			request.AddJsonBody(templatePatchRequest);
			return _client.ExecuteTaskAsync<TemplateDto>(request);
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