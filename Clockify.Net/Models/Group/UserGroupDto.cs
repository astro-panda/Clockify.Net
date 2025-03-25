using System.Collections.Generic;

using Clockify.Net.Models.Memberships;

namespace Clockify.Net.Models.Users
{
    public class UserGroupDto
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? WorkspaceId { get; set; }
        public List<string> UserIds { get; set; } = [];
    }
}