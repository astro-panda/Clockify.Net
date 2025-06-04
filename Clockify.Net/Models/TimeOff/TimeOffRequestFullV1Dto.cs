using System;
using Clockify.Net.Models.Enums;

namespace Clockify.Net.Models.TimeOff;

public class TimeOffRequestFullV1Dto
{
    public double Balance { get; set; }
    public double BalanceDiff { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Id { get; set; }
    public string Note { get; set; }
    public string PolicyId { get; set; }
    public string PolicyName { get; set; }
    public string RequesterUserId { get; set; }
    public string RequesterUserName { get; set; }
    public TimeOffRequestStatus Status { get; set; }
    public TimeOffRequestPeriodDto TimeOffPeriod { get; set; }
    public TimeUnitEnum TimeUnit { get; set; }
    public string UserEmail { get; set; }
    public string UserId { get; set; }
    public string UserName { get; set; }
    public string UserTimeZone { get; set; }
    public string WorkspaceId { get; set; }
}