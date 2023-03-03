using System.Collections.Generic;

namespace Clockify.Net.Models.TimeOff
{
    public class TimeOffRequestResponse {
        public int Count { get; set; }
        public List<TimeOffRequestFullDtoV1> Requests { get; set; }
    }
}