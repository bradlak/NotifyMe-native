using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using NotifyMe.Core.Infrastructure;
using UIKit;

namespace NotifyMe.iOS.PlatformSpecific
{
    public class LoginService : ILoginService
    {
        private MobileServiceClient client;

        public LoginService()
        {
            client = MobileServiceClientWrapper.Instance.Client;
        }

        public async Task<bool> Login()
        {
            var user = await client.LoginAsync(
                 UIApplication.SharedApplication.KeyWindow.RootViewController,
                 MobileServiceAuthenticationProvider.Facebook);

            if (user != null)
            {
                await Task.Delay(100);
                return true;
            }

            return false;
        }
    }
}