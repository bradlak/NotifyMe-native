using Newtonsoft.Json;

namespace NotifyMe.Models
{
	public class FacebookPicture
	{
		[JsonProperty("url")]
		public string Url { get; set; }
	}
}
