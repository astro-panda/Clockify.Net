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
	public PolicyRequest(Approve approve, string name, TimeUnitEnum timeUnit, ContainsFilter? userGroups = null, ContainsFilter? users = null)
	: this(name, timeUnit, userGroups, users)
	{
		Approve = approve;
	}
	
	public bool? AllowHalfDay { get; set; }
	public bool? AllowNegativeBalance { get; set; }
	public Approve? Approve { get; set; }
	public bool? Archived { get; set; }
	public AutomaticAccrual? AutomaticAccrual { get; set; }
	public bool? EveryoneIncludingNew { get; set; }
	public string? Name { get; set; }
	public NegativeBalanceRequest? NegativeBalance { get; set; }
	public TimeUnitEnum? TimeUnit { get; set; }
	public ContainsFilter? UserGroups { get; set; }
	public ContainsFilter? Users { get; set; }
}