using Android.OS;
using Android.Runtime;
using Android.Views;
using NotifyMe.Core.ViewModels;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Binding.Droid.BindingContext;

namespace NotifyMe.Droid.Views
{
    [Register("notifyMe.droid.views.FriendsFragment")]
    public class FriendsFragment : MvxFragment<FriendsViewModel>
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            this.EnsureBindingContextIsSet(savedInstanceState);
            return this.BindingInflate(Resource.Layout.FriendsFragmentView, container, false);
        }
    }
}