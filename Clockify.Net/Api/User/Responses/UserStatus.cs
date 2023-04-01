using System.Runtime.Serialization;

namespace Clockify.Net.Api.User.Responses; 

public enum UserStatus
{
    [EnumMember(Value = "ACTIVE")]
    Active,
    [EnumMember(Value = "PENDING_EMAIL_VERIFICATION")]
    PendingEmailVerification,
    [EnumMember(Value = "DELETED")]
    Deleted,
    [EnumMember(Value = "DECLINED")]
    Declined,
    [EnumMember(Value = "INACTIVE")]
    Inactive,
    [EnumMember(Value = "NOT_REGISTERED")]
    NotRegistered,
    [EnumMember(Value = "LIMITED")]
    Limited,
    [EnumMember(Value = "LIMITED_DELETED")]
    LimitedDeleted
}