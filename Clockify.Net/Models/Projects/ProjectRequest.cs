using System.Collections.Generic;
using System.Drawing;
using Clockify.Net.Models.Estimates;
using Clockify.Net.Models.HourlyRates;
using Clockify.Net.Models.Memberships;
using Clockify.Net.Models.Tasks;
using Clockify.Net.Models.Workspaces;

namespace Clockify.Net.Models.Projects {
	public class ProjectRequest {
		public string Name { get; set; }
		public string ClientId { get; set; }
		public bool? IsPublic { get; set; }
		public EstimateRequest Estimate { get; set; }
		/// <summary>
		/// Should be in HEX "#FF00FF"
		/// </summary>
		public string Color { get; set; }
		public bool? Billable { get; set; }
		public HourlyRateRequest HourlyRate { get; set; }
		public List<MembershipRequest> Memberships { get; set; }
		public List<TaskRequest> Tasks { get; set; }
	}
}