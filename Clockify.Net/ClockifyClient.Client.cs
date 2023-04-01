using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Clockify.Net.Api.Client.Requests;
using Clockify.Net.Api.Client.Responses;
using Clockify.Net.Models;
using RestSharp;

namespace Clockify.Net; 

public partial class ClockifyClient
{
    /// <summary>
    /// Find clients on workspace
    /// </summary>
    public async Task<Response<List<ClientDetails>>> FindAllClientsOnWorkspaceAsync(string workspaceId, int page = 1, int pageSize = 50)
    {
        var request = new RestRequest($"workspaces/{workspaceId}/clients");

        request.AddQueryParameter(nameof(page), page.ToString());
        request.AddQueryParameter("page-size", pageSize.ToString());

        var restResponse = await _client.ExecuteGetAsync<List<ClientDetails>>(request).ConfigureAwait(false);
        return Response<List<ClientDetails>>.FromRestResponse(restResponse);
    }

    /// <summary>
    /// Add a new client to workspace.
    /// </summary>
    public async Task<Response<ClientDetails>> CreateClientAsync(string workspaceId, CreateClientRequest createClientRequest)
    {
        if (createClientRequest == null) { throw new ArgumentNullException(nameof(createClientRequest)); }

        var request = new RestRequest($"workspaces/{workspaceId}/clients", Method.Post);
        request.AddJsonBody(createClientRequest);
            
        return Response<ClientDetails>.FromRestResponse(await _client.ExecutePostAsync<ClientDetails>(request).ConfigureAwait(false));
    }

    /// <summary>
    /// Update a client's name on workspace.
    /// </summary>
    public async Task<Response<UpdateClientResponse>> UpdateClientAsync(string workspaceId, string? clientId, UpdateClientRequest updateClientRequest)
    {
        var request = new RestRequest($"workspaces/{workspaceId}/clients/{clientId}", Method.Put);
        request.AddJsonBody(updateClientRequest);
        return Response<UpdateClientResponse>.FromRestResponse(await _client.ExecuteAsync<UpdateClientResponse>(request).ConfigureAwait(false));
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
        var clientUpdateRequest = new UpdateClientRequest {Archived = true, Name = Guid.NewGuid().ToString()};
        var updateClientResponse = await UpdateClientAsync(workspaceId, clientId, clientUpdateRequest).ConfigureAwait(false);
        if (!updateClientResponse.IsSuccessful) return updateClientResponse;
        return await this.DeleteClientAsync(workspaceId, clientId).ConfigureAwait(false);
    }
}