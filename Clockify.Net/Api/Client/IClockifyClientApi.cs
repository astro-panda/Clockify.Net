using System.Collections.Generic;
using System.Threading.Tasks;
using Clockify.Net.Api.Client.Requests;
using Clockify.Net.Api.Client.Responses;
using Clockify.Net.Models;

namespace Clockify.Net.Api.Client;

public interface IClockifyClientApi {
	Task<Response<List<ClientDetails>>> FindAllClientsOnWorkspaceAsync(string workspaceId,
	                                                                   GetClientsRequest? getClientsRequest = null);
	Task<Response<ClientDetails>> GetClientByIdAsync(string workspaceId, string id);
	Task<Response<ClientDetails>> CreateClientAsync(string workspaceId, CreateClientRequest createClientRequest);
	Task<Response<UpdateClientResponse>> UpdateClientAsync(string workspaceId, string clientId,
	                                                       UpdateClientRequest request);
	Task<Response> DeleteClientAsync(string workspaceId, string? clientId);
	/// <summary>
	/// Archive and delete a client from a workspace.
	/// </summary>
	Task<Response> ArchiveAndDeleteClientAsync(string workspaceId, string clientId);
}