using System.Collections.Generic;
using Clockify.Net.Json.Converters;
using Newtonsoft.Json;

namespace Clockify.Net.Models.Reports; 

public class SummaryGroup {
	[JsonProperty("duration")]
	public long Duration { get; set; }

	[JsonProperty("amounts")]
	[JsonConverter(typeof(SingleOrArrayConverter<decimal>))]
	public List<decimal> Amounts { get; set; }

	[JsonProperty("_id")]
	[JsonConverter(typeof(SingleOrArrayConverter<string>))]
	public List<string> Id { get; set; }

	[JsonProperty("name")]
	public string Name { get; set; }

	[JsonProperty("nameLowerCase")]
	public string NameLowerCase { get; set; }

	[JsonProperty("color")]
	public string Color { get; set; }

	[JsonProperty("clientName")]
	public string ClientName { get; set; }

	public List<SummaryGroup> Children { get; set; }
}