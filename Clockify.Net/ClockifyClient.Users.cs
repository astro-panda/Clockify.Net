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
        public async Task<Response<List<UserDto>>> FindAllUsersOnWorkspaceAsync(string workspaceId, int page = 1, int pageSize = 50)
        {
            var request = new RestRequest($"workspaces/{workspaceId}/users");

            request.AddQueryParameter(nameof(page), page.ToString());
            request.AddQueryParameter("page-size", pageSize.ToString());

            return Response<List<UserDto>>.FromRestResponse(await _client.ExecuteGetAsync<List<UserDto>>(request).ConfigureAwait(false));
        }

        /// <summary>
        /// Get currently logged in user's info
        /// </summary>
        public async Task<Response<CurrentUserDto>> GetCurrentUserAsync()
        {
            var request = new RestRequest("user");
            return Response<CurrentUserDto>.FromRestResponse(await _client.ExecuteGetAsync<CurrentUserDto>(request).ConfigureAwait(false));
        }

        /// <summary>
        /// Set active workspace for user
        /// </summary>
        [Obsolete("Removed from the experimental API")]
        public async Task<Response<UserDto>> SetActiveWorkspaceFor(string userId, string workspaceId)
        {
            var request = new RestRequest($"users/{userId}/activeWorkspace/{workspaceId}");
            return Response<UserDto>.FromRestResponse(await _experimentalClient.ExecutePostAsync<UserDto>(request).ConfigureAwait(false));
        }
    }
}
