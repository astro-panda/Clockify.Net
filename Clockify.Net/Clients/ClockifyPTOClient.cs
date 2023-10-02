using Clockify.Net.Models.Balance;
using Clockify.Net.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Clockify.Net.Clients
{
    internal class ClockifyPTOClient
    {
        /// <summary>
        /// Get Balance by Policy Id.
        /// </summary>
        /// <returns></returns>
        public async Task<Response<BalanceDtoV1>> GetBalanceByPolicyAsync(string workspaceId, string policyId, BalanceRequest? balance = null)
        {
            var request = new RestRequest($"workspaces/{workspaceId}/balance/policy/{policyId}");
            if (balance != null)
            {
                if (balance.Page is { } balancePage) request.AddQueryParameter("page", balancePage);
                if (balance.PageSize is { } balancePageSize) request.AddQueryParameter("page-size", balancePageSize);
                if (balance.Sort != null) request.AddQueryParameter("sort", balance.Sort);
                if (balance.SortOrder != null) request.AddQueryParameter("sort-order", balance.SortOrder);
            }
            return Response<BalanceDtoV1>.FromRestResponse(await _ptoClient.ExecuteGetAsync<BalanceDtoV1>(request).ConfigureAwait(false));
        }

        /// <summary>
        /// Update Balance on workspace.
        /// </summary>
        public async Task<Response> UpdateBalanceAsync(string workspaceId, string policyId, UpdateBalanceRequest balance)
        {
            if (balance == null) throw new ArgumentNullException(nameof(balance));
            if (balance.UserIds == null || !balance.UserIds.Any()) throw new ArgumentNullException(nameof(balance.UserIds));
            if (balance.Value == null) throw new ArgumentNullException(nameof(balance.Value));

            var request = new RestRequest($"workspaces/{workspaceId}/balance/policy/{policyId}");
            request.AddJsonBody(balance);
            return Response.FromRestResponse(await _ptoClient.ExecuteAsync(request, Method.Patch).ConfigureAwait(false));
        }

        public async Task<Response<BalancesDto>> GetBalanceByUserAsync(string workspaceId, string userId, BalanceRequest? balance = null)
        {
            var request = new RestRequest($"workspaces/{workspaceId}/balance/user/{userId}");
            if (balance != null)
            {
                if (balance.Page is { } balancePage) request.AddQueryParameter("page", balancePage);
                if (balance.PageSize is { } balancePageSize) request.AddQueryParameter("page-size", balancePageSize);
                if (balance.Sort != null) request.AddQueryParameter("sort", balance.Sort);
                if (balance.SortOrder != null) request.AddQueryParameter("sort-order", balance.SortOrder);
            }
            return Response<BalancesDto>.FromRestResponse(await _ptoClient.ExecuteGetAsync<BalancesDto>(request).ConfigureAwait(false));
        }
    }
}
