using Android.App;
using Android.OS;
using MvvmCross.Core.Views;
using NotifyMe.Core.ViewModels;

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
        }
    }
}
