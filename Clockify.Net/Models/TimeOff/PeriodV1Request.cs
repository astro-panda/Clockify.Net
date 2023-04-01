using System;
using Clockify.Net.Json.Converters;
using Newtonsoft.Json;

namespace Clockify.Net.Models.TimeOff;

public class PeriodV1Request
{
	public int? Days { get; set; }

	[JsonConverter(typeof(CustomFormatDateTimeConverter), "yyyy-MM-dd")]
	public DateTime? Start { get; set; }

	[JsonConverter(typeof(CustomFormatDateTimeConverter), "yyyy-MM-dd")]
	public DateTime? End { get; set; }
}