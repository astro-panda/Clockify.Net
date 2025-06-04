using System.Collections.Generic;
using Clockify.Net.Models.Enums;

namespace Clockify.Net.Models.Policies;

public class PolicyDto
{
	public bool AllowHalfDay { get; set; }
	public bool AllowNegativeBalance { get; set; }
	public ApproveDto Approve { get; set; }
	public bool Archived { get; set; }
	public AutomaticAccrualDto AutomaticAccrual { get; set; }
	public AutomaticTimeEntryCreationDto AutomaticTimeEntryCreation { get; set; }
	public bool EveryoneIncludingNew { get; set; }
	public string Id { get; set; }
	public string Name { get; set; }
	public NegativeBalanceDto NegativeBalance { get; set; }
	public string ProjectId { get; set; }
	public TimeUnitEnum TimeUnit { get; set; }
	public IEnumerable<string> UserGroupIds { get; set; }
	public IEnumerable<string> UserIds { get; set; }
	public string WorkspaceId { get; set; }
}