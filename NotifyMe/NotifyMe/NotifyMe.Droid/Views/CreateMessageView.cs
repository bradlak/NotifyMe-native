using System;
using Android.App;
using Android.Views;
using Android.Views.Animations;
using Android.Widget;
using Java.Lang;
using NotifyMe.Core.ViewModels;

namespace NotifyMe.Droid.Views
{
    [Activity]
    public class CreateMessageView : BaseAppCompatActivity<CreateMessageViewModel>, Animation.IAnimationListener
    {
        private ImageView image;


        public CreateMessageView()
            : base(Resource.Layout.CreateMessageView)
        {
        }

        protected override void OnCreate(Android.OS.Bundle bundle)
        {
            base.OnCreate(bundle);
            SupportActionBar.SetTitle(Resource.String.Message);

            image = FindViewById<ImageView>(Resource.Id.envelopeImage);

            ViewModel.PropertyChanged += ViewModel_PropertyChanged;
        }

        void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ViewModel.MessageSent))
            {
                Runnable end = new Runnable(() =>
                {
                    ViewModel.ExitCommand.Execute();
                });

                var x = image.GetX();
                var y = image.GetY();

                image.Animate().X(x + 600).Y(y - 600).ScaleX(0.5f).ScaleY(0.5f).SetDuration(1500).WithEndAction(end).Start();

            }
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            var result = base.OnOptionsItemSelected(item);
            if (ViewModel != null)
            {
                if (item.ItemId == Resource.Id.home || item.ItemId == Android.Resource.Id.Home)
                {
                    ViewModel.ExitCommand.Execute(null);
                    result = true;
                }
            }

            return result;
        }

        public void OnAnimationEnd(Animation animation)
        {
            ViewModel.ExitCommand.Execute();
        }

        public void OnAnimationRepeat(Animation animation)
        {

        }

        public void OnAnimationStart(Animation animation)
        {

        }
    }
}