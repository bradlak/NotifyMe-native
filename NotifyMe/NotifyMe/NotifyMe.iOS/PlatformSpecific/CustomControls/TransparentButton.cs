using System;
using System.ComponentModel;
using Foundation;
using NotifyMe.iOS.PlatformSpecific;
using UIKit;

namespace NotifyMe.iOS
{
    [Register("TransparentButton"), DesignTimeVisible (true)]
    public class TransparentButton : UIButton
    {
        public TransparentButton(IntPtr handle) : base(handle)
        {

        }

        public override void Draw(CoreGraphics.CGRect rect)
        {
            base.Draw(rect);
            this.Layer.MasksToBounds = true;
            this.Layer.BorderColor = SharedColors.Primary.CGColor;
            this.Layer.CornerRadius = 10;
            this.Layer.BorderWidth = 3;
            this.SetTitleColor(SharedColors.Primary, UIControlState.Normal);
            this.SetTitleColor(SharedColors.SecondPrimary, UIControlState.Highlighted);
            this.TintColor = SharedColors.Background;

            this.TouchDown += (sender, e) =>
            {
                this.Layer.BorderColor = SharedColors.SecondPrimary.CGColor;
            };

            this.TouchUpInside += (sender, e) =>
            {
                this.Layer.BorderColor = SharedColors.Primary.CGColor;
            };

            this.TouchUpOutside += (sender, e) =>
            {
                this.Layer.BorderColor = SharedColors.Primary.CGColor;
            };
        }
    }
}
