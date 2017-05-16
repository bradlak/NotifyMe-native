using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using NotifyMe.Core.ViewModels;
using MvvmCross.Droid.Support.V4;
using Android.Support.V4.App;
using MvvmCross.Droid.Shared.Caching;

namespace NotifyMe.Droid.Views
{
    [Activity]
    public class MainView : MvxTabsFragmentActivity
    {
        public MainView() : base(Resource.Layout.MainView, Resource.Id.content_frame)
        {

        }

        public new MainViewModel ViewModel
        {
            get { return (MainViewModel)base.ViewModel; }
        }


        protected override void AddTabs(Bundle args)
        {
            AddTab<FriendsFragment>("1", "Friends", args, ViewModel.FriendsViewModel);
            AddTab<HistoryFragment>("2", "History", args, ViewModel.HistoryViewModel);
        }
    }
}