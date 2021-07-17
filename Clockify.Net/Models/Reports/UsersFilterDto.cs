using System.Collections.Generic;

namespace Clockify.Net.Models.Reports
{
    public class UsersFilterDto
    {
        public List<string> Ids { get; set; }
        public ContainsType Contains {get; set;}
        public UsersStatusType Status { get; set; }
    }
}