using System.Collections.Generic;

namespace Clockify.Net.Models.Reports
{
    public class AuditFilterDto
    {
        public bool? WithoutProject { get; set; }
        public bool? WithoutTask { get; set; }
        public int Duration { get; set; }
        public bool? DurationShorter { get; set; }
    }
}