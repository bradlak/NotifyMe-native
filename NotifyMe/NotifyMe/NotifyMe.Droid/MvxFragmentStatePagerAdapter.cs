using System;
using System.Collections.Generic;
using System.Linq;
using Android.Content;
using Android.Runtime;
using Android.Support.V4.App;
using Java.Lang;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Support.V4;

namespace NotifyMe.Droid
{
    public class MvxFragmentStatePagerAdapter : FragmentStatePagerAdapter
    {
        private readonly Context _context;

        public IEnumerable<FragmentInfo> Fragments { get; private set; }

        public override int Count
        {
            get { return Fragments.Count(); }
        }

        protected MvxFragmentStatePagerAdapter(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

        public MvxFragmentStatePagerAdapter(
            Context context, FragmentManager fragmentManager, IEnumerable<FragmentInfo> fragments)
            : base(fragmentManager)
        {
            _context = context;
            Fragments = fragments;
        }

        public override Fragment GetItem(int position)
        {
            var fragmentInfo = Fragments.ElementAt(position);

            return fragmentInfo.Fragment;
        }

        public class FragmentInfo
        {
            public string Title { get; set; }

            public MvxFragment Fragment { get; set; }

            public IMvxViewModel ViewModel { get; set; }
        }
    }
}
