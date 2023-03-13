namespace Clockify.Net.Models.TimeOff
{
    public class TimeOffRequestPeriod
    {
        public bool HalfDay { get; set; }
        public DatePeriod HalfDayHours { get; set; }
        public string? HalfDayPeriod { get; set; }
        public DatePeriod DatePeriod { get; set; }
    }
}