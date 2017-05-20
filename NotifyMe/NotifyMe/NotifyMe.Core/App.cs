using MvvmCross.Platform;
using MvvmCross.Platform.IoC;

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

            RegisterAppStart<ViewModels.LoginViewModel>();
        }
    }
}
