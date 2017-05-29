using System;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using NotifyMe.Core.ViewModels;
using NotifyMe.iOS.PlatformSpecific;
using NotifyMe.iOS.ViewControllers;
using UIKit;

namespace NotifyMe.iOS
{
    [MvxFromStoryboard("ApplicationStoryboard")]
    public partial class LoginViewController : BaseViewController<LoginViewModel>
    {
        public LoginViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            NavigationController.SetNavigationBarHidden(true, true);

            var set = this.CreateBindingSet<LoginViewController, LoginViewModel>();
            set.Bind(loginButton).To(vm => vm.LoginCommand);
            set.Apply();

            NavigationController.TopViewController.NavigationItem.BackBarButtonItem =
                new UIBarButtonItem("Logout", UIBarButtonItemStyle.Plain, (sender, e) => { ViewModel.ExitCommand.Execute(); });
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            NavigationController.SetNavigationBarHidden(true, true);
        }
    }
}