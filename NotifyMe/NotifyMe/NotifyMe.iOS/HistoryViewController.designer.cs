// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace NotifyMe.iOS
{
    [Register ("HistoryViewController")]
    partial class HistoryViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView historyTable { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (historyTable != null) {
                historyTable.Dispose ();
                historyTable = null;
            }
        }
    }
}