using System;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using NotifyMe.Models.Entities;
using UIKit;

namespace NotifyMe.iOS
{
    public partial class HistoryCell : MvxTableViewCell
    {
        public static readonly NSString Key = new NSString("HistoryCell");
        public static readonly UINib Nib;

        static HistoryCell()
        {
            Nib = UINib.FromName("HistoryCell", NSBundle.MainBundle);
        }

        protected HistoryCell(IntPtr handle) : base(handle)
        {
            this.DelayBind(() =>
            {
                var set = this.CreateBindingSet<HistoryCell, SentMessage>();
                set.Bind(receiver).To(m => m.Receiver);
                set.Bind(date).To(m => m.Date);
                set.Bind(body).To(m => m.Body);
                set.Apply();
            });
        }
    }
}
