using Clockify.Net.Models.Enums;

namespace Clockify.Net.Models.Policies;

public class AutomaticAccrualDto
{
	public double? Amount { get; set; }
	public PeriodEnum? Period { get; set; }
	public TimeUnitEnum? TimeUnit { get; set; }
}