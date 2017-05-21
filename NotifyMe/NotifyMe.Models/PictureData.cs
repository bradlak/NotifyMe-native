using Newtonsoft.Json;

namespace NotifyMe.Models
{
    public class PictureData
    {
        [JsonProperty("data")]
        public FacebookPicture Picture { get; set; }
    }
}
