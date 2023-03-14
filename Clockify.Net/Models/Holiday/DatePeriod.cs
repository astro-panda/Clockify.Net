using System;
using Newtonsoft.Json;

namespace Clockify.Net.Models.Holiday;

public class DatePeriod {
    [JsonIgnore]
    public DateTime? StartDate { get; set; }
    [JsonProperty("startDate")]
    public string StartDateJson => $"{StartDate:yyyy-MM-dd}";
        
    [JsonIgnore]
    public DateTime? EndDate { get; set; }
    [JsonProperty("endDate")]
    public string EndDateJson => $"{EndDate:yyyy-MM-dd}";
}