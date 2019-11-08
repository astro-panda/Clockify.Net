using System.Collections.Generic;

namespace Clockify.Net.Models.Workspaces {
	public class WorkspaceSettingsDto {
		public List<string> AdminOnlyPages { get; set; }
		public AutomaticClockDto AutomaticLock { get; set; }
		public string CanSeeTimeSheet { get; set; }
		public string DefaultBillableProjects { get; set; }
		public string ForceDescription { get; set; }
		public string ForceProjects { get; set; }
		public string ForceTags { get; set; }
		public string ForceTasks { get; set; }
		public string LockTimeEntries { get; set; }
		public string OnlyAdminsCreateProject { get; set; }
		public string OnlyAdminsCreateTag { get; set; }
		public string OnlyAdminsSeeAllTimeEntries { get; set; }
		public string OnlyAdminsSeeBillableRates { get; set; }
		public string OnlyAdminsSeeDashboard { get; set; }
		public string OnlyAdminsSeePublicProjectsEntries { get; set; }
		public string ProjectFavorites { get; set; }
		public string ProjectGroupingLabel { get; set; }
		public string ProjectPickerSpecialFilter { get; set; }
		public RoundDto RoundDto { get; set; }
		public string TimeRoundingInReports { get; set; }
		public string TrackTimeDownToSecond { get; set; }
	}
}