using System.Collections.Generic;
using Clockify.Net.Models.TimeEntries;

namespace Clockify.Net.Models.Reports
{
    public class TimeEntryDto
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public bool? Billable { get; set; }
        public string TaskId { get; set; }
        public string ProjectId { get; set; }
        public string ClientId { get; set; }
        public TimeIntervalDto TimeInterval { get; set; }
        public string ApprovalRequestId { get; set; }
        public string TaskName { get; set; }
        public List<string> Tags { get; set; }
        public bool? IsLocked { get; set; }
        public List<CustomFieldDto> CustomFields { get; set; }
        public InvoicingInfoDto InvoicingInfo { get; set; }
        public decimal Amount { get; set; }
        public decimal Rate { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string ProjectName { get; set; }
        public string ProjectColor { get; set; }
        public string ClientName { get; set; }
    }
}