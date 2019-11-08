namespace Clockify.Net.Models.Workspaces {
	public class AutomaticClockDto {
		public string ChangeDay { get; set; }
		public string DayOfMonth { get; set; }
		public string FirstDay { get; set; }
		public string OlderThanPeriod { get; set; }
		public string OlderThanValue { get; set; }
		public string Type { get; set; }
	}
}