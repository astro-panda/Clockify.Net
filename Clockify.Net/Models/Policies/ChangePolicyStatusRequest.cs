using Clockify.Net.Models.Enums;

namespace Clockify.Net.Models.Policies;

public class ChangePolicyStatusRequest
{
	public StatusEnum Status { get; set; }
}