using NotifyMe.Models;

namespace NotifyMe.Core.Services
{
	public interface IApplicationCache
	{
		FacebookFriend SelectedFriend { get; set; }

        ApplicationUser CurrentUser { get; set; }
	}
}
