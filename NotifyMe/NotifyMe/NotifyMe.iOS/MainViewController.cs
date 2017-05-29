using System;
using UIKit;
using MvvmCross.iOS.Views;
using NotifyMe.Core.ViewModels;
using MvvmCross.Core.ViewModels;

namespace NotifyMe.iOS
{
    [MvxFromStoryboard("ApplicationStoryboard")]
    public partial class MainViewController : MvxTabBarViewController<MainViewModel>
    {
        public MainViewController(IntPtr handle) : base(handle)
        {

        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            NavigationController.SetNavigationBarHidden(false, true);

            var viewControllers = new UIViewController[]
            {
                CreateTab(0, "Friends", "people", ViewModel.FriendsViewModel),
                CreateTab(1, "History", "history",ViewModel.HistoryViewModel),
             };

            ViewControllers = viewControllers;
            CustomizableViewControllers = new UIViewController[] { };

            SelectedViewController = ViewControllers[0];
        }

        private UIViewController CreateTab(int index, string title, string imageName, MvxViewModel vm)
        {
            var screen = this.CreateViewControllerFor(vm) as UIViewController;
            screen.TabBarItem = new UITabBarItem(title, UIImage.FromBundle(imageName), index);

            return screen;
        }
    }
}