using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Clockify.Net.Models;
using Clockify.Net.Models.Enums;
using Clockify.Net.Models.Holiday;
using Clockify.Net.Models.Policies;
using RestSharp;

namespace Clockify.Net;

public partial class ClockifyClient
{
	/// <summary>
	/// Get all Policies
	/// </summary>
	public async Task<Response<IEnumerable<PolicyDto>>> GetPoliciesAsync(string workspaceId, GetPoliciesRequest policy)
	{
		var request = new RestRequest($"workspaces/{workspaceId}/policies");
		request.AddJsonBody(policy);
		return Response<IEnumerable<PolicyDto>>.FromRestResponse(await _ptoClient.ExecuteGetAsync<IEnumerable<PolicyDto>>(request).ConfigureAwait(false));
	}
	
	/// <summary>
	/// Add a new Policy to workspace.
	/// </summary>
	public async Task<Response<PolicyDto>> CreateTimeOffPolicyAsync(string workspaceId, PolicyRequest policy)
	{
		if (policy == null) throw new ArgumentNullException(nameof(policy));
		if (policy.Approve == null) throw new ArgumentNullException(nameof(policy.Approve));
		if (policy.Name == null) throw new ArgumentNullException(nameof(policy.Name));

		var request = new RestRequest($"workspaces/{workspaceId}/policies", Method.Post);
		request.AddJsonBody(policy);
		return Response<PolicyDto>.FromRestResponse(await _ptoClient.ExecuteAsync<PolicyDto>(request).ConfigureAwait(false));
	}
	
	/// <summary>
	/// Delete Policy with Id.
	/// </summary>
	public async Task<Response> DeletePolicyAsync(string workspaceId, string policyId)
	{
		var request = new RestRequest($"workspaces/{workspaceId}/policies/{policyId}");
		return Response.FromRestResponse(await _ptoClient.ExecuteAsync(request, Method.Delete).ConfigureAwait(false));
	}

	/// <summary>
	/// Get Policy with Id.
	/// </summary>
	/// <returns></returns>
	public async Task<Response<PolicyDto>> GetPolicyAsync(string workspaceId, string policyId)
	{
		var request = new RestRequest($"workspaces/{workspaceId}/policies/{policyId}");
		return Response<PolicyDto>.FromRestResponse(await _ptoClient.ExecuteGetAsync<PolicyDto>(request).ConfigureAwait(false));
	}
	
	/// <summary>
	/// Change Policy status on workspace.
	/// </summary>
	public async Task<Response<PolicyDto>> ChangePolicyStatusAsync(string workspaceId, string holidayId, ChangePolicyStatusRequest policy)
	{
		if (policy == null) throw new ArgumentNullException(nameof(policy));
		if (!Enum.IsDefined(typeof(StatusEnum), policy.Status))
			throw new ArgumentOutOfRangeException(nameof(policy.Status));

		var request = new RestRequest($"workspaces/{workspaceId}/policies/{holidayId}");
		request.AddJsonBody(policy);
		return Response<PolicyDto>.FromRestResponse(await _ptoClient.ExecuteAsync<PolicyDto>(request, Method.Patch).ConfigureAwait(false));
	}
	
	/// <summary>
	/// Update Policy on workspace.
	/// </summary>
	public async Task<Response<HolidayDto>> UpdatePolicyAsync(string workspaceId, string holidayId, PolicyRequest policy)
	{
		if (policy == null) throw new ArgumentNullException(nameof(policy));
		if (policy.AllowHalfDay == null) throw new ArgumentNullException(nameof(policy.AllowHalfDay));
		if (policy.AllowNegativeBalance == null) throw new ArgumentNullException(nameof(policy.AllowNegativeBalance));
		if (policy.Approve == null) throw new ArgumentNullException(nameof(policy.Approve));
		if (policy.Archived == null) throw new ArgumentNullException(nameof(policy.Archived));
		if (policy.EveryoneIncludingNew == null) throw new ArgumentNullException(nameof(policy.EveryoneIncludingNew));
		if (policy.Name == null) throw new ArgumentNullException(nameof(policy.Name));
		if (policy.UserGroups == null) throw new ArgumentNullException(nameof(policy.UserGroups));
		if (policy.Users == null) throw new ArgumentNullException(nameof(policy.Users));

		var request = new RestRequest($"workspaces/{workspaceId}/policies/{holidayId}");
		request.AddJsonBody(policy);
		return Response<HolidayDto>.FromRestResponse(await _ptoClient.ExecuteAsync<HolidayDto>(request, Method.Put).ConfigureAwait(false));
	}
}