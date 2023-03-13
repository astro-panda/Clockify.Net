using System;

namespace Clockify.Net.Models.TimeOff
{
    public class DatePeriod {
        public int Days { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}