using System;
using Clockify.Net.Json.Converters;
using Newtonsoft.Json;

namespace Clockify.Net.Models.Holiday; 

public class DatePeriod {
    [JsonConverter(typeof(CustomFormatDateTimeConverter), "yyyy-MM-dd")]
    public DateTime? StartDate { get; set; }
    [JsonConverter(typeof(CustomFormatDateTimeConverter), "yyyy-MM-dd")]
    public DateTime? EndDate { get; set; }
}