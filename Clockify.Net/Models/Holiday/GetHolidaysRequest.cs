using System;
using Newtonsoft.Json;

namespace Clockify.Net.Models.Holiday;

public class GetHolidaysRequest
{
    [JsonProperty("assigned-to")]
    public string AssignedTo { get; set; }
    public DateTime? Start { get; set; }
    public DateTime? End { get; set; }
}