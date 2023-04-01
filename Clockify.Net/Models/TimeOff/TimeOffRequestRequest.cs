namespace Clockify.Net.Models.TimeOff; 

public class TimeOffRequestRequest
{
	public string? Note { get; set; }
	public TimeOffRequestPeriodV1Request? TimeOffPeriod { get; set; }
}