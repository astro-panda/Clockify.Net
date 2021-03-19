using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Clockify.Net.Models.Tasks;
using RestSharp;

namespace Clockify.Net
{
    public partial class ClockifyClient
    {
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
    }
}
