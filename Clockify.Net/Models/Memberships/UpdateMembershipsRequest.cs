using System.Collections.Generic;
using Clockify.Net.Models.HourlyRates;

namespace Clockify.Net.Models.Memberships
{
    public class UpdateMembershipsRequest
    {
        public IReadOnlyCollection<UpdateMembershipRequest> Memberships { get; set; }
    }
}