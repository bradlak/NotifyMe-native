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
using MvvmCross.Droid.Shared.Attributes;
using MvvmCross.Droid.Support.V4;

namespace NotifyMe.Droid.Views
{
   // [MvxFragment(typeof(MainViewModel), Resource.Id.content_frame, false)]
   // [Register("NotifyMe.Droid.Views.HistoryFragment")]
    public class HistoryFragment : MvxFragment<HistoryViewModel>
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.FriendsFragmentView, container, false);
            return view;
        }
    }
}