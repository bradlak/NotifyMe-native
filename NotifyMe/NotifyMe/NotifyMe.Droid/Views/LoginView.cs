using Android.App;
using Android.OS;
using Gcm.Client;
using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Analytics;
using Microsoft.Azure.Mobile.Crashes;
using MvvmCross.Core.Views;
using NotifyMe.Core.Infrastructure.Messages;
using NotifyMe.Core.ViewModels;
using NotifyMe.Droid;

namespace NotifyMe.Droid.Views
{
    [Activity]
    public class LoginView : BaseAppCompatActivity<LoginViewModel>
    {
        public LoginView() : base(Resource.Layout.LoginView)
        {
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            MobileCenter.Start("<your-mc-key>",
                   typeof(Analytics), typeof(Crashes));
            
            ViewModel.Messenger.Subscribe<RegistrationMessage>((obj) =>
            {
                GcmClient.CheckDevice(this);
                GcmClient.CheckManifest(this);

                GcmClient.Register(this, PushHandlerBroadcastReceiver.SenderIds);
            });
        }
    }
}
