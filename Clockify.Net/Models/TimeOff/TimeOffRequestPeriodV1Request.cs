using Clockify.Net.Models.Enums;

namespace Clockify.Net.Models.TimeOff;

public class TimeOffRequestPeriodV1Request
{
	public HalfDayPeriodEnum? HalfDayPeriod { get; set; }
	public bool? IsHalfDay { get; set; }
	public PeriodV1Request? Period { get; set; }
	public HalfDayPeriodEnum? TimeOffHalfDayPeriod { get; set; }
}