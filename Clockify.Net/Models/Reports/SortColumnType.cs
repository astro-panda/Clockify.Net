using System.Runtime.Serialization;

namespace Clockify.Net.Models.Reports; 

public enum SortColumnType
{
    [EnumMember(Value = "GROUP")]
    GROUP,
    [EnumMember(Value = "DURATION")]
    DURATION,
    [EnumMember(Value = "AMOUNT")]
    AMOUNT,
    [EnumMember(Value = "DATE")]
    DATE
}