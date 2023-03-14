using System;
using Newtonsoft.Json;

namespace Clockify.Net.Models.Holiday;

public class GetHolidaysRequest
{
    /// <summary>
    /// Assigned to User (ID)
    /// </summary>
    public string? AssignedTo { get; set; }
    public DateTime? Start { get; set; }
    public DateTime? End { get; set; }
}