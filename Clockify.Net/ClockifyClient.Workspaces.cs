using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Clockify.Net.Models;
using Clockify.Net.Models.Workspaces;
using RestSharp;

namespace Clockify.Net
{
    public partial class ClockifyClient
    {
        /// <summary>
        /// Find workspaces for currently logged in user
        /// </summary>
        public async Task<Response<List<WorkspaceDto>>> GetWorkspacesAsync()
        {
            var request = new RestRequest("workspaces");
            return Response<List<WorkspaceDto>>.FromRestResponse(await _client.ExecuteGetAsync<List<WorkspaceDto>>(request).ConfigureAwait(false));
        }

        /// <summary>
        /// Creates new workspace.
        /// </summary>
        public async Task<Response<WorkspaceDto>> CreateWorkspaceAsync(WorkspaceRequest workspaceRequest)
        {
            var request = new RestRequest("workspaces", Method.Post);
            request.AddJsonBody(workspaceRequest);
            return Response<WorkspaceDto>.FromRestResponse(await _client.ExecutePostAsync<WorkspaceDto>(request).ConfigureAwait(false));
        }

        /// <summary>
        /// Delete workspace with Id.
        /// </summary>
        [Obsolete("Changing active workplace was removed from the experimental API")]
        public async Task<Response> DeleteWorkspaceAsync(string id)
        {
            var request = new RestRequest($"workspaces/{id}");
            return Response.FromRestResponse(await _experimentalClient.ExecuteAsync(request, Method.Delete).ConfigureAwait(false));
        }

        /// <summary>
        /// Adds a user to workspace.
        /// </summary>
        public async Task<Response<List<WorkspaceDto>>> AddWorkspaceUser(string workspaceId, WorkspaceAddUserRequest requestBody)
        {
            var request = new RestRequest($"/workspaces/{workspaceId}/users");
            request.AddJsonBody(requestBody);

            return Response<List<WorkspaceDto>>.FromRestResponse(await _client.ExecuteAsync<List<WorkspaceDto>>(request, Method.Post).ConfigureAwait(false));
        }
    }
}
