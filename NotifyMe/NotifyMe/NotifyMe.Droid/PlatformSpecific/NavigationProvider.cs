using System;
using Android.App;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Views;
using MvvmCross.Platform.Droid;
using NotifyMe.Core;
using NotifyMe.Core.ViewModels;

namespace NotifyMe.Droid
{
    public class NavigationProvider : INavigationProvider
    {
        private readonly IMvxAndroidGlobals androidGlobals;

        private readonly IMvxAndroidViewModelRequestTranslator androidViewModelRequestTranslator;

        public NavigationProvider(
            IMvxAndroidViewModelRequestTranslator androidViewModelRequestTranslator,
            IMvxAndroidGlobals globals)
        {
            this.androidViewModelRequestTranslator = androidViewModelRequestTranslator;
            androidGlobals = globals;
        }

        public void StartApplication()
        {
            var request = new MvxViewModelRequest<LoginViewModel>(null, null, null);
            var intent = androidViewModelRequestTranslator.GetIntentFor(request);

            TaskStackBuilder tsb = TaskStackBuilder.Create(androidGlobals.ApplicationContext);
            tsb.AddNextIntent(intent);

            tsb.StartActivities();
        }
    }
}
