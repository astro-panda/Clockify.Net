using System;
using System.Collections.Generic;
using System.Text;

namespace Clockify.Net.Models.Users
{
    public class UserRolesDto
    {
        public string FormatterRoleName { get; set; }
        public string Role { get; set; }

        public List<Entities> Entities { get; set; } = [];

    }

    public class Entities
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
