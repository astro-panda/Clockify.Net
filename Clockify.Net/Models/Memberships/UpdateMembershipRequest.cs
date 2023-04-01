using System.Collections.Generic;
using Clockify.Net.Models.HourlyRates;

namespace Clockify.Net.Models.Memberships; 

public class UpdateMembershipRequest
{
    public HourlyRateRequest HourlyRate { get; set; }
    public string UserId { get; set; }
}