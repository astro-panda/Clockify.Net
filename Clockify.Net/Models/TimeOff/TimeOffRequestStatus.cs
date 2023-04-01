using System;

namespace Clockify.Net.Models.TimeOff; 

public class TimeOffRequestStatus
{
	public DateTime ChangedAt { get; set; }
	public string ChangedByUserId { get; set; }
	public string ChangedByUserName { get; set; }
	public string Note { get; set; }
	public string StatusType { get; set; }
}