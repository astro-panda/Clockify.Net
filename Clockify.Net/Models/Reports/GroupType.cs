using System.Runtime.Serialization;

namespace Clockify.Net.Models.Reports; 

public enum GroupType
{
    [EnumMember(Value = "PROJECT")]
    PROJECT,
    [EnumMember(Value = "CLIENT")]
    CLIENT,
    [EnumMember(Value = "TASK")]
    TASK,
    [EnumMember(Value = "TAG")]
    TAG,
    [EnumMember(Value = "DATE")]
    DATE,
    [EnumMember(Value = "USER")]
    USER,
    [EnumMember(Value = "USER_GROUP")]
    USER_GROUP,
    [EnumMember(Value = "TIMEENTRY")]
    TIMEENTRY
}