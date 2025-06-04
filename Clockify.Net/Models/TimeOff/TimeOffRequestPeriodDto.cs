namespace Clockify.Net.Models.TimeOff
{
    public class TimeOffRequestPeriodDto
    {
        public bool HalfDay { get; set; }
        public Period? HalfDayHours { get; set; }
        public string HalfDayPeriod { get; set; }
        public Period? Period { get; set; }
    }
}