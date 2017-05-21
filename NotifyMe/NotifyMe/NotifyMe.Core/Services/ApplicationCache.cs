using NotifyMe.Models;

namespace NotifyMe.Core.Services
{
    public class ApplicationCache : IApplicationCache
    {
        public ApplicationUser CurrentUser { get; set; }

        public FacebookFriend SelectedFriend { get; set; }
    }
}
