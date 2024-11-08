using System;
using System.Collections.Generic;

namespace Clockify.Net.Models.Reports
{
    /// <summary>
    /// Request to get a time summary report and configures the response format.
    /// 
    /// <para>
    /// Requires calues for <see cref="DateRangeStart"/>, <see cref="DateRangeEnd"/>, and <see cref="SummaryFilter"/>
    /// </para>
    /// </summary>
    public class SummaryReportRequest
    {
        // REQUIRED
        /// <summary>
        /// The start of the date range in view for the summary report. REQUIRED
        /// </summary>
        public DateTimeOffset? DateRangeStart { get; set; }

        /// <summary>
        /// The end of the date range in view for the summary report. REQUIRED.
        /// 
        /// (This value will be transformed to the end of the date provided.)
        /// </summary>
        public DateTimeOffset? DateRangeEnd { get; set; }

        /// <summary>
        /// The filter object with information to control how the response is 
        /// grouped and displayed.
        /// </summary>
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
        public ClientsFilterDto Clients { get; set; }
        public string Projects { get; set; }
        public string Tasks { get; set; }
        public TagsFilterDto Tags { get; set; }
        public bool? Billable { get; set; }
        public string Description { get; set; }
        public bool? WithoutDescription { get; set; }
        public List<CustomFieldDto> CustomeFields { get; set; }
    }
}
