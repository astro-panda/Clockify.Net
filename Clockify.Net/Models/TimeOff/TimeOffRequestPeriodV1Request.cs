namespace Clockify.Net.Models.TimeOff;

public class TimeOffRequestPeriodV1Request
{
	public string HalfDayPeriod { get; set; }
	public bool? IsHalfDay { get; set; }
	public DatePeriod? Period { get; set; }
}