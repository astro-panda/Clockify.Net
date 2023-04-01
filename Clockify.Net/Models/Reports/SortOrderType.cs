using System.Runtime.Serialization;

namespace Clockify.Net.Models.Reports; 

public enum SortOrderType
{
    [EnumMember(Value = "ASCENDING")]
    ASCENDING,
    [EnumMember(Value = "DESCENDING")]
    DESCENDING
}