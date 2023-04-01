using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Clockify.Net.Models;
using Clockify.Net.Models.Clients;
using RestSharp;

namespace Clockify.Net.Api.Client;

public sealed class ClockifyClientApi : IClockifyClientApi {
	private readonly RestClient _client;

	public ClockifyClientApi(RestClient client) {
		_client = client;
	}

	/// <summary>
	/// Find clients on workspace
	/// </summary>
	public async Task<Response<List<ClientDto>>> FindAllClientsOnWorkspaceAsync(
		string workspaceId, int page = 1, int pageSize = 50) {
		var request = new RestRequest($"workspaces/{workspaceId}/clients");

		request.AddQueryParameter("page", page.ToString());
		request.AddQueryParameter("page-size", pageSize.ToString());

		var response = await _client.ExecuteGetAsync<List<ClientDto>>(request).ConfigureAwait(false);
		return response;
	}

	/// <summary>
	/// Add a new client to workspace.
	/// </summary>
	public async Task<Response<ClientDto>> CreateClientAsync(string workspaceId, ClientRequest clientRequest) {
		var request = new RestRequest($"workspaces/{workspaceId}/clients", Method.Post);
		request.AddJsonBody(clientRequest);
		var response = await _client.ExecutePostAsync<ClientDto>(request).ConfigureAwait(false);
		return response;
	}
	
	/// <summary>
	/// Update a client's name on workspace.
	/// </summary>
	public async Task<Response<ClientUpdateDto>> UpdateClientAsync(string workspaceId, string clientId,
	                                                               ClientUpdateRequest updateRequest) {
		var request = new RestRequest($"workspaces/{workspaceId}/clients/{clientId}", Method.Put);
		request.AddJsonBody(updateRequest);
		var response = await _client.ExecuteAsync<ClientUpdateDto>(request).ConfigureAwait(false);
		return response;
	}

	/// <summary>
	/// Delete a client from a workspace.
	/// </summary>
	public async Task<Response> DeleteClientAsync(string workspaceId, string? clientId) {
		var request = new RestRequest($"workspaces/{workspaceId}/clients/{clientId}");
		var response = await _client.ExecuteAsync(request, Method.Delete).ConfigureAwait(false);
		return response;
	}

	/// <summary>
	/// Delete a client from a workspace.
	/// </summary>
	public async Task<Response> ArchiveAndDeleteClientAsync(string workspaceId, string clientId) {
		var clientUpdateRequest = new ClientUpdateRequest { Archived = true, Name = Guid.NewGuid().ToString() };
		var updateClientResponse =
			await UpdateClientAsync(workspaceId, clientId, clientUpdateRequest).ConfigureAwait(false);
		if (!updateClientResponse.IsSuccessful) return updateClientResponse;
		return await DeleteClientAsync(workspaceId, clientId).ConfigureAwait(false);
	}
}