using Newtonsoft.Json;

namespace Clockify.Net.Models.Reports
{
    public class TagDto
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}