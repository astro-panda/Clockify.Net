using System;
using System.Collections.Generic;

namespace Clockify.Net.Models.TimeOff;

public class GetAllTimeOffRequestsRequest
{
	public GetAllTimeOffRequestsRequest()
	{
	}

	/// <summary>
	///   For <see cref="ClockifyClient.GetAllTimeOffRequestsAsync" />
	/// </summary>
	public GetAllTimeOffRequestsRequest(IEnumerable<TimeOffRequestStatusEnum> statuses,
		IEnumerable<string>? userGroups = null, IEnumerable<string>? users = null)
	{
		Statuses = statuses;
		UserGroups = userGroups;
		Users = users;
	}

	public DateTime? End { get; set; }
	public int? Limit { get; set; }
	public int? Offset { get; set; }
	public DateTime? Start { get; set; }
	public int? Page { get; set; }
	public int? PageSize { get; set; }
	public IEnumerable<TimeOffRequestStatusEnum>? Statuses { get; set; }
	public IEnumerable<string>? UserGroups { get; set; }
	public IEnumerable<string>? Users { get; set; }
}