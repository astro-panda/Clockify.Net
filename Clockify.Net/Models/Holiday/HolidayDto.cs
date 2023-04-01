using System.Collections.Generic;

namespace Clockify.Net.Models.Holiday; 

public class HolidayDto
{
    public DatePeriod DatePeriod { get; set; }
    public bool EveryoneIncludingNew { get; set; }    
    public string Id { get; set; }
    public string Name { get; set; }
    public bool OccursAnnually { get; set; }
    public IEnumerable<string> UserGroupIds { get; set; }
    public IEnumerable<string> UserIds { get; set; }
    public string WorkspaceId { get; set; }
}