using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Clockify.Net.Models;
using Clockify.Net.Models.Tasks;
using RestSharp;

namespace Clockify.Net; 

public partial class ClockifyClient
{
    /// <summary>
    /// Find tasks on project.
    /// </summary>
    public async Task<Response<List<TaskDto>>> FindAllTasksAsync(
        string workspaceId,
        string projectId,
        bool? isActive = null,
        string? name = null,
        int page = 1,
        int pageSize = 50)
    {
        var request = new RestRequest($"workspaces/{workspaceId}/projects/{projectId}/tasks");
        if (isActive != null) { request.AddQueryParameter("is-active", isActive.ToString()); }
        if (name != null) { request.AddQueryParameter(nameof(name), name); }

        request.AddQueryParameter(nameof(page), page.ToString());
        request.AddQueryParameter("page-size", pageSize.ToString());
        return Response<List<TaskDto>>.FromRestResponse(await _client.ExecuteGetAsync<List<TaskDto>>(request).ConfigureAwait(false));
    }

    /// <summary>
    /// Add a new client to workspace.
    /// </summary>
    public async Task<Response<TaskDto>> CreateTaskAsync(
        string workspaceId,
        string projectId,
        TaskRequest taskRequest)
    {
        if (taskRequest == null) { throw new ArgumentNullException(nameof(taskRequest)); }
        if (taskRequest.Name == null) throw new ArgumentNullException(nameof(taskRequest.Name));

        var request = new RestRequest($"workspaces/{workspaceId}/projects/{projectId}/tasks", Method.Post);
        request.AddJsonBody(taskRequest);
        return Response<TaskDto>.FromRestResponse(await _client.ExecutePostAsync<TaskDto>(request).ConfigureAwait(false));
    }

    /// <summary>
    /// Updates an existing task to workspace.
    /// </summary>
    public async Task<Response<TaskDto>> UpdateTaskAsync(
        string workspaceId,
        string projectId,
        TaskRequest taskRequest)
    {
        if (taskRequest == null) { throw new ArgumentNullException(nameof(taskRequest)); }
        if (taskRequest.Name == null) throw new ArgumentNullException(nameof(taskRequest.Name));
        if (taskRequest.Id == null) { throw new ArgumentNullException(nameof(taskRequest.Id)); }

        var request = new RestRequest($"workspaces/{workspaceId}/projects/{projectId}/tasks/{taskRequest.Id}", Method.Put);
        request.AddJsonBody(taskRequest);
        return Response<TaskDto>.FromRestResponse(await _client.ExecuteAsync<TaskDto>(request, Method.Put).ConfigureAwait(false));
    }

    /// <summary>
    /// Deletes an existing task from workspace.
    /// </summary>
    public async Task<Response<TaskDto>> DeleteTaskAsync(
        string workspaceId,
        string projectId,
        string taskId)
    {
        if (taskId == null) { throw new ArgumentNullException(nameof(taskId)); }

        var request = new RestRequest($"workspaces/{workspaceId}/projects/{projectId}/tasks/{taskId}", Method.Delete);
        return Response<TaskDto>.FromRestResponse(await _client.ExecuteAsync<TaskDto>(request, Method.Delete).ConfigureAwait(false));
    }
}