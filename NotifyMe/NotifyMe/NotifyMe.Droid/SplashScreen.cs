using Android.App;
using Android.Content.PM;
using MvvmCross.Droid.Views;

namespace NotifyMe.Droid
{
    [Activity(
        Label = "NotifyMe.Native"
        , MainLauncher = true
        , Icon = "@drawable/envelope"
        , Theme = "@style/Theme.Splash"
        , NoHistory = true
        , ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreen : MvxSplashScreenActivity
    {
        public SplashScreen()
            : base(Resource.Layout.SplashScreen)
        {
        }
    }
}
