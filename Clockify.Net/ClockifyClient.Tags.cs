using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Clockify.Net.Models;
using Clockify.Net.Models.Tags;
using RestSharp;

namespace Clockify.Net
{
    public partial class ClockifyClient
    {
        /// <summary>
        /// Find tags on workspace.
        /// </summary>
        public async Task<Response<List<TagDto>>> FindAllTagsOnWorkspaceAsync(string workspaceId)
        {
            var request = new RestRequest($"workspaces/{workspaceId}/tags");
            return Response<List<TagDto>>.FromRestResponse(await _client.ExecuteGetAsync<List<TagDto>>(request).ConfigureAwait(false));
        }

        /// <summary>
        /// Add a new tag to workspace.
        /// </summary>
        public async Task<Response<TagDto>> CreateTagAsync(string workspaceId, TagRequest projectRequest)
        {
            if (projectRequest == null) { throw new ArgumentNullException(nameof(projectRequest)); }
            if (projectRequest.Name == null) { throw new ArgumentNullException(nameof(projectRequest.Name)); }

            var request = new RestRequest($"workspaces/{workspaceId}/tags", Method.Post);
            request.AddJsonBody(projectRequest);
            return Response<TagDto>.FromRestResponse(await _client.ExecutePostAsync<TagDto>(request).ConfigureAwait(false));
        }

        
        /// <summary>
        /// Delete tag from workspace.
        /// </summary>
        /// <param name="workspaceId"></param>
        /// <param name="tagId"></param>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Response> DeleteTagAsync(string workspaceId, string tagId) {
            var request = new RestRequest($"workspaces/{workspaceId}/tags/{tagId}", Method.Delete);
            return Response.FromRestResponse(await _client.DeleteAsync(request).ConfigureAwait(false));
        }
    }
}
