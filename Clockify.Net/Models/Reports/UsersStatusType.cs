using System.Runtime.Serialization;

namespace Clockify.Net.Models.Reports; 

public enum UsersStatusType
{
    [EnumMember(Value = "All")]
    ALL,
    [EnumMember(Value = "ACTIVE")]
    ACTIVE,
    [EnumMember(Value = "INACTIVE")]
    INACTIVE
}