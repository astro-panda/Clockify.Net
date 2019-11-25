using System;
using System.Collections.Generic;

namespace Clockify.Net.Models.TimeEntries {
	public class UpdateTimeEntryRequest {
		public DateTimeOffset? Start { get; set; }
		public bool? Billable { get; set; }
		public string Description { get; set; }
		public string ProjectId { get; set; }
		public string TaskId { get; set; }
		public DateTimeOffset? End { get; set; }
		public List<string> TagIds { get; set; }
	}
}