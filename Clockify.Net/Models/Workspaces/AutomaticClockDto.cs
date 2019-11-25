using Clockify.Net.Models.Users;

namespace Clockify.Net.Models.Workspaces {
	public class AutomaticClockDto {
		public Week? ChangeDay { get; set; }
		public int? DayOfMonth { get; set; }
		public Week? FirstDay { get; set; }
		public OlderThanPeriod? OlderThanPeriod { get; set; }
		public int? OlderThanValue { get; set; }
		public AutomaticClockType Type { get; set; }
	}

	public enum AutomaticClockType {
		Weekly,
		Monthly,
		OlderThan
	}

	public enum OlderThanPeriod {
		Days,
		Weeks,
		Months
	}
}