using Android.OS;
using Android.Runtime;
using Android.Views;
using NotifyMe.Core.ViewModels;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Binding.Droid.BindingContext;
using Android.Widget;
using System.Linq;
using MvvmCross.Core.ViewModels;

namespace NotifyMe.Droid.Views
{
    [Register("notifyMe.droid.views.FriendsFragment")]
    public class FriendsFragment : MvxFragment<FriendsViewModel>
    {
        private ListView friendsListView;

        private ProgressBar progress;

        private FriendsAdapter friendsAdapter;

        private MvxPropertyChangedListener friendsListener;

        private MvxPropertyChangedListener busyListener;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            this.EnsureBindingContextIsSet(savedInstanceState);
            var view = this.BindingInflate(Resource.Layout.FriendsFragmentView, container, false);

            friendsListView = view.FindViewById<ListView>(Resource.Id.friendsList);
            progress = view.FindViewById<ProgressBar>(Resource.Id.busyIndicator);

            friendsAdapter = new FriendsAdapter(this.Activity, ViewModel);
            friendsListView.Adapter = friendsAdapter;

            friendsListener = new MvxPropertyChangedListener(ViewModel).Listen(() => ViewModel.Friends, (sender, e) =>
           {
               friendsAdapter.NotifyDataSetChanged();
           });

            friendsListView.ItemClick += (sender, e) =>
            {
                var selected = ViewModel.Friends[e.Position];
                ViewModel.NavigateToCreateMessageCommand.Execute(selected);
            };

            return view;
        }
    }
}