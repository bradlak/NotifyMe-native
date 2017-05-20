using System;
using System.Collections.Generic;
using System.Linq;
using Android.Runtime;
using Android.Support.V4.App;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Support.V4;

namespace NotifyMe.Droid
{
    public class MvxFragmenPagerAdapter : FragmentPagerAdapter
    {
        public IEnumerable<FragmentInfo> FragmentInfos { get; private set; }

        public override int Count
        {
            get { return FragmentInfos.Count(); }
        }

        protected MvxFragmenPagerAdapter(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

        public MvxFragmenPagerAdapter(FragmentManager fragmentManager, IEnumerable<FragmentInfo> fragments)
            : base(fragmentManager)
        {
            FragmentInfos = fragments;
        }

        public override Fragment GetItem(int position)
        {
            var info = FragmentInfos.ElementAt(position);
            info.Fragment.DataContext = info.ViewModel;
            return info.Fragment;
        }
    }
}
