using System.Collections.Generic;

namespace Clockify.Net.Models.Reports
{
    public class InvoicingInfoDto
    {
        public string InvoiceId { get; set; }
        public string InvoiceNumber { get; set; }
        public bool? ManuallyInvoiced { get; set; }
    }
}