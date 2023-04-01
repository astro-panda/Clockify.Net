using System.Collections.Generic;
using Clockify.Net.Models.Memberships;
using Clockify.Net.Models.Reports;

namespace Clockify.Net.Api.User.Responses; 

public record UserDetails
{
    public string ActiveWorkspace { get; set; }
    public IEnumerable<UserCustomField> CustomFields { get; set; }
    public string DefaultWorkspace { get; set; }
    public string Email { get; set; }
    public string Id { get; set; }
    public List<MembershipDto> Memberships { get; set; }
    public string Name { get; set; }
    public string ProfilePicture { get; set; }
    public UserSettingsDto Settings { get; set; }
    public UserStatus Status { get; set; }
}