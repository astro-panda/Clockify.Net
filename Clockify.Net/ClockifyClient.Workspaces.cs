using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Clockify.Net.Models.Workspaces;
using RestSharp;

namespace Clockify.Net
{
    public partial class ClockifyClient
    {
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

        /// <summary>
        /// Adds a user to workspace.
        /// </summary>
        public Task<IRestResponse<List<WorkspaceDto>>> AddWorkspaceUser(string workspaceId, WorkspaceAddUserRequest requestBody)
        {
            var request = new RestRequest($"/workspaces/{workspaceId}/users");
            request.AddJsonBody(requestBody);

            return _client.ExecuteAsync<List<WorkspaceDto>>(request, Method.POST);
        }
    }
}
