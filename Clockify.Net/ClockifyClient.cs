using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Clockify.Net.Models.Clients;
using Clockify.Net.Models.Estimates;
using Clockify.Net.Models.Projects;
using Clockify.Net.Models.Tags;
using Clockify.Net.Models.Templates;
using Clockify.Net.Models.Tasks;
using Clockify.Net.Models.TimeEntries;
using Clockify.Net.Models.Users;
using Clockify.Net.Models.Workspaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

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

        /// <summary>
        /// Updates an existing task to workspace.
        /// </summary>
        public Task<IRestResponse<TaskDto>> UpdateTaskAsync(
            string workspaceId,
            string projectId,
            TaskRequest taskRequest)
        {
            if (taskRequest == null) { throw new ArgumentNullException(nameof(taskRequest)); }
            if (taskRequest.Name == null) throw new ArgumentNullException(nameof(taskRequest.Name));
            if (taskRequest.Id == null) { throw new ArgumentNullException(nameof(taskRequest.Id)); }

            var request = new RestRequest($"workspaces/{workspaceId}/projects/{projectId}/tasks/{taskRequest.Id}", Method.PUT);
            request.AddJsonBody(taskRequest);
            return _client.ExecuteAsync<TaskDto>(request, Method.PUT);
        }

        /// <summary>
        /// Deletes an existing task from workspace.
        /// </summary>
        public Task<IRestResponse<TaskDto>> DeleteTaskAsync(
            string workspaceId,
            string projectId,
            string taskId)
        {
            if (taskId == null) { throw new ArgumentNullException(nameof(taskId)); }

            var request = new RestRequest($"workspaces/{workspaceId}/projects/{projectId}/tasks/{taskId}", Method.DELETE);
            return _client.ExecuteAsync<TaskDto>(request, Method.DELETE);
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

        /// <summary>
        /// Set active workspace for user
        /// </summary>
        [Obsolete("Removed from the experimental API")]
        public Task<IRestResponse<UserDto>> SetActiveWorkspaceFor(string userId, string workspaceId)
        {
            var request = new RestRequest($"users/{userId}/activeWorkspace/{workspaceId}");
            return _experimentalClient.ExecutePostAsync<UserDto>(request);
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
        [Obsolete("Changing active workplace was removed from the experimental API")]
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
        /// Find projects on workspace. See Clockify docs for query params explanation.
        /// </summary>
        public Task<IRestResponse<List<ProjectDtoImpl>>> FindAllProjectsOnWorkspaceAsync(string workspaceId,
            bool? archived = null,
            string name = null,
            bool? billable = null,
            string[] clients = null,
            bool? containsClient = null,
            string clientStatus = null,
            string[] users = null,
            bool? containsUsers = null,
            string userStatus = null,
            bool? isTemplate = null,
            string sortColumn = null,
            string sortOrder = null,
            int page = 1,
            int pageSize = 50)
        {
            var request = new RestRequest($"workspaces/{workspaceId}/projects");
            if (archived != null) { request.AddQueryParameter(nameof(archived), archived.ToString()); }
            if (name != null) { request.AddQueryParameter(nameof(name), name); }
            if (billable != null) { request.AddQueryParameter(nameof(billable), billable.ToString()); }
            if (clients != null && clients.Length > 0)
            {
                request.AddQueryParameter(nameof(clients), string.Join(",", clients));
            }
            if (containsClient != null) { request.AddQueryParameter("contains-client", containsClient.ToString()); }
            if (!string.IsNullOrEmpty(clientStatus)) { request.AddQueryParameter("client-status", clientStatus); }
            if (users != null && users.Length > 0)
            {
                request.AddQueryParameter(nameof(users), string.Join(",", users));
            }
            if (containsUsers != null) { request.AddQueryParameter("contains-users", containsUsers.ToString()); }
            if (!string.IsNullOrEmpty(userStatus)) { request.AddQueryParameter("user-status", userStatus); }
            if (isTemplate != null) { request.AddQueryParameter("is-template", isTemplate.ToString()); }
            if (!string.IsNullOrEmpty(sortColumn)) { request.AddQueryParameter("sort-column", sortColumn); }
            if (!string.IsNullOrEmpty(sortOrder)) { request.AddQueryParameter("sort-order", sortOrder); }

            request.AddQueryParameter(nameof(page), page.ToString());
            request.AddQueryParameter("page-size", pageSize.ToString());

            return _client.ExecuteGetAsync<List<ProjectDtoImpl>>(request);
        }

        /// <summary>
        /// Add a new project to workspace.
        /// </summary>
        public Task<IRestResponse<ProjectDtoImpl>> CreateProjectAsync(string workspaceId, ProjectRequest projectRequest)
        {
            if (projectRequest == null) { throw new ArgumentNullException(nameof(projectRequest)); }
            if (projectRequest.Name == null) throw new ArgumentNullException(nameof(projectRequest.Name));
            if (projectRequest.Color == null) throw new ArgumentNullException(nameof(projectRequest.Color));
            if (projectRequest.Estimate != null && (projectRequest.Estimate.Type == null || !Enum.IsDefined(typeof(EstimateType), projectRequest.Estimate.Type)))
                throw new ArgumentOutOfRangeException(nameof(projectRequest.Estimate.Type));

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

		/// <summary>
		/// Find project with Id.
		/// </summary>
		public Task<IRestResponse> FindProjectByIdAsync(string workspaceId, string id)
        {
			var request = new RestRequest($"workspaces/{workspaceId}/projects/{id}");
			return _experimentalClient.ExecuteAsync(request, Method.GET);
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
        /// Add a new time entry to workspace for another user. If end is not sent in request means that stopwatch mode is active, otherwise time entry is manually added.
        /// </summary>
        public Task<IRestResponse<TimeEntryDtoImpl>> CreateTimeEntryForAnotherUserAsync(string workspaceId, string userId, TimeEntryRequest timeEntryRequest)
        {
            if (timeEntryRequest == null) { throw new ArgumentNullException(nameof(timeEntryRequest)); }
            if (timeEntryRequest.Start == null) { throw new ArgumentNullException(nameof(timeEntryRequest.Start)); }
            if (timeEntryRequest.UserId == null) { throw new ArgumentNullException(nameof(timeEntryRequest.UserId)); }

            var request = new RestRequest($"workspaces/{workspaceId}/user/{userId}/time-entries", Method.POST);
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
        public Task<IRestResponse> DeleteTimeEntryAsync(string workspaceId, string timeEntryId)
        {
            var request = new RestRequest($"workspaces/{workspaceId}/time-entries/{timeEntryId}");
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
            if (start != null) { request.AddQueryParameter(nameof(start), start.Value.ToString("yyyy-MM-ddTHH:mm:ssZ")); }
            if (end != null) { request.AddQueryParameter(nameof(end), end.Value.ToString("yyyy-MM-ddTHH:mm:ssZ")); }
            if (project != null) { request.AddQueryParameter(nameof(project), project); }
            if (task != null) { request.AddQueryParameter(nameof(task), task); }
            if (projectRequired != null) { request.AddQueryParameter("project-required", projectRequired.ToString()); }
            if (taskRequired != null) { request.AddQueryParameter("task-required", taskRequired.ToString()); }
            if (considerDurationFormat != null) { request.AddQueryParameter("consider-duration-format", considerDurationFormat.ToString()); }
            if (hydrated != null) { request.AddQueryParameter(nameof(hydrated), hydrated.ToString()); }
            if (inProgress != null) { request.AddQueryParameter("in-progress", inProgress.ToString()); }

            request.AddQueryParameter(nameof(page), page.ToString());
            request.AddQueryParameter("page-size", pageSize.ToString());

            return _client.ExecuteGetAsync<List<TimeEntryDtoImpl>>(request);
        }

        /// <summary>
        /// Get hydrated time entries for current user on specified workspace. See Clockify docs for query params explanation.
        /// </summary>
        public Task<IRestResponse<List<HydratedTimeEntryDtoImpl>>> FindAllHydratedTimeEntriesForUserAsync(
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
            bool? inProgress = null,
            int page = 1,
            int pageSize = 50)
        {
            var request = new RestRequest($"workspaces/{workspaceId}/user/{userId}/time-entries");
            const bool hydrated = true;

            if (description != null) { request.AddQueryParameter(nameof(description), description); }
            if (start != null) { request.AddQueryParameter(nameof(start), start.Value.ToString("yyyy-MM-ddTHH:mm:ssZ")); }
            if (end != null) { request.AddQueryParameter(nameof(end), end.Value.ToString("yyyy-MM-ddTHH:mm:ssZ")); }
            if (project != null) { request.AddQueryParameter(nameof(project), project); }
            if (task != null) { request.AddQueryParameter(nameof(task), task); }
            if (projectRequired != null) { request.AddQueryParameter("project-required", projectRequired.ToString()); }
            if (taskRequired != null) { request.AddQueryParameter("task-required", taskRequired.ToString()); }
            if (considerDurationFormat != null) { request.AddQueryParameter("consider-duration-format", considerDurationFormat.ToString()); }
            if (inProgress != null) { request.AddQueryParameter("in-progress", inProgress.ToString()); }

            request.AddQueryParameter(nameof(hydrated), hydrated.ToString());
            request.AddQueryParameter(nameof(page), page.ToString());
            request.AddQueryParameter("page-size", pageSize.ToString());

            return _client.ExecuteGetAsync<List<HydratedTimeEntryDtoImpl>>(request);
        }

        /// <summary>
        /// Get all time entries for a project.
        /// </summary>
        public async Task<IRestResponse<IEnumerable<TimeEntryDtoImpl>>> FindAllTimeEntriesForProjectAsync(
            string workspaceId,
            string projectId,
            string description = null,
            DateTimeOffset? start = null,
            DateTimeOffset? end = null,
            string task = null,
            bool? projectRequired = null,
            bool? taskRequired = null,
            bool? considerDurationFormat = null,
            bool? hydrated = null,
            bool? inProgress = null,
            int page = 1,
            int pageSize = 50)
        {
            // Find project
            var requestProject = new RestRequest($"workspaces/{workspaceId}/projects/{projectId}");
            var projectResponse = await _experimentalClient.ExecuteAsync(requestProject, Method.GET);

            var project = JsonConvert.DeserializeObject<ProjectDtoImpl>(projectResponse.Content);

            // All the time entries in the project
            List<TimeEntryDtoImpl> timeEntriesProject = new List<TimeEntryDtoImpl>();

            foreach (var member in project.Memberships)
            {
                var responseTimeEntriesMember = await FindAllTimeEntriesForUserAsync(workspaceId, member.UserId,description,start,end,project.Id,task,projectRequired,taskRequired,considerDurationFormat,hydrated,inProgress,page,pageSize );

                if (responseTimeEntriesMember.IsSuccessful && responseTimeEntriesMember.Data != null)
                    timeEntriesProject.AddRange(responseTimeEntriesMember.Data);
            }
            
            IRestResponse<IEnumerable<TimeEntryDtoImpl>> response = new RestResponse<IEnumerable<TimeEntryDtoImpl>>()
            {
                Data = timeEntriesProject,
            };

            return response;
        }


        #endregion

        #region Private methods

        private void InitClients(string apiKey)
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

            _client = new RestClient(BaseUrl);
            _client.AddDefaultHeader(ApiKeyHeaderName, apiKey);
            _client.UseNewtonsoftJson(jsonSerializerSettings);

            _experimentalClient = new RestClient(ExperimentalApiUrl);
            _experimentalClient.AddDefaultHeader(ApiKeyHeaderName, apiKey);
            _client.UseNewtonsoftJson(jsonSerializerSettings);
        }

        #endregion
    }
}
