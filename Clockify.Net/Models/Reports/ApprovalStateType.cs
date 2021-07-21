using System.Runtime.Serialization;

namespace Clockify.Net.Models.Reports
{
    public enum ApprovalStateType
    {
        [EnumMember(Value = "APPROVED")]
        APPROVED,
        [EnumMember(Value = "UNAPPROVED")]
        UNAPPROVED,
        [EnumMember(Value = "ALL")]
        ALL
    }
}