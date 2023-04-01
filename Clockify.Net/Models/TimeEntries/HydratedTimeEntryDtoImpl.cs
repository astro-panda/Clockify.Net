using System.Collections.Generic;
using Clockify.Net.Models.HourlyRates;
using Clockify.Net.Models.Projects;
using Clockify.Net.Models.Tags;
using Clockify.Net.Models.Tasks;
using Clockify.Net.Models.Users;

namespace Clockify.Net.Models.TimeEntries; 

public class HydratedTimeEntryDtoImpl
{
    public string Id { get; set; }
    public string Description { get; set; }
    public List<TagDto> Tags { get; set; }
    public UserDto User { get; set; }
    public bool Billable { get; set; }
    public TaskDto Task { get; set; }
    public ProjectDtoImpl Project { get; set; }
    public TimeIntervalDto TimeInterval { get; set; }
    public string WorkspaceId { get; set; }
    public HourlyRateDto HourlyRate { get; set; }
    public string UserId { get; set; }
    public string ProjectId { get; set; }
    public bool IsLocked { get; set; }
}