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
        /// Update tag.
        /// </summary>
        public async Task<Response<TagDto>> UpdateTagAsync(string workspaceId, string? tagId, TagUpdateRequest updateRequest)
        {
            var request = new RestRequest($"workspaces/{workspaceId}/tags/{tagId}", Method.Put);
            request.AddJsonBody(updateRequest);
            var response = await _client.ExecuteAsync<TagDto>(request).ConfigureAwait(false);
            return Response<TagDto>.FromRestResponse(response);
        }
        
        /// <summary>
        /// Delete tag from workspace.
        /// </summary>
        public async Task<Response<TagDto>> DeleteTagAsync(string workspaceId, string tagId) {
            var request = new RestRequest($"workspaces/{workspaceId}/tags/{tagId}", Method.Delete);
            var response = await _client.ExecuteAsync<TagDto>(request).ConfigureAwait(false);
            return Response<TagDto>.FromRestResponse(response);
        }

        public async Task<Response<TagDto>> ArchiveAndDeleteTagAsync(string workspaceId, string tagId) {
            var updateRequest = new TagUpdateRequest() {Archived = true, Name = Guid.NewGuid().ToString()};
            var updateResponse = await UpdateTagAsync(workspaceId, tagId, updateRequest).ConfigureAwait(false);
            if (!updateResponse.IsSuccessful) return updateResponse;
            return await this.DeleteTagAsync(workspaceId, tagId).ConfigureAwait(false);
        }
    }
}
