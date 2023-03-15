using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clockify.Net.Models;
using Clockify.Net.Models.Enums;
using Clockify.Net.Models.Policies;
using RestSharp;

namespace Clockify.Net;

public partial class ClockifyClient
{
	/// <summary>
	///   Get all Policies
	/// </summary>
	public async Task<Response<IEnumerable<PolicyDto>>> GetPoliciesAsync(string workspaceId,
		GetPoliciesRequest? policy = null)
	{
		var request = new RestRequest($"workspaces/{workspaceId}/policies");
		if (policy != null)
		{
			if (policy.Page is { } policyPage) request.AddQueryParameter("page", policyPage);
			if (policy.PageSize is { } policyPageSize) request.AddQueryParameter("page-size", policyPageSize);
			if (policy.Name != null) request.AddQueryParameter("name", policy.Name);
			if (policy.Status != null) request.AddQueryParameter("status", policy.Status.ToString());
		}

		return Response<IEnumerable<PolicyDto>>.FromRestResponse(await _ptoClient
			.ExecuteGetAsync<IEnumerable<PolicyDto>>(request).ConfigureAwait(false));
	}

	/// <summary>
	///   Add a new Policy to workspace.
	/// </summary>
	public async Task<Response<PolicyDto>> CreateTimeOffPolicyAsync(string workspaceId, PolicyRequest policy)
	{
		if (policy == null) throw new ArgumentNullException(nameof(policy));
		if (policy.Approve == null) throw new ArgumentNullException(nameof(policy.Approve));
		if (policy.Name == null) throw new ArgumentNullException(nameof(policy.Name));
		if (policy.TimeUnit != null && !Enum.IsDefined(typeof(TimeUnitEnum), policy.TimeUnit))
			throw new ArgumentOutOfRangeException(nameof(policy.TimeUnit));
		if ((policy.UserGroups?.Ids == null || !policy.UserGroups.Ids.Any()) &&
		    (policy.Users?.Ids == null || !policy.Users.Ids.Any()))
			throw new ArgumentOutOfRangeException("At least one user or user group must be assigned");

		var request = new RestRequest($"workspaces/{workspaceId}/policies", Method.Post);
		request.AddJsonBody(policy);
		return Response<PolicyDto>.FromRestResponse(await _ptoClient.ExecuteAsync<PolicyDto>(request)
			.ConfigureAwait(false));
	}

	/// <summary>
	///   Delete Policy with Id.
	/// </summary>
	public async Task<Response> DeletePolicyAsync(string workspaceId, string policyId)
	{
		var request = new RestRequest($"workspaces/{workspaceId}/policies/{policyId}");
		return Response.FromRestResponse(await _ptoClient.ExecuteAsync(request, Method.Delete).ConfigureAwait(false));
	}

	/// <summary>
	///   Get Policy with Id.
	/// </summary>
	/// <returns></returns>
	public async Task<Response<PolicyDto>> GetPolicyAsync(string workspaceId, string policyId)
	{
		var request = new RestRequest($"workspaces/{workspaceId}/policies/{policyId}");
		return Response<PolicyDto>.FromRestResponse(await _ptoClient.ExecuteGetAsync<PolicyDto>(request)
			.ConfigureAwait(false));
	}

	/// <summary>
	///   Change Policy status on workspace.
	/// </summary>
	public async Task<Response<PolicyDto>> ChangePolicyStatusAsync(string workspaceId, string policyId,
		ChangePolicyStatusRequest policy)
	{
		if (policy == null) throw new ArgumentNullException(nameof(policy));
		if (!Enum.IsDefined(typeof(StatusEnum), policy.Status))
			throw new ArgumentOutOfRangeException(nameof(policy.Status));

		var request = new RestRequest($"workspaces/{workspaceId}/policies/{policyId}");
		request.AddJsonBody(policy);
		return Response<PolicyDto>.FromRestResponse(await _ptoClient.ExecuteAsync<PolicyDto>(request, Method.Patch)
			.ConfigureAwait(false));
	}

	/// <summary>
	///   Update Policy on workspace.
	/// </summary>
	public async Task<Response<PolicyDto>> UpdatePolicyAsync(string workspaceId, string policyId, PolicyRequest policy)
	{
		if (policy == null) throw new ArgumentNullException(nameof(policy));
		if (policy.AllowHalfDay == null) throw new ArgumentNullException(nameof(policy.AllowHalfDay));
		if (policy.AllowNegativeBalance == null) throw new ArgumentNullException(nameof(policy.AllowNegativeBalance));
		if (policy.Approve == null) throw new ArgumentNullException(nameof(policy.Approve));
		if (policy.Archived == null) throw new ArgumentNullException(nameof(policy.Archived));
		if (policy.EveryoneIncludingNew == null) throw new ArgumentNullException(nameof(policy.EveryoneIncludingNew));
		if (policy.Name == null) throw new ArgumentNullException(nameof(policy.Name));
		if (policy.UserGroups == null) throw new ArgumentNullException(nameof(policy.UserGroups));
		if (policy.UserGroups.Status == null) throw new ArgumentNullException(nameof(policy.UserGroups.Status)); // undocumented, but required for the update to succeed
		if (policy.Users == null) throw new ArgumentNullException(nameof(policy.Users));

		var request = new RestRequest($"workspaces/{workspaceId}/policies/{policyId}");
		request.AddJsonBody(policy);
		return Response<PolicyDto>.FromRestResponse(await _ptoClient.ExecuteAsync<PolicyDto>(request, Method.Put)
			.ConfigureAwait(false));
	}
	
	/// <summary>
	/// Archive and delete Policy on workspace.
	/// </summary>
	public async Task<Response> ArchiveAndDeletePolicyAsync(string workspaceId, string policyId)
	{
		var changePolicyStatusRequest = new ChangePolicyStatusRequest
		{
			Status = StatusEnum.ARCHIVED
		};
		var archivePolicyResponse = await ChangePolicyStatusAsync(workspaceId, policyId, changePolicyStatusRequest).ConfigureAwait(false);
		if (!archivePolicyResponse.IsSuccessful) return archivePolicyResponse;

		return await DeletePolicyAsync(workspaceId, policyId).ConfigureAwait(false);
	}
}