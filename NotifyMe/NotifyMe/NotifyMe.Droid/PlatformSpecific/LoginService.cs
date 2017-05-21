using System.Threading.Tasks;
using Android.App;
using Microsoft.WindowsAzure.MobileServices;
using MvvmCross.Platform.Droid.Platform;
using NotifyMe.Core.Infrastructure;

namespace NotifyMe.Droid
{
    public class LoginService : ILoginService
    {
        private MobileServiceClient client;

        private readonly Activity activity;

        public LoginService(IMvxAndroidCurrentTopActivity currentTop)
        {
            client = MobileServiceClientWrapper.Instance.Client;
            activity = currentTop.Activity;
        }

        public async Task<bool> Login()
        {
            var user = await client.LoginAsync(activity, MobileServiceAuthenticationProvider.Facebook);

            if (user != null)
            {
                await Task.Delay(100);
                return true;
            }

            return false;
        }
    }
}
