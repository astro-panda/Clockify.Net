using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Clockify.Net.Api.Client.Requests;
using Clockify.Net.Api.Client.Responses;
using Clockify.Net.Api.Common.Requests;
using Clockify.Net.Models;
using RestSharp;

namespace Clockify.Net.Api.Client;

public sealed class ClockifyClientApi : IClockifyClientApi {
	private readonly RestClient _client;

	public ClockifyClientApi(RestClient client) {
		_client = client;
	}

	public async Task<Response<List<ClientDetails>>> FindAllClientsOnWorkspaceAsync(
		string workspaceId, GetClientsRequest? getClientsRequest = null) {
		var request = new RestRequest($"workspaces/{workspaceId}/clients");

		if (getClientsRequest is not null) {
			request.AddPagedQuery(getClientsRequest);
			if (getClientsRequest.Name is not null) request.AddQueryParameter("name", getClientsRequest.Name);
			if (getClientsRequest.Archived is not null) request.AddQueryParameter("archived", getClientsRequest.Archived.ToString());
		}
		
		var response = await _client.ExecuteGetAsync<List<ClientDetails>>(request).ConfigureAwait(false);
		return response;
	}

	public async Task<Response<ClientDetails>> GetClientByIdAsync(string workspaceId, string id) {
		var request = new RestRequest($"workspaces/{workspaceId}/clients/{id}");
		var response = await _client.ExecuteGetAsync<ClientDetails>(request).ConfigureAwait(false);
		return response;
	}

	public async Task<Response<ClientDetails>> CreateClientAsync(string workspaceId, CreateClientRequest createClientRequest) {
		var request = new RestRequest($"workspaces/{workspaceId}/clients", Method.Post);
		request.AddJsonBody(createClientRequest);
		var response = await _client.ExecutePostAsync<ClientDetails>(request).ConfigureAwait(false);
		return response;
	}
	
	public async Task<Response<UpdateClientResponse>> UpdateClientAsync(string workspaceId, string clientId,
	                                                               UpdateClientRequest updateClientRequest) {
		var request = new RestRequest($"workspaces/{workspaceId}/clients/{clientId}", Method.Put);
		request.AddJsonBody(updateClientRequest);
		var response = await _client.ExecuteAsync<UpdateClientResponse>(request).ConfigureAwait(false);
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
	/// Archive and delete a client from a workspace.
	/// </summary>
	public async Task<Response> ArchiveAndDeleteClientAsync(string workspaceId, string clientId) {
		var updateClientRequest = new UpdateClientRequest { Archived = true, Name = Guid.NewGuid().ToString() };
		var updateClientResponse =
			await UpdateClientAsync(workspaceId, clientId, updateClientRequest).ConfigureAwait(false);
		if (!updateClientResponse.IsSuccessful) return updateClientResponse;
		return await DeleteClientAsync(workspaceId, clientId).ConfigureAwait(false);
	}
}