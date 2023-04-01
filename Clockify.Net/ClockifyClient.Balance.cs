using System;
using System.Linq;
using System.Threading.Tasks;
using Clockify.Net.Api.Balance.Requests;
using Clockify.Net.Api.Balance.Responses;
using Clockify.Net.Models;
using RestSharp;

namespace Clockify.Net; 

public partial class ClockifyClient
{
	/// <summary>
	/// Get Balance by Policy Id.
	/// </summary>
	/// <returns></returns>
	public async Task<Response<BalanceDetails>> GetBalanceByPolicyAsync(string workspaceId, string policyId, GetBalanceRequest? balance = null)
	{
		var request = new RestRequest($"workspaces/{workspaceId}/balance/policy/{policyId}");
		if (balance != null)
		{
			if (balance.Page is {} balancePage) request.AddQueryParameter("page", balancePage);
			if (balance.PageSize is { } balancePageSize) request.AddQueryParameter("page-size", balancePageSize);
			if (balance.Sort != null) request.AddQueryParameter("sort", balance.Sort);
			if (balance.SortOrder != null) request.AddQueryParameter("sort-order", balance.SortOrder);
		}
		return Response<BalanceDetails>.FromRestResponse(await _ptoClient.ExecuteGetAsync<BalanceDetails>(request).ConfigureAwait(false));
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
	
	/// <summary>
	/// Get Balance by User Id.
	/// </summary>
	/// <returns></returns>
	public async Task<Response<GetBalanceResponse>> GetBalanceByUserAsync(string workspaceId, string userId, GetBalanceRequest? balance = null)
	{
		var request = new RestRequest($"workspaces/{workspaceId}/balance/user/{userId}");
		if (balance != null)
		{
			if (balance.Page is {} balancePage) request.AddQueryParameter("page", balancePage);
			if (balance.PageSize is { } balancePageSize) request.AddQueryParameter("page-size", balancePageSize);
			if (balance.Sort != null) request.AddQueryParameter("sort", balance.Sort);
			if (balance.SortOrder != null) request.AddQueryParameter("sort-order", balance.SortOrder);
		}
		return Response<GetBalanceResponse>.FromRestResponse(await _ptoClient.ExecuteGetAsync<GetBalanceResponse>(request).ConfigureAwait(false));
	}
}