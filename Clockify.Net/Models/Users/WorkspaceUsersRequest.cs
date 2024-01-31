using Clockify.Net.Models.Reports;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Clockify.Net.Models.Users
{
    public class WorkspaceUsersRequest
    {
        // SETTINGS (OPTIONAL)
        public string Email { get; set; }

        public bool IncludeRoles { get; set; }

        public string Memberships { get; set; }

        public string Name { get; set; }

        public int Page { get; set; }

        public int PageSize { get; set; }

        public string ProjectId { get; set; }

        public List<RoleType> Roles { get; set; }

        public SortColumnType SortColumn { get; set; }

        public SortOrderType SortOrder { get; set; }

        public StatusType Status { get; set; }

        public List<string> UserGroups { get; set; }

    }
}
