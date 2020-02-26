using System.Collections.Generic;

namespace Clockify.Net.Models.TimeEntries
{
    public class TimeEntryDtoImpl
    {
        public bool? Billable { get; set; }
        public string Description { get; set; }
        public string Id { get; set; }
        public bool? IsLocked { get; set; }
        public string ProjectId { get; set; }
        public List<string> TagIds { get; set; }
        public string TaskId { get; set; }
        public TimeIntervalDto TimeInterval { get; set; }
        public string UserId { get; set; }
        public string WorkspaceId { get; set; }
    }
}