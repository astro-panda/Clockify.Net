using System;
using System.Collections.Generic;

namespace Clockify.Net.Models.TimeOff
{
    public class TimeOffEndpointRequest
    {
        public DateTime End { get; set; }
        public DateTime Start { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public IEnumerable<TimeOffRequestStatusType> Statuses { get; set; }
        public IEnumerable<string> UserGroups { get; set; }
        public IEnumerable<string> Users { get; set; }
    }
}