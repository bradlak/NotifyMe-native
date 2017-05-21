using MvvmCross.Platform;
using MvvmCross.Platform.IoC;
using NotifyMe.Core.Services;

namespace NotifyMe.Core
{
    public class App : MvvmCross.Core.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            Mvx.RegisterType<IApplicationCache, ApplicationCache>();
            Mvx.RegisterType<IDatabaseService, DatabaseService>();
            Mvx.RegisterType<IFacebookService, FacebookService>();
            Mvx.RegisterType<IMobileCenterLogger, MobileCenterLogger>();

            RegisterAppStart<ViewModels.LoginViewModel>();
        }
    }
}
