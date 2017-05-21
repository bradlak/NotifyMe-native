using Newtonsoft.Json;
using System.Collections.Generic;

namespace NotifyMe.Models
{
    public class FriendsResponse
    {
        [JsonProperty("data")]
        public List<FacebookFriend> Friends { get; set; }

        [JsonProperty("summary")]
        public Summary Summary { get; set; }
    }
}
