using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Platform;
using MvvmCross.Platform;
using Foundation;
using UIKit;
using NotifyMe.iOS.PlatformSpecific;

namespace NotifyMe.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : MvxApplicationDelegate
    {
        public override UIWindow Window
        {
            get;
            set;
        }

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Window = new UIWindow(UIScreen.MainScreen.Bounds);

            var setup = new Setup(this, Window);
            setup.Initialize();

            UINavigationBar.Appearance.BarTintColor = SharedColors.Background;
            UINavigationBar.Appearance.TintColor = UIColor.White;

            UITabBar.Appearance.BarTintColor = SharedColors.Background;
            UITabBar.Appearance.TintColor = UIColor.White;

            var startup = Mvx.Resolve<IMvxAppStart>();
            startup.Start();

            Window.MakeKeyAndVisible();

            return true;
        }
    }
}
