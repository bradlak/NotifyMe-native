using System;
using MvvmCross.Binding.iOS.Views;
using NotifyMe.Models;
using UIKit;

namespace NotifyMe.iOS
{
    public class FriendsDataSource : MvxSimpleTableViewSource
    {
        public Action<FacebookFriend> OnRowSelected;

        public FriendsDataSource(UITableView table, string nibName, string cellId) 
            : base(table, nibName, cellId)
        {
        }

        public override UITableViewCell GetCell(UITableView tableView, Foundation.NSIndexPath indexPath)
        {
            var cell = base.GetCell(tableView, indexPath) as FriendCell;

            var item = (FacebookFriend)GetItemAt(indexPath);
            cell.UpdateCell(item);
            return cell;
        }

        public override void RowSelected(UITableView tableView, Foundation.NSIndexPath indexPath)
        {
            base.RowSelected(tableView, indexPath);

            var item = (FacebookFriend)GetItemAt(indexPath);
            SelectedItem = item;
            OnRowSelected?.Invoke(item);
        }
    }
}
