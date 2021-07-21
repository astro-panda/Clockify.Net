using System.Runtime.Serialization;

namespace Clockify.Net.Models.Reports
{
    public enum ContainsType
    {
        [EnumMember(Value = "CONTAINS")]
        CONTAINS,
        [EnumMember(Value = "DOES_NOT_CONTAIN")]
        DOES_NOT_CONTAIN
    }
}