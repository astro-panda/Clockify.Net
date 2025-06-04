using System;
using System.Linq;
using System.Threading.Tasks;
using Clockify.Net.Models;
using Clockify.Net.Models.TimeOff;
using RestSharp;

namespace Clockify.Net;

public partial class ClockifyClient
{
	/// <summary>
	///   Create a Time Off request for day policies.
	/// </summary>
	public async Task<Response<TimeOffRequestFullV1Dto>> CreateTimeOffRequestForDayPoliciesAsync(string workspaceId,
		string policyId, TimeOffRequestRequest timeOffRequest)
	{
		if (timeOffRequest == null) throw new ArgumentNullException(nameof(timeOffRequest));
		if (timeOffRequest.TimeOffPeriod == null) throw new ArgumentNullException(nameof(timeOffRequest.TimeOffPeriod));
		if (timeOffRequest.TimeOffPeriod is {Period: null})
			throw new ArgumentNullException(nameof(timeOffRequest.TimeOffPeriod.Period));

		var request = new RestRequest($"workspaces/{workspaceId}/time-off/policies/{policyId}/requests", Method.Post);
		request.AddJsonBody(timeOffRequest);
		return Response<TimeOffRequestFullV1Dto>.FromRestResponse(await _client
			.ExecuteAsync<TimeOffRequestFullV1Dto>(request).ConfigureAwait(false));
	}

	/// <summary>
	///   Delete Time Off Request with Id.
	/// </summary>
	public async Task<Response> DeleteTimeOffRequestAsync(string workspaceId, string policyId, string requestId)
	{
		var request = new RestRequest($"workspaces/{workspaceId}/time-off/policies/{policyId}/requests/{requestId}");
		return Response.FromRestResponse(await _client.ExecuteAsync(request, Method.Delete).ConfigureAwait(false));
	}

	/// <summary>
	///   Change Time Off Request status on workspace.
	/// </summary>
	public async Task<Response<TimeOffRequestFullV1Dto>> ChangeTimeOffRequestStatusAsync(string workspaceId,
		string policyId, string requestId, ChangeTimeOffRequestStatusRequest timeOffRequest)
	{
		if (timeOffRequest == null) throw new ArgumentNullException(nameof(timeOffRequest));
		if (timeOffRequest.Status == null) throw new ArgumentNullException(nameof(timeOffRequest.Status));

		var request = new RestRequest($"workspaces/{workspaceId}/time-off/policies/{policyId}/requests/{requestId}");
		request.AddJsonBody(timeOffRequest);
		return Response<TimeOffRequestFullV1Dto>.FromRestResponse(await _client
			.ExecuteAsync<TimeOffRequestFullV1Dto>(request, Method.Patch).ConfigureAwait(false));
	}

	/// <summary>
	///   Create a Time Off request.
	/// </summary>
	public async Task<Response<TimeOffRequestFullV1Dto>> CreateTimeOffRequestAsync(string workspaceId,
		string policyId, string userId, TimeOffRequestRequest timeOffRequest)
	{
		if (timeOffRequest == null) throw new ArgumentNullException(nameof(timeOffRequest));
		if (timeOffRequest.Note == null) throw new ArgumentNullException(nameof(timeOffRequest.Note));
		if (timeOffRequest.TimeOffPeriod == null) throw new ArgumentNullException(nameof(timeOffRequest.TimeOffPeriod));
		if (timeOffRequest.TimeOffPeriod is {Period: null})
			throw new ArgumentNullException(nameof(timeOffRequest.TimeOffPeriod.Period));
		if (timeOffRequest.TimeOffPeriod.Period.Days < 1)
			throw new ArgumentOutOfRangeException(nameof(timeOffRequest.TimeOffPeriod.Period.Days));
		if (timeOffRequest.TimeOffPeriod.Period.Start == null)
			throw new ArgumentNullException(nameof(timeOffRequest.TimeOffPeriod.Period.Start));
		if (timeOffRequest.TimeOffPeriod.Period.End == null)
			throw new ArgumentNullException(nameof(timeOffRequest.TimeOffPeriod.Period.End));

		var request = new RestRequest($"workspaces/{workspaceId}/time-off/policies/{policyId}/users/{userId}/requests", Method.Post);
		request.AddJsonBody(timeOffRequest);
		return Response<TimeOffRequestFullV1Dto>.FromRestResponse(await _client
			.ExecuteAsync<TimeOffRequestFullV1Dto>(request).ConfigureAwait(false));
	}

	/// <summary>
	///   Get all Time Off requests.
	/// </summary>
	public async Task<Response<TimeOffRequestResponse>> GetAllTimeOffRequestsAsync(string workspaceId,
		GetAllTimeOffRequestsRequest timeOffRequest)
	{
		if (timeOffRequest == null) throw new ArgumentNullException(nameof(timeOffRequest));
		if (timeOffRequest.Statuses == null || !timeOffRequest.Statuses.Any())
			throw new ArgumentOutOfRangeException(nameof(timeOffRequest.Statuses));
		if ((timeOffRequest.UserGroups == null || !timeOffRequest.UserGroups.Any()) &&
		    (timeOffRequest.Users == null || !timeOffRequest.Users.Any()))
		{
			throw new ArgumentOutOfRangeException("At least one user or user group must be defined");
		}

		var request = new RestRequest($"workspaces/{workspaceId}/time-off/requests");
		request.AddJsonBody(timeOffRequest);
		return Response<TimeOffRequestResponse>.FromRestResponse(await _client
			.ExecutePostAsync<TimeOffRequestResponse>(request).ConfigureAwait(false));
	}
}