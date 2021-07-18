using System.Runtime.Serialization;

namespace Clockify.Net.Models.Reports
{
    public enum InvoicingStateType
    {
        [EnumMember(Value = "ALL")]
        ALL,
        [EnumMember(Value = "INVOICED")]
        INVOICED,
        [EnumMember(Value = "UNINVOICED")]
        UNINVOICED
    }
}