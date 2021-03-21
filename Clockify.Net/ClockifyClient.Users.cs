using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Clockify.Net.Models.Users;
using RestSharp;

namespace Clockify.Net
{
    public partial class ClockifyClient
    {
        /// <summary>
        /// Find all users on workspace
        /// </summary>
        public Task<IRestResponse<List<UserDto>>> FindAllUsersOnWorkspaceAsync(string workspaceId, int page = 1, int pageSize = 50)
        {
            var request = new RestRequest($"workspaces/{workspaceId}/users");

            request.AddQueryParameter(nameof(page), page.ToString());
            request.AddQueryParameter("page-size", pageSize.ToString());

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
    }
}
