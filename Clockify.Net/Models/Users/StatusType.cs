using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Clockify.Net.Models.Users
{
    public enum StatusType
    {
        [EnumMember(Value = "PENDING")]
        PENDING,
        [EnumMember(Value = "ACTIVE")]
        ACTIVE,
        [EnumMember(Value = "DECLINED")]
        DECLINED,
        [EnumMember(Value = "INACTIVE")]
        INACTIVE,
        [EnumMember(Value = "ALL")]
        ALL
    }
}
