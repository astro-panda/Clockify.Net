using Newtonsoft.Json;

namespace Clockify.Net.Models.Holidays
{
    public class GetHolidaysRequestParams
    {
        [JsonProperty("assigned-to")]
        public string AssignedTo { get; set; }
    }
}