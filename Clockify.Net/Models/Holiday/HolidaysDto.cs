using System.Collections.Generic;
using Newtonsoft.Json;

namespace Clockify.Net.Models.Holidays
{
    public class HolidaysDto
    {
        public Period DatePeriod { get; set; }
        public bool EveryoneIsIncludedNew { get; set; }    
        public string Id { get; set; }
        public string Name { get; set; }
        public bool OccursAnnually { get; set; }
        public IEnumerable<string> UserGroupIds { get; set; }
        public IEnumerable<string> UserIds { get; set; }
        public string WorkspaceId { get; set; }
    }
}