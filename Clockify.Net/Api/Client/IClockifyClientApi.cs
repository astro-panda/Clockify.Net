using System.Collections.Generic;
using System.Threading.Tasks;
using Clockify.Net.Models;
using Clockify.Net.Models.Clients;

namespace Clockify.Net.Api.Client;

public interface IClockifyClientApi {
	/// <summary>
	/// Find clients on workspace
	/// </summary>
	Task<Response<List<ClientDto>>> FindAllClientsOnWorkspaceAsync(
		string workspaceId, int page = 1, int pageSize = 50);

	/// <summary>
	/// Add a new client to workspace.
	/// </summary>
	Task<Response<ClientDto>> CreateClientAsync(string workspaceId, ClientRequest clientRequest);

	/// <summary>
	/// Update a client's name on workspace.
	/// </summary>
	Task<Response<ClientUpdateDto>> UpdateClientAsync(string workspaceId, string clientId,
	                                                  ClientUpdateRequest updateRequest);

	/// <summary>
	/// Delete a client from a workspace.
	/// </summary>
	Task<Response> DeleteClientAsync(string workspaceId, string? clientId);

	/// <summary>
	/// Delete a client from a workspace.
	/// </summary>
	Task<Response> ArchiveAndDeleteClientAsync(string workspaceId, string clientId);
}