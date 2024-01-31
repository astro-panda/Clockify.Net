using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Clockify.Net.Models.Users
{
    public enum RoleType
    {
        [EnumMember(Value = "WORKSPACE_ADMIN")]
        WORKSPACE_ADMIN,
        [EnumMember(Value = "OWNER")]
        OWNER,
        [EnumMember(Value = "TEAM_MANAGER")]
        TEAM_MANAGER,
        [EnumMember(Value = "PROJECT_MANAGER")]
        PROJECT_MANAGER
    }
}
