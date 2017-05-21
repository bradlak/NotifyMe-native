using Newtonsoft.Json;

namespace NotifyMe.Models
{
    public class Summary
    {
        [JsonProperty("total_count")]
        public int Total { get; set; }
    }
}
