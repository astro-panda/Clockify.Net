using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Clockify.Net.Models.Tags;
using RestSharp;

namespace Clockify.Net
{
    public partial class ClockifyClient
    {
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
    }
}
