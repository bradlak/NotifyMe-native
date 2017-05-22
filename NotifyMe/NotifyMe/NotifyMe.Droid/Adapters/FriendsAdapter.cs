using System;
using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Views;
using Android.Widget;
using Java.Lang;
using NotifyMe.Core.ViewModels;
using NotifyMe.Models;

namespace NotifyMe.Droid
{
    public class FriendsAdapter : BaseAdapter
    {
        private FriendsViewModel viewModel;

        private Activity context;

        public FriendsAdapter(Activity context, FriendsViewModel vm)
        {
            this.viewModel = vm;
            this.context = context;
        }

        public override int Count
        {
            get
            {
                int result = 0;
                if (viewModel.Friends != null)
                {
                    result = viewModel.Friends.Count;
                }

                return result;
            }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return position;
        }


        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;

            if (view == null)
            {
                view = context.LayoutInflater.Inflate(Resource.Layout.friendListItem, null);
            }

            if (viewModel.Friends != null && viewModel.Friends.Any())
            {

                var currentFriend = viewModel.Friends[position];

                var nameTextView = view.FindViewById<TextView>(Resource.Id.friendName);

                nameTextView.Text = currentFriend.Name;

            }

            return view;
        }
    }
}
