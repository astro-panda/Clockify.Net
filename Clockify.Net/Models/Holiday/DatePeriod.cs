using System;
using Newtonsoft.Json;

namespace Clockify.Net.Models.Holiday;

public class DatePeriod {
    [JsonIgnore]
    public DateTime? StartDate { get; set; }
    [JsonProperty("startDate")]
    public string StartDateJson
    {
        get => $"{StartDate:yyyy-MM-dd}";
        set => StartDate = DateTime.Parse(value);
    }

    [JsonIgnore]
    public DateTime? EndDate { get; set; }
    [JsonProperty("endDate")]
    public string EndDateJson
    {
        get => $"{EndDate:yyyy-MM-dd}";
        set => EndDate = DateTime.Parse(value);
    }
}