using System.Collections.Generic;

namespace Clockify.Net.Models.Reports
{
    public class SummaryReportRequest
    {
        // REQUIRED
        public string DateRangeStart { get; set; }
        public string DateRangeEnd { get; set; }
        public SummaryFilterDto SummaryFilter { get; set; }

        // SETTINGS (OPTIONAL)
        public SortOrderType SortOrder { get; set; }
        public ExportType ExportType { get; set; }
        public bool? Rounding { get; set; }
        public AmountShownType AmountShown { get; set; }
        public string TimeZone { get; set; }

        // FILTERS (OPTIONAL)
        public UsersFilterDto Users { get; set; }
        public InvoicingStateType InvoicingState { get; set; }
        public ApprovalStateType ApprovalState { get; set; }
        public string UserGroups { get; set; }
        public string Clients { get; set; }
        public string Projects { get; set; }
        public string Tasks { get; set; }
        public TagsFilterDto Tags { get; set; }
        public bool? Billable { get; set; }
        public string Description { get; set; }
        public bool? WithoutDescription { get; set; }
        public List<CustomFieldDto> CustomeFields { get; set; }
    }
}