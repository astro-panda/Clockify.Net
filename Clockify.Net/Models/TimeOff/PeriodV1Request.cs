using System;
using Newtonsoft.Json;

namespace Clockify.Net.Models.TimeOff;

public class PeriodV1Request
{
	public int? Days { get; set; }
        
	[JsonIgnore]
	public DateTime? Start { get; set; }

	[JsonProperty("start")]
	public string StartJson
	{
		get => $"{Start:yyyy-MM-dd}";
		set => Start = DateTime.Parse(value);
	}
        
	[JsonIgnore]
	public DateTime? End { get; set; }

	[JsonProperty("end")]
	public string EndJson
	{
		get => $"{End:yyyy-MM-dd}";
		set => End = DateTime.Parse(value);
	}
}