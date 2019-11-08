using System.Collections.Generic;
using Clockify.Net.Models.Workspaces;

namespace Clockify.Net.Models.Users {
	public class CurrentUserDto {
		public string ActiveWorkspace { get; set; }
		public string DefaultWorkspace { get; set; }
		public string Email { get; set; }
		public string ID { get; set; }
		public List<MembershipDto> Memberships { get; set; }
		public string Name { get; set; }
		public string ProfilePicture { get; set; }
		public UserSettingsDto UserSettingsDto { get; set; }
		public UserStatus Status { get; set; }
	}

	public enum UserStatus {
		Active,
		PendingEmailVerification,
		Deleted
	}
}