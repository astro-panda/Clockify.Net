namespace Clockify.Net.Models.Holiday;

public class HolidayRequest
{
	public DatePeriod? DatePeriod { get; set; }
	public bool? EveryoneIncludingNew { get; set; }
	public string? Name { get; set; }
	public bool? OccursAnnually { get; set; }
	public ContainsFilter? UserGroups { get; set; }
	public ContainsFilter? Users { get; set; }
}