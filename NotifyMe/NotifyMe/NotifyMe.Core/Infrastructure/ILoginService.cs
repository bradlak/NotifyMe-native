using System.Threading.Tasks;

namespace NotifyMe.Core.Infrastructure
{
    public interface ILoginService
    {
       Task<bool> Login();
    }
}
