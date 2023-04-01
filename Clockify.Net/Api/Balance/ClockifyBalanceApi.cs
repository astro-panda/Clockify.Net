using System;
using System.Linq;
using System.Threading.Tasks;
using Clockify.Net.Api.Balance.Requests;
using Clockify.Net.Api.Balance.Responses;
using Clockify.Net.Models;
using RestSharp;

namespace Clockify.Net.Api.Balance;

public sealed class ClockifyBalanceApi : IClockifyBalanceApi {
	private readonly RestClient _ptoClient;

	public ClockifyBalanceApi(RestClient ptoClient) {
		_ptoClient = ptoClient;
	}

	/// <summary>
	/// Get Balance by Policy Id.
	/// </summary>
	/// <returns></returns>
	public async Task<Response<GetBalanceResponse>> GetBalanceByPolicyAsync(string workspaceId, string policyId,
	                                                                  GetBalanceRequest? balance = null) {
		var request = new RestRequest($"workspaces/{workspaceId}/balance/policy/{policyId}");
		if (balance is not null) {
			if (balance.Page is { } balancePage) request.AddQueryParameter("page", balancePage);
			if (balance.PageSize is { } balancePageSize) request.AddQueryParameter("page-size", balancePageSize);
			if (balance.Sort is null) request.AddQueryParameter("sort", balance.Sort);
			if (balance.SortOrder is null) request.AddQueryParameter("sort-order", balance.SortOrder);
		}

		var response = await _ptoClient.ExecuteGetAsync<GetBalanceResponse>(request).ConfigureAwait(false);
		return response;
	}

	/// <summary>
	/// Get Balance by User Id.
	/// </summary>
	/// <returns></returns>
	public async Task<Response<GetBalanceResponse>> GetBalanceByUserAsync(string workspaceId, string userId,
	                                                               GetBalanceRequest? balance = null) {
		var request = new RestRequest($"workspaces/{workspaceId}/balance/user/{userId}");
		if (balance != null) {
			if (balance.Page is { } balancePage) request.AddQueryParameter("page", balancePage);
			if (balance.PageSize is { } balancePageSize) request.AddQueryParameter("page-size", balancePageSize);
			if (balance.Sort != null) request.AddQueryParameter("sort", balance.Sort);
			if (balance.SortOrder != null) request.AddQueryParameter("sort-order", balance.SortOrder);
		}

		var response = await _ptoClient.ExecuteGetAsync<GetBalanceResponse>(request).ConfigureAwait(false);
		return response;
	}

	/// <summary>
	/// Update Balance on workspace.
	/// </summary>
	public async Task<Response> UpdateBalanceAsync(string workspaceId, string policyId, UpdateBalanceRequest balance) {
		if (balance == null) throw new ArgumentNullException(nameof(balance));
		if (balance.UserIds == null || !balance.UserIds.Any()) throw new ArgumentNullException(nameof(balance.UserIds));
		if (balance.Value == null) throw new ArgumentNullException(nameof(balance.Value));

		var request = new RestRequest($"workspaces/{workspaceId}/balance/policy/{policyId}");
		request.AddJsonBody(balance);
		var response = await _ptoClient.ExecuteAsync(request, Method.Patch).ConfigureAwait(false);
		return response;
	}
}