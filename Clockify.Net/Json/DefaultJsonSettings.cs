using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Clockify.Net.Json; 

internal sealed class DefaultJsonSettings {
	internal static readonly JsonSerializerSettings Settings = new() {
		NullValueHandling = NullValueHandling.Ignore,

		Converters = new List<JsonConverter> {
			new StringEnumConverter(),
			new IsoDateTimeConverter {
				DateTimeFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'ss'Z'"
			}
		},
		ContractResolver = new CamelCasePropertyNamesContractResolver()
	};
}