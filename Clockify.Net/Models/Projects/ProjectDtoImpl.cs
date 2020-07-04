using System.Collections.Generic;
using Clockify.Net.Models.Estimates;
using Clockify.Net.Models.HourlyRates;
using Clockify.Net.Models.Memberships;

namespace Clockify.Net.Models.Projects
{
    public class ProjectDtoImpl
    {
        public bool? Archived { get; set; }
        public bool? Billable { get; set; }
        public string ClientId { get; set; }
        public string ClientName { get; set; }
        public string Color { get; set; }
        public string Duration { get; set; }
        public EstimateDto Estimate { get; set; }
        public HourlyRateDto HourlyRate { get; set; }
        public string Id { get; set; }
        public List<MembershipDto> Memberships { get; set; }
        public string Name { get; set; }
        public bool? Public { get; set; }
        public string WorkspaceId { get; set; }
        public string Note { get; set; }
    }
}