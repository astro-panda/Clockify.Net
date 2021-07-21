using System.Runtime.Serialization;

namespace Clockify.Net.Models.Reports
{
    public enum StatusType
    {
        [EnumMember(Value = "ALL")]
        ALL,
        [EnumMember(Value = "ACTIVE")]
        ACTIVE,
        [EnumMember(Value = "ARCHIVED")]
        ARCHIVED
    }
}