using System.Collections.Generic;

namespace Clockify.Net.Models.TimeOff
{
    public class TimeOffRequestResponse {
        public int Count { get; set; }
        public IEnumerable<TimeOffRequestFullV1Dto> Requests { get; set; }
    }
}