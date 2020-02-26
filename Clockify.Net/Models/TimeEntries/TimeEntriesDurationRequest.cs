using System;

namespace Clockify.Net.Models.TimeEntries
{
    public class TimeEntriesDurationRequest
    {
        public DateTimeOffset Start { get; set; }
        public DateTimeOffset End { get; set; }
    }
}