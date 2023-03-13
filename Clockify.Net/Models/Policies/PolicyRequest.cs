using Clockify.Net.Models.Enums;

namespace Clockify.Net.Models.Policies;

public class PolicyRequest
{
	public bool? AllowHalfDay { get; set; }
	public bool? AllowNegativeBalance { get; set; }
	public PolicyApprove? Approve { get; set; }
	public bool? Archived { get; set; }
	public AutomaticAccrual? AutomaticAccrual { get; set; }
	public bool? EveryoneIncludingNew { get; set; }
	public string? Name { get; set; }
	public NegativeBalance? NegativeBalance { get; set; }
	public TimeUnitEnum? TimeUnit { get; set; }
	public ContainsFilter? UserGroups { get; set; }
	public ContainsFilter? Users { get; set; }
}