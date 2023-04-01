using System.Collections.Generic;

namespace Clockify.Net.Models.Reports; 

public class DetailedFilterDto
{
    public int Page { get; set; }
    public int PageSize {get; set;}

    // SETTINGS (OPTIONAL)
    public SortColumnType SortColumn { get; set; }
    public OptionsDto Options { get; set; }
    public AuditFilterDto AuditFilter { get; set; }
}