using System.Collections.Generic;
using Clockify.Net.Models.Memberships;

namespace Clockify.Net.Models.Users {
	public class CurrentUserDto {
		public string ActiveWorkspace { get; set; }
		public string DefaultWorkspace { get; set; }
		public string Email { get; set; }
		public string ID { get; set; }
		public List<MembershipDto> Memberships { get; set; }
		public string Name { get; set; }
		public string ProfilePicture { get; set; }
		public UserSettingsDto Settings { get; set; }
		public UserStatus? Status { get; set; }
	}
}