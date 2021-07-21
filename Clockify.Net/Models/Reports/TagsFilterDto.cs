using System.Collections.Generic;

namespace Clockify.Net.Models.Reports
{
    public class TagsFilterDto
    {
        public List<string> Ids { get; set; }
        public ContainedInTimeEntryType ContainedInTimeEntry {get; set;}
        public StatusType Status { get; set; }
    }
}