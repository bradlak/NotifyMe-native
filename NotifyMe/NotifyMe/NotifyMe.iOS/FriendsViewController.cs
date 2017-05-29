using System;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Views;
using NotifyMe.Core.ViewModels;
using NotifyMe.iOS.ViewControllers;
using UIKit;

namespace NotifyMe.iOS
{
    [MvxFromStoryboard("ApplicationStoryboard")]
    public partial class FriendsViewController : BaseViewController<FriendsViewModel>
    {
        private MvxPropertyChangedListener friendsListener;

        public FriendsViewController(IntPtr handle) : base(handle)
        {

        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var source = new FriendsDataSource(friendsList, "FriendCell", FriendCell.Key);
            friendsList.RowHeight = 100;

            var set = this.CreateBindingSet<FriendsViewController, FriendsViewModel>();
            set.Bind(showFriendsButton).To(vm => vm.GetFriendsCommand);
            set.Bind(source).To(vm => vm.Friends);
            set.Apply();

            source.OnRowSelected += (f) => ViewModel.NavigateToCreateMessageCommand.Execute(f);

            friendsList.Source = source;

            friendsListener = new MvxPropertyChangedListener(ViewModel).Listen(() => ViewModel.Friends, (sender, e) =>
            {
                friendsList.ReloadData();
            });

            NavigationController.TopViewController.NavigationItem.BackBarButtonItem =
                new UIBarButtonItem("Message", UIBarButtonItemStyle.Plain, (sender, e) => { ViewModel.ExitCommand.Execute(); });
        }
    }
}