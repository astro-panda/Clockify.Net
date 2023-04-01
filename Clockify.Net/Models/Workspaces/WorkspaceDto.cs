using System.Collections.Generic;
using Clockify.Net.Models.HourlyRates;
using Clockify.Net.Models.Memberships;

namespace Clockify.Net.Models.Workspaces; 

public class WorkspaceDto
{
    public HourlyRateDto HourlyRate { get; set; }
    public string Id { get; set; }
    public string ImageUrl { get; set; }
    public List<MembershipDto> Memberships { get; set; }
    public string Name { get; set; }
    public WorkspaceSettingsDto WorkspaceSettings { get; set; }
}