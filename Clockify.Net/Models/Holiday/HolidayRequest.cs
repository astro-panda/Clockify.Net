using System;

namespace Clockify.Net.Models.Holiday;

public class HolidayRequest
{
	public DatePeriod? DatePeriod { get; set; }
	public bool? EveryoneIncludingNew { get; set; }

	private string? _name;
	public string? Name
	{
		get => _name;
		set
		{
			if (value == null)
			{
				_name = null;
				return;
			}
			if (value.Length is < 2 or > 50)
				throw new ArgumentOutOfRangeException("Value must be between 2 and 50 characters");
			_name = value;
		}
	}
	public bool? OccursAnnually { get; set; }
	public ContainsFilter? UserGroups { get; set; }
	public ContainsFilter? Users { get; set; }
}