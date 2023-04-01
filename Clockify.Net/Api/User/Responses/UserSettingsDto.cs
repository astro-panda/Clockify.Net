namespace Clockify.Net.Api.User.Responses; 

public class UserSettingsDto
{
    public bool? CollapseAllProjectLists { get; set; }
    public bool? DashboardPinToTop { get; set; }
    public DashboardSelection? DashboardSelection { get; set; }
    public DashboardViewType? DashboardViewType { get; set; }
    public string DateFormat { get; set; }
    public bool? IsCompactViewOn { get; set; }
    public bool? LongRunning { get; set; }
    public string ProjectListCollapse { get; set; }
    public bool? SendNewsletter { get; set; }
    public SummaryReportSettingsDto SummaryReportSettingsDto { get; set; }
    public string TimeFormat { get; set; }
    public bool? TimeTrackingManual { get; set; }
    public string TimeZone { get; set; }
    public Week? Week { get; set; }
    public bool? WeeklyUpdates { get; set; }
}

public enum Week
{
    Monday,
    Tuesday,
    Wednesday,
    Thursday,
    Friday,
    Saturday,
    Sunday
}

public enum DashboardViewType
{
    Project,
    Billability
}

public enum DashboardSelection
{
    Me,
    Team
}