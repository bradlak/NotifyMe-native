using Android.OS;
using Android.Support.V7.Widget;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Views;
using MvvmCross.Core.ViewModels;
using NotifyMe.Core.ViewModels;

namespace NotifyMe.Droid.Views
{
    public abstract class BaseAppCompatActivity<TViewModel> : MvxAppCompatActivity, IMvxAndroidView<TViewModel> where TViewModel : BaseViewModel
    {
        private int layout;

        public BaseAppCompatActivity(int layoutResource)
        {
            layout = layoutResource;
        }

        protected Toolbar Toolbar { get; set; }


        public new TViewModel ViewModel
        {
            get { return (TViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(layout);

            Toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            if (Toolbar != null)
            {
                SetSupportActionBar(Toolbar);
                SupportActionBar.SetDisplayHomeAsUpEnabled(true);
                SupportActionBar.SetHomeButtonEnabled(true);
            }
        }

        protected override void OnResume()
        {
            base.OnResume();
            if(ViewModel != null)
            {
                ViewModel.ResumeCommand.Execute();
            }
        }

        protected override void OnPause()
        {
            if(ViewModel != null)
            {
                ViewModel.ExitCommand.Execute();
            }
            base.OnPause();
        }
    }
}
