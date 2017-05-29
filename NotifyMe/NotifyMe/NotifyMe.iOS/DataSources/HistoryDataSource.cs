using System;
using MvvmCross.Binding.iOS.Views;
using UIKit;

namespace NotifyMe.iOS
{
    public class HistoryDataSource : MvxSimpleTableViewSource
    {
        public HistoryDataSource(UITableView table, string nibName, string cellId)
            : base(table, nibName, cellId)
        {
        }

        public override UITableViewCell GetCell(UITableView tableView, Foundation.NSIndexPath indexPath)
        {
            var cell = base.GetCell(tableView, indexPath) as HistoryCell;

            return cell;
        }
    }
}
