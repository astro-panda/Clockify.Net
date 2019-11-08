namespace Clockify.Net.Models.Workspaces {
	public class MembershipDto {
		public HourlyRateDto HourlyRate { get; set; }
		public MembershipStatus MembershipStatus { get; set; }
		public string MembershipType { get; set; }
		public string TargetId { get; set; }
		public string UserId { get; set; }
	}

	public enum MembershipStatus {
		Pending,
		Active,
		Declined,
		Inactive
	}
}