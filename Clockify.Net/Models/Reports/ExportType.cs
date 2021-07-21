using System.Runtime.Serialization;

namespace Clockify.Net.Models.Reports
{
    public enum ExportType
    {
        [EnumMember(Value = "JSON")]
        JSON,
        [EnumMember(Value = "CSV")]
        CSV,
        [EnumMember(Value = "XLSX")]
        XLSX,
        [EnumMember(Value = "PDF")]
        PDF
    }
}