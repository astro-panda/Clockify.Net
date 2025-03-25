using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Clockify.Net.Models;
using Clockify.Net.Models.Users;
using RestSharp;

namespace Clockify.Net
{
    public partial class ClockifyClient
    {
        /// <summary>
        /// Find all users on workspace
        /// </summary>
        public async Task<Response<List<UserGroupDto>>> FindAllGroupsOnWorkspaceAsync(string workspaceId, int page = 1, int pageSize = 50)
        {
            var request = new RestRequest($"workspaces/{workspaceId}/user-groups");

            request.AddQueryParameter(nameof(page), page.ToString());
            request.AddQueryParameter("page-size", pageSize.ToString());

            return Response<List<UserGroupDto>>.FromRestResponse(await _client.ExecuteGetAsync<List<UserGroupDto>>(request).ConfigureAwait(false));
        }

    }
}
