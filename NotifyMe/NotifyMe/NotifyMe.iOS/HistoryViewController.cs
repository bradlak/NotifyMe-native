using Foundation;
using System;
using UIKit;
using NotifyMe.iOS.ViewControllers;
using NotifyMe.Core.ViewModels;
using MvvmCross.iOS.Views;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Core.ViewModels;

namespace NotifyMe.iOS
{
    [MvxFromStoryboard("ApplicationStoryboard")]
    public partial class HistoryViewController : BaseViewController<HistoryViewModel>
    {
        MvxPropertyChangedListener historyListener;

        public HistoryViewController(IntPtr handle) : base(handle)
        {

        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var source = new HistoryDataSource(historyTable, "HistoryCell", HistoryCell.Key);
             historyTable.RowHeight = 70;
            var set = this.CreateBindingSet<HistoryViewController, HistoryViewModel>();
            set.Bind(source).To(vm => vm.SentMessages);
            set.Apply();

            historyTable.Source = source;

            historyListener = new MvxPropertyChangedListener(ViewModel).Listen(() => ViewModel.SentMessages, (sender, e) =>
            {
                historyTable.ReloadData();
            });
        }
    }
}