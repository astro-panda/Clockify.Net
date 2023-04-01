using System.Runtime.Serialization;

namespace Clockify.Net.Models.Reports; 

public enum AmountShownType
{
    [EnumMember(Value = "HIDE_AMOUNT")]
    HIDE_AMOUNT,
    [EnumMember(Value = "EARNED")]
    EARNED,
    [EnumMember(Value = "COST")]
    COST,
    [EnumMember(Value = "PROFIT")]
    PROFIT
}