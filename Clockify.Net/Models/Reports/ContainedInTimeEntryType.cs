using System.Runtime.Serialization;

namespace Clockify.Net.Models.Reports
{
    public enum ContainedInTimeEntryType
    {
        [EnumMember(Value = "CONTAINS")]
        CONTAINS,
        [EnumMember(Value = "CONTAINS_ONLY")]
        CONTAINS_ONLY,
        [EnumMember(Value = "DOES_NOT_CONTAIN")]
        DOES_NOT_CONTAIN
    }
}