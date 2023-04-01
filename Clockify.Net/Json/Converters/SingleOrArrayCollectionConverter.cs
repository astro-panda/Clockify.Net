using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Clockify.Net.Json.Converters; 

public class SingleOrArrayConverter<T> : JsonConverter {
	public override bool CanConvert(Type objectType) {
		return objectType == typeof(List<T>);
	}

	public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
	                                JsonSerializer serializer) {
		var token = JToken.Load(reader);
		if (token.Type == JTokenType.Array) {
			return token.ToObject<List<T>>();
		}

		return new List<T> { token.ToObject<T>() };
	}

	public override bool CanWrite => false;

	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
		throw new NotImplementedException();
	}
}