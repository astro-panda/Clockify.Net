using System.Collections.Generic;

namespace Clockify.Net.Models.Reports
{
    public class ProjectFilterDto
    {
        public ContainsType Contains { get; set; }
        public List<string> Ids { get; set; }
        public StatusType Status { get; set; }
    }
}