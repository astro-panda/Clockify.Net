using System.Collections.Generic;

namespace Clockify.Net.Models.Workspaces {
	public class WorkspaceDto {
		public HourlyRateDto HourlyRate { get; set; }
		public string Id { get; set; }
		public string ImageUrl { get; set; }
		public List<MembershipDto> Memberships { get; set; }
		public string Name { get; set; }
		public WorkspaceSettingsDto WorkspaceSettings { get; set; }
	}

	public class HourlyRateDto {
		public string Amount { get; set; }
		public string Currency { get; set; }
	}

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

	public class AutomaticClockDto {
		public string ChangeDay { get; set; }
		public string DayOfMonth { get; set; }
		public string FirstDay { get; set; }
		public string OlderThanPeriod { get; set; }
		public string OlderThanValue { get; set; }
		public string Type { get; set; }
	}

	public class RoundDto {
		public string Minutes { get; set; }
		public string Round { get; set; }
	}

	public class MembershipDto {
		public HourlyRateDto HourlyRate { get; set; }
		public MembershipStatus MembershipStatus { get; set; }
		public string MembershipType { get; set; }
		public string TargetId { get; set; }
		public string UserId { get; set; }
	}

	public enum MembershipStatus {
		PENDING,
		ACTIVE,
		DECLINED,
		INACTIVE
	}
}