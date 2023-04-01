using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Clockify.Net.Models;
using Clockify.Net.Models.Clients;
using RestSharp;

namespace Clockify.Net; 

public partial class ClockifyClient
{
    /// <summary>
    /// Find clients on workspace
    /// </summary>
    public async Task<Response<List<ClientDto>>> FindAllClientsOnWorkspaceAsync(string workspaceId, int page = 1, int pageSize = 50)
    {
        var request = new RestRequest($"workspaces/{workspaceId}/clients");

        request.AddQueryParameter(nameof(page), page.ToString());
        request.AddQueryParameter("page-size", pageSize.ToString());

        var restResponse = await _client.ExecuteGetAsync<List<ClientDto>>(request).ConfigureAwait(false);
        return Response<List<ClientDto>>.FromRestResponse(restResponse);
    }

    /// <summary>
    /// Add a new client to workspace.
    /// </summary>
    public async Task<Response<ClientDto>> CreateClientAsync(string workspaceId, ClientRequest clientRequest)
    {
        if (clientRequest == null) { throw new ArgumentNullException(nameof(clientRequest)); }

        var request = new RestRequest($"workspaces/{workspaceId}/clients", Method.Post);
        request.AddJsonBody(clientRequest);
            
        return Response<ClientDto>.FromRestResponse(await _client.ExecutePostAsync<ClientDto>(request).ConfigureAwait(false));
    }

    /// <summary>
    /// Update a client's name on workspace.
    /// </summary>
    [Obsolete($"Use {nameof(UpdateClientAsync)} instead.")]
    public async Task<Response<ClientUpdateDto>> UpdateClientNameAsync(string workspaceId, string? clientId, ClientName clientName)
    {
        if (clientName == null) { throw new ArgumentNullException(nameof(clientName)); }

        var request = new RestRequest($"workspaces/{workspaceId}/clients/{clientId}", Method.Put);
        request.AddJsonBody(clientName);
        return Response<ClientUpdateDto>.FromRestResponse(await _client.ExecuteAsync<ClientUpdateDto>(request).ConfigureAwait(false));
    }
        
    /// <summary>
    /// Update a client's name on workspace.
    /// </summary>
    public async Task<Response<ClientUpdateDto>> UpdateClientAsync(string workspaceId, string? clientId, ClientUpdateRequest updateRequest)
    {
        var request = new RestRequest($"workspaces/{workspaceId}/clients/{clientId}", Method.Put);
        request.AddJsonBody(updateRequest);
        return Response<ClientUpdateDto>.FromRestResponse(await _client.ExecuteAsync<ClientUpdateDto>(request).ConfigureAwait(false));
    }
        
    /// <summary>
    /// Delete a client from a workspace.
    /// </summary>
    public async Task<Response> DeleteClientAsync(string workspaceId, string? clientId)
    {
        var request = new RestRequest($"workspaces/{workspaceId}/clients/{clientId}");
        return Response.FromRestResponse(await _client.ExecuteAsync(request, Method.Delete).ConfigureAwait(false));
    }
        
    /// <summary>
    /// Delete a client from a workspace.
    /// </summary>
    public async Task<Response> ArchiveAndDeleteClientAsync(string workspaceId, string? clientId)
    {
        var clientUpdateRequest = new ClientUpdateRequest {Archived = true, Name = Guid.NewGuid().ToString()};
        var updateClientResponse = await UpdateClientAsync(workspaceId, clientId, clientUpdateRequest).ConfigureAwait(false);
        if (!updateClientResponse.IsSuccessful) return updateClientResponse;
        return await this.DeleteClientAsync(workspaceId, clientId).ConfigureAwait(false);
    }
}