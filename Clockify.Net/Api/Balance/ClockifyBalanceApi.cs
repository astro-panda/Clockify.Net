using System;
using System.Linq;
using System.Threading.Tasks;
using Clockify.Net.Api.Balance.Requests;
using Clockify.Net.Api.Balance.Responses;
using Clockify.Net.Api.Common.Requests;
using Clockify.Net.Models;
using RestSharp;

namespace Clockify.Net.Api.Balance;

public sealed class ClockifyBalanceApi : IClockifyBalanceApi {
	private readonly RestClient _ptoClient;

	public ClockifyBalanceApi(RestClient ptoClient) {
		_ptoClient = ptoClient;
	}
	
	public async Task<Response<GetBalanceResponse>> GetBalanceByPolicyAsync(string workspaceId, string policyId,
	                                                                  GetBalanceRequest? getBalanceRequest = null) {
		var request = new RestRequest($"workspaces/{workspaceId}/balance/policy/{policyId}");
		if (getBalanceRequest is not null) request.AddPagedQuery(getBalanceRequest);

		var response = await _ptoClient.ExecuteGetAsync<GetBalanceResponse>(request).ConfigureAwait(false);
		return response;
	}
	
	public async Task<Response<GetBalanceResponse>> GetBalanceByUserAsync(string workspaceId, string userId,
	                                                               GetBalanceRequest? getBalanceRequest = null) {
		var request = new RestRequest($"workspaces/{workspaceId}/balance/user/{userId}");
		if (getBalanceRequest is not null) request.AddPagedQuery(getBalanceRequest);

		var response = await _ptoClient.ExecuteGetAsync<GetBalanceResponse>(request).ConfigureAwait(false);
		return response;
	}

	public async Task<Response> UpdateBalanceAsync(string workspaceId, string policyId, UpdateBalanceRequest balance) {
		if (balance.UserIds.Any()) throw new ArgumentNullException(nameof(balance.UserIds));

		var request = new RestRequest($"workspaces/{workspaceId}/balance/policy/{policyId}");
		request.AddJsonBody(balance);
		var response = await _ptoClient.ExecuteAsync(request, Method.Patch).ConfigureAwait(false);
		return response;
	}
}