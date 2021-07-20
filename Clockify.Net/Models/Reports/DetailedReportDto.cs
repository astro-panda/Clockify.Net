using System.Collections.Generic;
using Clockify.Net.Models.HourlyRates;
using Clockify.Net.Models.Memberships;

namespace Clockify.Net.Models.Reports
{
    public class DetailedReportDto
    {
        public List<TotalsDto> Totals { get; set; }
        public List<TimeEntryDto> TimeEntries { get; set; }
    }
}