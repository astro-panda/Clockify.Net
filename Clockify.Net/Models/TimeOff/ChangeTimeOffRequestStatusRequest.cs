using Clockify.Net.Models.Enums;

namespace Clockify.Net.Models.TimeOff;

public class ChangeTimeOffRequestStatusRequest
{
	public string Note { get; set; }
	public StatusEnum Status { get; set; }
}