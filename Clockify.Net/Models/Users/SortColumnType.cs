using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Clockify.Net.Models.Users
{
    public enum SortColumnType
    {
        [EnumMember(Value = "ID")]
        ID,
        [EnumMember(Value = "EMAIL")]
        EMAIL,
        [EnumMember(Value = "NAME")]
        NAME,
        [EnumMember(Value = "NAME_LOWERCASE")]
        NAME_LOWERCASE,
        [EnumMember(Value = "ACCESS")]
        ACCESS,
        [EnumMember(Value = "HOURLYRATE")]
        HOURLYRATE,
        [EnumMember(Value = "COSTRATE")]
        COSTRATE
    }
}
