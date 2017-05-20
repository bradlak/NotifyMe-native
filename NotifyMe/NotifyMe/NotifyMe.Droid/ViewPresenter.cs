using System;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Views;

namespace NotifyMe.Droid
{
    public class ViewPresenter : MvxAndroidViewPresenter
    {
        public override void Show(MvxViewModelRequest request)
        {
            var intent = this.CreateIntentForRequest(request);
            intent.SetFlags(Android.Content.ActivityFlags.NewTask | Android.Content.ActivityFlags.MultipleTask);
            Show(intent);
        }
    }
}
