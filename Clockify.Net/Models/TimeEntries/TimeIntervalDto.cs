using System;

namespace Clockify.Net.Models.TimeEntries {
	public class TimeIntervalDto {
		/// <summary>
		/// Example: PT1H30M15S - 1 hour 30 minutes 15 seconds
		/// </summary>
		public string Duration { get; set; }
		public DateTimeOffset? End { get; set; }
		public DateTimeOffset? Start { get; set; }
	}
}