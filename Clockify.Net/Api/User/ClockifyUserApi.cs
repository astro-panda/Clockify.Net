using System.Collections.Generic;
using System.Threading.Tasks;
using Clockify.Net.Api.Common.Requests;
using Clockify.Net.Api.User.Requests;
using Clockify.Net.Api.User.Responses;
using Clockify.Net.Models;
using RestSharp;

namespace Clockify.Net.Api.User;

public sealed class ClockifyUserApi {
	private readonly RestClient _mainClient;

	public ClockifyUserApi(RestClient mainClient) {
		_mainClient = mainClient;
	}

	/// <summary>
	/// Find all users on workspace
	/// </summary>
	public async Task<Response<List<UserDetails>>> FindAllUsersOnWorkspaceAsync(
		string workspaceId, GetAllUserRequest? getAllUserRequest) {
		var request = new RestRequest($"workspaces/{workspaceId}/users");

		if (getAllUserRequest is not null) {
			request.AddPagedQuery(getAllUserRequest);
			if (getAllUserRequest.Email is not null) request.AddQueryParameter("email", getAllUserRequest.Email);
			if (getAllUserRequest.ProjectId is not null) request.AddQueryParameter("projectId", getAllUserRequest.ProjectId);
			if (getAllUserRequest.Status is not null) request.AddQueryParameter("status", getAllUserRequest.Status.ToString());
			if (getAllUserRequest.Name is not null) request.AddQueryParameter("name", getAllUserRequest.Name);
			if (getAllUserRequest.Memberships is not null) request.AddQueryParameter("memberships", getAllUserRequest.Email);
		}

		var response = await _mainClient.ExecuteGetAsync<List<UserDetails>>(request)
		                                       .ConfigureAwait(false);
		return response;
	}

	public async Task<Response<UserDetails>> GetCurrentUserAsync() {
		var request = new RestRequest("user");
		var response = await _mainClient.ExecuteGetAsync<UserDetails>(request).ConfigureAwait(false);
		return response;
	}
}