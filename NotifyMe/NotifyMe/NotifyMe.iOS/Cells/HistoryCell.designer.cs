// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace NotifyMe.iOS
{
    [Register ("HistoryCell")]
    partial class HistoryCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel body { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel date { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel receiver { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (body != null) {
                body.Dispose ();
                body = null;
            }

            if (date != null) {
                date.Dispose ();
                date = null;
            }

            if (receiver != null) {
                receiver.Dispose ();
                receiver = null;
            }
        }
    }
}