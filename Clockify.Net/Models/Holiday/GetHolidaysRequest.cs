using System;
using Newtonsoft.Json;

namespace Clockify.Net.Models.Holiday;

public class GetHolidaysRequest
{
    /// <summary>
    /// For <see cref="ClockifyClient.GetHolidaysAsync"/>
    /// </summary>
    public GetHolidaysRequest()
    {
    }

    /// <summary>
    /// For <see cref="ClockifyClient.GetHolidayInSpecificPeriodAsync"/>
    /// </summary>
    public GetHolidaysRequest(string assignedTo, DateTime start, DateTime end)
    {
        AssignedTo = assignedTo;
        Start = start;
        End = end;
    }
    
    /// <summary>
    /// Assigned to User (ID)
    /// </summary>
    public string? AssignedTo { get; set; }
    public DateTime? Start { get; set; }
    public DateTime? End { get; set; }
}