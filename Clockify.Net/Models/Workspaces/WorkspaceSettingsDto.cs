using System.Collections.Generic;

namespace Clockify.Net.Models.Workspaces
{
    public class WorkspaceSettingsDto
    {
        public List<AdminOnlyPages>? AdminOnlyPages { get; set; }
        public AutomaticLockDto? AutomaticLock { get; set; }
        public bool? CanSeeTimeSheet { get; set; }
        public bool? DefaultBillableProjects { get; set; }
        public bool? ForceDescription { get; set; }
        public bool? ForceProjects { get; set; }
        public bool? ForceTags { get; set; }
        public bool? ForceTasks { get; set; }
        public string? LockTimeEntries { get; set; }
        public bool? OnlyAdminsCreateProject { get; set; }
        public bool? OnlyAdminsCreateTag { get; set; }
        public bool? OnlyAdminsSeeAllTimeEntries { get; set; }
        public bool? OnlyAdminsSeeBillableRates { get; set; }
        public bool? OnlyAdminsSeeDashboard { get; set; }
        public bool? OnlyAdminsSeePublicProjectsEntries { get; set; }
        public bool? ProjectFavorites { get; set; }
        public string? ProjectGroupingLabel { get; set; }
        public bool? ProjectPickerSpecialFilter { get; set; }
        public RoundDto? RoundDto { get; set; }
        public bool? TimeRoundingInReports { get; set; }
        public bool? TrackTimeDownToSecond { get; set; }
    }

    public enum AdminOnlyPages
    {
        Project,
        Team,
        Reports
    }
}