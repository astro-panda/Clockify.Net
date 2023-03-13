using System.Collections.Generic;

namespace Clockify.Net.Models.Policies;

public class PolicyApprove
{
	public bool RequiresApproval { get; set; }
	public bool SpecificMembers { get; set; }
	public bool TeamManagers { get; set; }
	public IEnumerable<string> UserIds { get; set; }
}