using System.Collections.Generic;

namespace Clockify.Net.Models.Reports; 

public class SummaryFilterDto
{
    public List<GroupType> Groups { get; set; }

    // SETTINGS (OPTIONAL)
    public SortColumnType SortColumn {get; set;}
}