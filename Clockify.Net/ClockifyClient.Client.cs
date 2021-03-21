using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Clockify.Net.Models.Clients;
using RestSharp;

namespace Clockify.Net
{
    public partial class ClockifyClient
    {
        /// <summary>
        /// Find clients on workspace
        /// </summary>
        public Task<IRestResponse<List<ClientDto>>> FindAllClientsOnWorkspaceAsync(string workspaceId, int page = 1, int pageSize = 50)
        {
            var request = new RestRequest($"workspaces/{workspaceId}/clients");

            request.AddQueryParameter(nameof(page), page.ToString());
            request.AddQueryParameter("page-size", pageSize.ToString());

            return _client.ExecuteGetAsync<List<ClientDto>>(request);
        }

        /// <summary>
        /// Add a new client to workspace.
        /// </summary>
        public Task<IRestResponse<ClientDto>> CreateClientAsync(string workspaceId, ClientRequest clientRequest)
        {
            if (clientRequest == null) { throw new ArgumentNullException(nameof(clientRequest)); }

            var request = new RestRequest($"workspaces/{workspaceId}/clients", Method.POST);
            request.AddJsonBody(clientRequest);
            return _client.ExecutePostAsync<ClientDto>(request);
        }
    }
}
