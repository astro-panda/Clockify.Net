using System;

namespace Clockify.Net.Models.TimeOff
{
    public class TimeOffRequestStatus
    {
        public DateTime ChangedAt { get; set; }
        public string ChangedByUserName { get; set; }
        public string Note { get; set; }
        public TimeOffRequestStatusType StatusType { get; set; }
    }
}