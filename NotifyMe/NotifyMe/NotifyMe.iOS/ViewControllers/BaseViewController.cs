using System;
using CoreGraphics;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Views;
using NotifyMe.Core.ViewModels;
using UIKit;

namespace NotifyMe.iOS.ViewControllers
{
    public class BaseViewController<TViewModel> : MvxViewController where TViewModel : BaseViewModel
	{
        private MvxPropertyChangedListener busyListener;

        public BaseViewController(IntPtr handle) : base(handle)
		{
		}

        public new TViewModel ViewModel
        {
            get
            {
                return (TViewModel)base.ViewModel;
            }
            set
            {
                base.ViewModel = value;
            }
        }


        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            busyListener = new MvxPropertyChangedListener(ViewModel).Listen(() => ViewModel.IsBusy, (sender, e) =>
            {
                var indicator = new UIActivityIndicatorView(new CGRect(0, 0, 20, 20));
                var button = new UIBarButtonItem(indicator);

                if (ViewModel.IsBusy)
                {
                    NavigationController.TopViewController.NavigationItem.SetRightBarButtonItem(button, true);
                    indicator.StartAnimating();
                }
                else
                {
                    NavigationController.TopViewController.NavigationItem.RightBarButtonItem = null;
                    indicator.StopAnimating();
                }
            });
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            ViewModel.ResumeCommand.Execute();
        }
	}
}
