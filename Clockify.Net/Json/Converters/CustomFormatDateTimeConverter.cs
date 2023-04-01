using Newtonsoft.Json.Converters;

namespace Clockify.Net.Json.Converters; 

public class CustomFormatDateTimeConverter : IsoDateTimeConverter
{
	public CustomFormatDateTimeConverter(string format)
	{
		DateTimeFormat = format;
	}
}