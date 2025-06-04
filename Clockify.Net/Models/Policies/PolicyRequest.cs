using Clockify.Net.Models.Enums;

namespace Clockify.Net.Models.Policies;

public class PolicyRequest
{
	public PolicyRequest()
	{
	}

	/// <summary>
	/// For <see cref="ClockifyClient.CreateTimeOffPolicyAsync"/>
	/// </summary>
	public PolicyRequest(string name, TimeUnitEnum timeUnit, ContainsFilter? userGroups = null, ContainsFilter? users = null)
	{
		Name = name;
		TimeUnit = timeUnit;
		UserGroups = userGroups;
		Users = users;
	}

	/// <summary>
	/// For <see cref="ClockifyClient.CreateTimeOffPolicyAsync"/>
	/// </summary>
	public PolicyRequest(ApproveDto approve, string name, TimeUnitEnum timeUnit, ContainsFilter? userGroups = null, ContainsFilter? users = null)
	: this(name, timeUnit, userGroups, users)
	{
		Approve = approve;
	}

	/// <summary>
	/// For <see cref="ClockifyClient.UpdatePolicyAsync"/>
	/// </summary>
	public PolicyRequest(bool allowHalfDay, bool allowNegativeBalance, ApproveDto approve, bool archived, bool everyoneIncludingNew, string name, ContainsFilter userGroups, ContainsFilter users)
	{
		AllowHalfDay = allowHalfDay;
		AllowNegativeBalance = allowNegativeBalance;
		Approve = approve;
		Archived = archived;
		EveryoneIncludingNew = everyoneIncludingNew;
		Name = name;
		UserGroups = userGroups;
		Users = users;
	}
	
	public bool? AllowHalfDay { get; set; }
	public bool? AllowNegativeBalance { get; set; }
	public ApproveDto? Approve { get; set; }
	public bool? Archived { get; set; }
	public AutomaticAccrualRequest? AutomaticAccrual { get; set; }
	public AutomaticTimeEntryCreationRequest? AutomaticTimeEntryCreation { get; set; }
	public string? Color { get; set; }
	public bool? EveryoneIncludingNew { get; set; }
	public string? Name { get; set; }
	public NegativeBalanceRequest? NegativeBalance { get; set; }
	public TimeUnitEnum? TimeUnit { get; set; }
	public ContainsFilter? UserGroups { get; set; }
	public ContainsFilter? Users { get; set; }
}