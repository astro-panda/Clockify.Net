using System.Collections.Generic;
using Clockify.Net.Models.Interfaces;

namespace Clockify.Net.Models.TimeOff
{
    public class TimeOffRequestResponse : IHasCount {
        public int Count { get; set; }
        public IEnumerable<TimeOffRequestFullDtoV1> Requests { get; set; }
    }
}