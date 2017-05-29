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
    [Register ("FriendsViewController")]
    partial class FriendsViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView friendsList { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        NotifyMe.iOS.TransparentButton showFriendsButton { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (friendsList != null) {
                friendsList.Dispose ();
                friendsList = null;
            }

            if (showFriendsButton != null) {
                showFriendsButton.Dispose ();
                showFriendsButton = null;
            }
        }
    }
}