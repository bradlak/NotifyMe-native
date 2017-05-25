using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using NotifyMe.Core.ViewModels;
using Android.Support.V4.View;
using Android.Support.Design.Widget;

namespace NotifyMe.Droid.Views
{
    [Activity]
    public class MainView : BaseAppCompatActivity<MainViewModel>
    {
        public MainView() : base(Resource.Layout.MainView)
        {
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SupportActionBar.SetTitle(Resource.String.Logout);

            var viewPager = FindViewById<ViewPager>(Resource.Id.viewpager);
            if (viewPager != null)
            {
                var fragments = new List<FragmentInfo>
                {
                    new FragmentInfo() {ViewModel = ViewModel.FriendsViewModel, Fragment = new FriendsFragment()},
                    new FragmentInfo() {ViewModel = ViewModel.HistoryViewModel, Fragment = new HistoryFragment()}
                };

                viewPager.Adapter = new MvxFragmenPagerAdapter(SupportFragmentManager, fragments);
            }

            var tabLayout = FindViewById<TabLayout>(Resource.Id.tabs);
            tabLayout.SetupWithViewPager(viewPager);

            for (int i = 0; i < tabLayout.TabCount; i++)
            {
                var view = PrepareCustomView(i);
                var tab = tabLayout.GetTabAt(i).SetCustomView(view);
            }
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            var result = base.OnOptionsItemSelected(item);
            if (ViewModel != null)
            {
                if (item.ItemId == Resource.Id.home || item.ItemId == Android.Resource.Id.Home)
                {
                    ViewModel.ExitCommand.Execute(null);
                    result = true;
                }
            }

            return result;
        }

        private View PrepareCustomView(int i)
        {
            var view = LayoutInflater.Inflate(Resource.Layout.tabView, null);

            var image = view.FindViewById<ImageView>(Resource.Id.tabIcon);
            var text = view.FindViewById<TextView>(Resource.Id.tabText);
            if (i == 0)
            {
                image.SetImageDrawable(Resources.GetDrawable(Resource.Drawable.people));
                text.Text = "FRIENDS";
            }
            else
            {
                image.SetImageDrawable(Resources.GetDrawable(Resource.Drawable.history));
                text.Text = "HISTORY";
            }

            view.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent,
                                                               ViewGroup.LayoutParams.MatchParent);

            return view;
        }
    }
}