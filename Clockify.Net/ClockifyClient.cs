using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Clockify.Net.Configuration;
using Clockify.Net.Models.Clients;
using Clockify.Net.Models.Projects;
using Clockify.Net.Models.Tags;
using Clockify.Net.Models.Templates;
using Clockify.Net.Models.Tasks;
using Clockify.Net.Models.TimeEntries;
using Clockify.Net.Models.Users;
using Clockify.Net.Models.Workspaces;
using RestSharp;
using RestSharp.Validation;

namespace Clockify.Net 
{
    public class ClockifyClient 
    {
		private const string BaseUrl = "https://api.clockify.me/api/v1";
		private const string ExperimentalApiUrl = "https://api.clockify.me/api/";
		private const string ApiKeyHeaderName = "X-Api-Key";
		private const string ApiKeyVariableName = "CAPI_KEY";
		private IRestClient _client;
		private IRestClient _experimentalClient;

		public ClockifyClient(string apiKey) 
        {
			InitClients(apiKey);
		}

		/// <summary>
		/// Creates new <see cref="ClockifyClient"/>.
		/// Uses value from environment variable named "CAPI_KEY"
		/// </summary>
		public ClockifyClient() 
        {
			var apiKey = Environment.GetEnvironmentVariable(ApiKeyVariableName);
			if (apiKey == null) { throw new ArgumentException($"Environment variable {ApiKeyVariableName} is not set."); }

			InitClients(apiKey);
		}

		#region Tasks

		/// <summary>
		/// Find tasks on project.
		/// </summary>
		public Task<IRestResponse<List<TaskDto>>> FindAllTasksAsync(
            string workspaceId, 
            string projectId,
			bool? isActive = null, 
            string name = null, 
            int page = 1, 
            int pageSize = 50) 
        {
			var request = new RestRequest($"workspaces/{workspaceId}/projects/{projectId}/tasks");
            if (isActive != null) { request.AddQueryParameter("is-active", isActive.ToString()); }
            if (name != null) { request.AddQueryParameter(nameof(name), name); }

			request.AddQueryParameter(nameof(page), page.ToString());
			request.AddQueryParameter("page-size", pageSize.ToString());
			return _client.ExecuteGetAsync<List<TaskDto>>(request);
		}

		/// <summary>
		/// Add a new client to workspace.
		/// </summary>
		public Task<IRestResponse<TaskDto>> CreateTaskAsync(
            string workspaceId, 
            string projectId,
			TaskRequest taskRequest) 
        {
            if (taskRequest == null) { throw new ArgumentNullException(nameof(taskRequest)); }
            if (taskRequest.Name == null) throw new ArgumentNullException(nameof(taskRequest.Name));

			var request = new RestRequest($"workspaces/{workspaceId}/projects/{projectId}/tasks", Method.POST);
			request.AddJsonBody(taskRequest);
			return _client.ExecutePostAsync<TaskDto>(request);
		}

		#endregion

		#region User

		/// <summary>
		/// Find all users on workspace
		/// </summary>
		public Task<IRestResponse<List<UserDto>>> FindAllUsersOnWorkspaceAsync(string workspaceId)
        {
			var request = new RestRequest($"workspaces/{workspaceId}/users");
			return _client.ExecuteGetAsync<List<UserDto>>(request);
		}

		/// <summary>
		/// Get currently logged in user's info
		/// </summary>
		public Task<IRestResponse<CurrentUserDto>> GetCurrentUserAsync() 
        {
			var request = new RestRequest("user");
			return _client.ExecuteGetAsync<CurrentUserDto>(request);
		}

		#endregion

		#region Workspace

		/// <summary>
		/// Find workspaces for currently logged in user
		/// </summary>
		public Task<IRestResponse<List<WorkspaceDto>>> GetWorkspacesAsync() 
        {
			var request = new RestRequest("workspaces");
			return _client.ExecuteGetAsync<List<WorkspaceDto>>(request);
		}

		/// <summary>
		/// Creates new workspace.
		/// </summary>
		public Task<IRestResponse<WorkspaceDto>> CreateWorkspaceAsync(WorkspaceRequest workspaceRequest) 
        {
			var request = new RestRequest("workspaces", Method.POST);
			request.AddJsonBody(workspaceRequest);
			return _client.ExecutePostAsync<WorkspaceDto>(request);
		}

		/// <summary>
		/// Delete workspace with Id.
		/// </summary>
		public Task<IRestResponse> DeleteWorkspaceAsync(string id) 
        {
			var request = new RestRequest($"workspaces/{id}");
			return _experimentalClient.ExecuteAsync(request, Method.DELETE);
		}

		#endregion

		#region Client

		/// <summary>
		/// Find clients on workspace
		/// </summary>
		public Task<IRestResponse<List<ClientDto>>> FindAllClientsOnWorkspaceAsync(string workspaceId) 
        {
			var request = new RestRequest($"workspaces/{workspaceId}/clients");
			return _client.ExecuteGetAsync<List<ClientDto>>(request);
		}

		/// <summary>
		/// Add a new client to workspace.
		/// </summary>
		public Task<IRestResponse<ClientDto>> CreateClientAsync(string workspaceId, ClientRequest clientRequest) 
        {
            if (clientRequest == null) { throw new ArgumentNullException(nameof(clientRequest)); }

			var request = new RestRequest($"workspaces/{workspaceId}/clients", Method.POST);
			request.AddJsonBody(clientRequest);
			return _client.ExecutePostAsync<ClientDto>(request);
		}

		#endregion

		#region Projects

		/// <summary>
		/// Find projects on workspace.
		/// </summary>
		public Task<IRestResponse<List<ProjectDtoImpl>>> FindAllProjectsOnWorkspaceAsync(string workspaceId) 
        {
			var request = new RestRequest($"workspaces/{workspaceId}/projects");
			return _client.ExecuteGetAsync<List<ProjectDtoImpl>>(request);
		}

		/// <summary>
		/// Add a new client to workspace.
		/// </summary>
		public Task<IRestResponse<ProjectDtoImpl>> CreateProjectAsync(string workspaceId, ProjectRequest projectRequest) 
		{
            if (projectRequest == null) { throw new ArgumentNullException(nameof(projectRequest)); }
            if (projectRequest.Name == null) throw new ArgumentNullException(nameof(projectRequest.Name));
            if (projectRequest.Color == null) throw new ArgumentNullException(nameof(projectRequest.Color));

			var request = new RestRequest($"workspaces/{workspaceId}/projects", Method.POST);
			request.AddJsonBody(projectRequest);
			return _client.ExecutePostAsync<ProjectDtoImpl>(request);
		}

		/// <summary>
		/// Delete project with Id.
		/// </summary>
		public Task<IRestResponse> DeleteProjectAsync(string workspaceId, string id) 
        {
			var request = new RestRequest($"workspaces/{workspaceId}/projects/{id}");
			return _experimentalClient.ExecuteAsync(request, Method.DELETE);
		}

		#endregion

		#region Tags

		/// <summary>
		/// Find tags on workspace.
		/// </summary>
		public Task<IRestResponse<List<TagDto>>> FindAllTagsOnWorkspaceAsync(string workspaceId) 
        {
			var request = new RestRequest($"workspaces/{workspaceId}/tags");
			return _client.ExecuteGetAsync<List<TagDto>>(request);
		}

		/// <summary>
		/// Add a new client to workspace.
		/// </summary>
		public Task<IRestResponse<TagDto>> CreateTagAsync(string workspaceId, TagRequest projectRequest) 
        {
            if (projectRequest == null) { throw new ArgumentNullException(nameof(projectRequest)); }
            if (projectRequest.Name == null) { throw new ArgumentNullException(nameof(projectRequest.Name)); }

			var request = new RestRequest($"workspaces/{workspaceId}/tags", Method.POST);
			request.AddJsonBody(projectRequest);
			return _client.ExecutePostAsync<TagDto>(request);
		}

		#endregion

		#region Timesheet templates

		/// <summary>
		/// Get templates for current user on specified workspace. See Clockify docs for query params explanation.
		/// </summary>
		public Task<IRestResponse<List<TemplateDto>>> FindAllTemplatesOnWorkspaceAsync(
            string workspaceId,
			string name = null, 
            bool cleansed = false, 
            bool hydrated = false, 
            int page = 1, 
            int pageSize = 1) 
        {
			var request = new RestRequest($"workspaces/{workspaceId}/templates");

            if (name != null) { request.AddQueryParameter(nameof(name), name); }
			request.AddQueryParameter(nameof(cleansed), cleansed.ToString());
			request.AddQueryParameter(nameof(hydrated), hydrated.ToString());
			request.AddQueryParameter(nameof(page), page.ToString());
			request.AddQueryParameter("page-size", pageSize.ToString());

			return _client.ExecuteGetAsync<List<TemplateDto>>(request);
		}

		/// <summary>
		/// Get template from workspace. See Clockify docs for query params explanation.
		/// </summary>
		public Task<IRestResponse<TemplateDto>> GetTemplateAsync(
            string workspaceId, 
            string templateId,
			bool cleansed = false, 
            bool hydrated = false) 
        {
			var request = new RestRequest($"workspaces/{workspaceId}/templates/{templateId}");
			request.AddQueryParameter(nameof(cleansed), cleansed.ToString());
			request.AddQueryParameter(nameof(hydrated), hydrated.ToString());
			return _client.ExecuteGetAsync<TemplateDto>(request);
		}

		/// <summary>
		/// Save templates to workspace.
		/// </summary>
		public Task<IRestResponse<List<TemplateDto>>> CreateTemplatesAsync(string workspaceId, params TemplateRequest[] projectRequests) 
        {
            if (projectRequests == null) { throw new ArgumentNullException(nameof(projectRequests)); }

			// todo: this nested foreach needs work
			foreach (var templateRequest in projectRequests) 
            {
	            if (templateRequest.Name == null) { throw new ArgumentNullException(nameof(templateRequest.Name)); }
	            if (templateRequest.ProjectsAndTasks == null) { throw new ArgumentNullException(nameof(templateRequest.ProjectsAndTasks)); }

				foreach (var projectsAndTask in templateRequest.ProjectsAndTasks) 
                {
		            if (projectsAndTask.ProjectId == null) { throw new ArgumentNullException(nameof(projectsAndTask.ProjectId)); }
		            if (projectsAndTask.TaskId == null) { throw new ArgumentNullException(nameof(projectsAndTask.TaskId)); }
				}
			}

			var request = new RestRequest($"workspaces/{workspaceId}/templates", Method.POST);
			request.AddJsonBody(projectRequests);
			return _client.ExecutePostAsync<List<TemplateDto>>(request);
		}

		/// <summary>
		/// Delete template with id.
		/// </summary>
		public Task<IRestResponse<TemplateDto>> DeleteTemplateAsync(string workspaceId, string templateId) 
        {
			var request = new RestRequest($"workspaces/{workspaceId}/templates/{templateId}", Method.DELETE);
			return _client.ExecuteAsync<TemplateDto>(request);
		}

		/// <summary>
		/// Updates template with id.
		/// </summary>
		public Task<IRestResponse<TemplateDto>> UpdateTemplateAsync(
            string workspaceId, 
            string timeEntryId,
			TemplatePatchRequest templatePatchRequest) 
        {
            if (templatePatchRequest == null) { throw new ArgumentNullException(nameof(templatePatchRequest)); }
            if (templatePatchRequest.Name == null) { throw new ArgumentNullException(nameof(templatePatchRequest.Name)); }

			var request = new RestRequest($"workspaces/{workspaceId}/templates/{timeEntryId}", Method.PATCH);
			request.AddJsonBody(templatePatchRequest);
			return _client.ExecuteAsync<TemplateDto>(request);
		}

		#endregion

		#region Time entry

		/// <summary>
		/// Add a new time entry to workspace. If end is not sent in request means that stopwatch mode is active, otherwise time entry is manually added.
		/// </summary>
		public Task<IRestResponse<TimeEntryDtoImpl>> CreateTimeEntryAsync(string workspaceId, TimeEntryRequest timeEntryRequest) 
        {
            if (timeEntryRequest == null) { throw new ArgumentNullException(nameof(timeEntryRequest)); }
            if (timeEntryRequest.Start == null) { throw new ArgumentNullException(nameof(timeEntryRequest.Start)); }

			var request = new RestRequest($"workspaces/{workspaceId}/time-entries", Method.POST);
			request.AddJsonBody(timeEntryRequest);
			return _client.ExecutePostAsync<TimeEntryDtoImpl>(request);
		}
		
		/// <summary>
		/// Get time entry from. workspace. See Clockify docs for query params explanation.
		/// </summary>
		public Task<IRestResponse<TimeEntryDtoImpl>> GetTimeEntryAsync(
            string workspaceId, 
            string timeEntryId,
			bool considerDurationFormat = false, 
            bool hydrated = false) 
        {
			var request = new RestRequest($"workspaces/{workspaceId}/time-entries/{timeEntryId}");
			request.AddQueryParameter("consider-duration-format", considerDurationFormat.ToString());
			request.AddQueryParameter(nameof(hydrated), hydrated.ToString());
			return _client.ExecuteGetAsync<TimeEntryDtoImpl>(request);
		}

		/// <summary>
		/// Update time entry with id.
		/// </summary>
		public Task<IRestResponse<TimeEntryDtoImpl>> UpdateTimeEntryAsync(string workspaceId, string timeEntryId, UpdateTimeEntryRequest updateTimeEntryRequest) 
        {
            if (updateTimeEntryRequest == null) { throw new ArgumentNullException(nameof(updateTimeEntryRequest)); }
            if (updateTimeEntryRequest.Start == null) { throw new ArgumentNullException(nameof(updateTimeEntryRequest.Start)); }
            if (updateTimeEntryRequest.Billable == null) { throw new ArgumentNullException(nameof(updateTimeEntryRequest.Billable)); }

			var request = new RestRequest($"workspaces/{workspaceId}/time-entries/{timeEntryId}", Method.PUT);
			request.AddJsonBody(updateTimeEntryRequest);
			return _client.ExecuteAsync<TimeEntryDtoImpl>(request);
		}

		/// <summary>
		/// Delete time entry with id.
		/// </summary>
		public Task<IRestResponse> DeleteTimeEntryAsync(string workspaceId, string templateId) 
        {
			var request = new RestRequest($"workspaces/{workspaceId}/time-entries/{templateId}");
			return _client.ExecuteAsync(request, Method.DELETE);
		}

		/// <summary>
		/// Get templates for current user on specified workspace. See Clockify docs for query params explanation.
		/// </summary>
		public Task<IRestResponse<List<TimeEntryDtoImpl>>> FindAllTimeEntriesForUserAsync(
            string workspaceId, 
            string userId,
			string description = null, 
            DateTimeOffset? start = null, 
            DateTimeOffset? end = null, 
            string project = null,
			string task = null, 
            bool? projectRequired = null, 
            bool? taskRequired = null,
			bool? considerDurationFormat = null, 
            bool? hydrated = null, 
            bool? inProgress = null,
			int page = 1, 
            int pageSize = 50) 
        {
			var request = new RestRequest($"workspaces/{workspaceId}/user/{userId}/time-entries");

            if (description != null) { request.AddQueryParameter(nameof(description), description); }
            if (start != null) { request.AddQueryParameter(nameof(start), start.ToString()); }
			if (end != null) { request.AddQueryParameter(nameof(end), end.ToString()); }
            if (project != null) { request.AddQueryParameter(nameof(project), project); }
            if (task != null) { request.AddQueryParameter(nameof(task), task); }
            if (projectRequired != null) { request.AddQueryParameter("consider-duration-format", considerDurationFormat.ToString()); }
            if (taskRequired != null) { request.AddQueryParameter("task-required", taskRequired.ToString()); }
            if (projectRequired != null) { request.AddQueryParameter("project-required", projectRequired.ToString()); }
            if (hydrated != null) { request.AddQueryParameter(nameof(hydrated), hydrated.ToString()); }
            if (inProgress != null) { request.AddQueryParameter("in-progress", inProgress.ToString()); }

			request.AddQueryParameter(nameof(page), page.ToString());
			request.AddQueryParameter("page-size", pageSize.ToString());

			return _client.ExecuteGetAsync<List<TimeEntryDtoImpl>>(request);
		}

		#endregion
		
		#region Private methods

		private void InitClients(string apiKey) 
        {
			_client = new RestClient(BaseUrl);
			_client.AddDefaultHeader(ApiKeyHeaderName, apiKey);
			_experimentalClient = new RestClient(ExperimentalApiUrl);
			_experimentalClient.AddDefaultHeader(ApiKeyHeaderName, apiKey);
			SimpleJson.CurrentJsonSerializerStrategy = new CamelCaseSerializerStrategy();
		}

		#endregion
	}
}