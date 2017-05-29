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
    [Register ("FriendCell")]
    partial class FriendCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView friendImage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel friendName { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (friendImage != null) {
                friendImage.Dispose ();
                friendImage = null;
            }

            if (friendName != null) {
                friendName.Dispose ();
                friendName = null;
            }
        }
    }
}