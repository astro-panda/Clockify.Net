using System.Collections.Generic;
using Newtonsoft.Json;

namespace Clockify.Net.Models.Reports {
	public class SummaryGroup {
		[JsonProperty("duration")]
		public long Duration { get; set; }

		[JsonProperty("amount")]
		public decimal Amount { get; set; }

		[JsonProperty("_id")]
		public string Id { get; set; }

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
}