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
    [Register ("CreateMessageViewController")]
    partial class CreateMessageViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView envelopeImage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField messageBody { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel receiver { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIScrollView scrollView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        NotifyMe.iOS.TransparentButton sendButton { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (envelopeImage != null) {
                envelopeImage.Dispose ();
                envelopeImage = null;
            }

            if (messageBody != null) {
                messageBody.Dispose ();
                messageBody = null;
            }

            if (receiver != null) {
                receiver.Dispose ();
                receiver = null;
            }

            if (scrollView != null) {
                scrollView.Dispose ();
                scrollView = null;
            }

            if (sendButton != null) {
                sendButton.Dispose ();
                sendButton = null;
            }
        }
    }
}