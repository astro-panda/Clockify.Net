using System.Runtime.Serialization;

namespace Clockify.Net.Models.Users
{
    public enum UserStatus
    {
        [EnumMember(Value = "ACTIVE")]
        Active,
        [EnumMember(Value = "PENDING_EMAIL_VERIFICATION")]
        PendingEmailVerification,
        [EnumMember(Value = "DeleteD")]
        Deleted,
        [EnumMember(Value = "DECLINED")]
        Declined,
        [EnumMember(Value = "INACTIVE")]
        Inactive,
        [EnumMember(Value = "NOT_REGISTERED")]
        NotRegistered
    }
}