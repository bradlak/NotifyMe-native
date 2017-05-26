using Android.OS;
using Android.Runtime;
using Android.Views;
using NotifyMe.Core.ViewModels;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Binding.Droid.BindingContext;
using Android.Widget;
using System.Linq;
using NotifyMe.Core.Infrastructure.Messages;

namespace NotifyMe.Droid.Views
{
    [Register("notifyMe.droid.views.HistoryFragment")]
    public class HistoryFragment : MvxFragment<HistoryViewModel>
    {
        private ListView historyList;

        private HistoryAdapter adapter;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            this.EnsureBindingContextIsSet(savedInstanceState);
            var view = this.BindingInflate(Resource.Layout.HistoryFragmentView, container, false);

            historyList = view.FindViewById<ListView>(Resource.Id.historyList);
            historyList.EmptyView = view.FindViewById<TextView>(Resource.Id.emptyView);

            adapter = new HistoryAdapter(this.Activity, ViewModel);

            historyList.Adapter = adapter;

            return view;
        }

        public override void OnResume()
        {
            base.OnResume();
            adapter.NotifyDataSetChanged();
            ViewModel.ResumeCommand.Execute();
        }
    }
}