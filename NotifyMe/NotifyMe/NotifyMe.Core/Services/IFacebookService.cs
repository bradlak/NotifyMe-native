using NotifyMe.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotifyMe.Core.Services
{
    public interface IFacebookService
    {
        Task<IEnumerable<FacebookFriend>> GetFacebookFriends();

        Task<ApplicationUser> GetCurrentApplicationUser();
    }
}
