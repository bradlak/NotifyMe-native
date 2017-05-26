using Android.App;
using Android.Views;
using Android.Widget;
using NotifyMe.Core.ViewModels;

namespace NotifyMe.Droid
{
    public class HistoryAdapter : BaseAdapter
    {
        private Activity context;

        private HistoryViewModel vm;

        public HistoryAdapter(Activity activity, HistoryViewModel data)
        {
            context = activity;
            vm = data;
        }

        public override int Count => vm.SentMessages.Count;

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return 0;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;

            if (view == null)
            {
                view = context.LayoutInflater.Inflate(Resource.Layout.historyListItem, null, false);
            }

            var currentMessage = vm.SentMessages[position];

            var receiver = view.FindViewById<TextView>(Resource.Id.receiver);
            var body = view.FindViewById<TextView>(Resource.Id.body);
            var date = view.FindViewById<TextView>(Resource.Id.date);

            receiver.Text = currentMessage.Receiver;
            body.Text = currentMessage.Body;
            date.Text = currentMessage.Date;

            return view;
        }
    }
}
