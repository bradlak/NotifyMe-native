using System;
using CoreGraphics;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using NotifyMe.Core.ViewModels;
using NotifyMe.iOS.ViewControllers;
using UIKit;

namespace NotifyMe.iOS
{
    [MvxFromStoryboard("ApplicationStoryboard")]
    public partial class CreateMessageViewController : BaseViewController<CreateMessageViewModel>
    {
        UITapGestureRecognizer tap;

        NSObject shownotification;

        NSObject hidenotification;

        public CreateMessageViewController(IntPtr handle) : base(handle)
        {
            tap = new UITapGestureRecognizer();
            tap.AddTarget(() =>
            {
                View.EndEditing(true);
            });

            tap.CancelsTouchesInView = false;
            View.AddGestureRecognizer(tap);
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var set = this.CreateBindingSet<CreateMessageViewController, CreateMessageViewModel>();
            set.Bind(messageBody).To(vm => vm.MessageBody);
            set.Bind(receiver).To(vm => vm.MessageRecipient);
            set.Bind(sendButton).To(vm => vm.SendMessageCommand);
            set.Apply();

            messageBody.ShouldReturn += (textField) => textField.ResignFirstResponder();

            ViewModel.PropertyChanged += ViewModel_PropertyChanged;
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            hidenotification = UIKeyboard.Notifications.ObserveDidHide(HideCallback);
            shownotification = UIKeyboard.Notifications.ObserveDidShow(ShowCallback);
        }

        public override void ViewWillDisappear(bool animated)
        {
            hidenotification?.Dispose();
            shownotification?.Dispose();

            base.ViewWillDisappear(animated);
        }

        void HideCallback(object sender, UIKeyboardEventArgs e)
        {
            var insets = UIEdgeInsets.Zero;
            scrollView.ContentInset = insets;
        }

        void ShowCallback(object sender, UIKeyboardEventArgs e)
        {
            CGRect keyboardBounds = e.FrameEnd;

            var insets = new UIEdgeInsets(0.0f, 0.0f, keyboardBounds.Size.Height + 20, 0.0f);
            scrollView.ContentInset = insets;
        }

        void ViewModel_PropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ViewModel.MessageSent))
            {
                UIView.Animate(1, 0, UIViewAnimationOptions.CurveLinear,
                    () =>
                    {
                        envelopeImage.Center =
                                         new CGPoint(UIScreen.MainScreen.Bounds.Right - envelopeImage.Frame.Width / 2,
                                                     UIScreen.MainScreen.Bounds.Top + envelopeImage.Frame.Height / 2);

                        envelopeImage.Transform = CGAffineTransform.Scale(envelopeImage.Transform, 0.5f, 0.5f);
                    },
                    () =>
                    {
                        ViewModel.ExitCommand.Execute();
                    }
                );
            }
        }
    }
}