using Clockify.Net.Models.Users;

namespace Clockify.Net.Models.Workspaces
{
    public class AutomaticLockDto
    {
        public Week? ChangeDay { get; set; }
        public int? DayOfMonth { get; set; }
        public Week? FirstDay { get; set; }
        public OlderThanPeriod? OlderThanPeriod { get; set; }
        public int? OlderThanValue { get; set; }
        public AutomaticLockType Type { get; set; }
    }

    public enum AutomaticLockType
    {
        Weekly,
        Monthly,
        Older_Than
    }

    public enum OlderThanPeriod
    {
        Days,
        Weeks,
        Months
    }
}