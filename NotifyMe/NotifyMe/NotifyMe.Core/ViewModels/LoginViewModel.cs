using System;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;
using NotifyMe.Core.Enumerations;
using NotifyMe.Core.Infrastructure;
using NotifyMe.Core.Infrastructure.Messages;
using NotifyMe.Core.Services;

namespace NotifyMe.Core.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private MvxCommand loginCommand;

        public LoginViewModel(
        IFacebookService facebookService,
        IApplicationCache cache,
        IMobileCenterLogger logger,
        ILoginService loginService,
            IMvxMessenger messanger) : base(messanger)
        {
            FacebookService = facebookService;
            Logger = logger;
            Cache = cache;
            LoginService = loginService;
        }

        protected IFacebookService FacebookService { get; private set; }

        protected IMobileCenterLogger Logger { get; private set; }

        protected IApplicationCache Cache { get; private set; }

        protected ILoginService LoginService { get; private set; }

        public MvxCommand LoginCommand
        {
            get
            {
                return loginCommand ?? (loginCommand = new MvxCommand(async () =>
                {

                    var success = await LoginService.Login();
                    if (success)
                    {
                        if (Cache.CurrentUser == null)
                        {
                            Cache.CurrentUser = await FacebookService.GetCurrentApplicationUser();
                            MobileServiceClientWrapper.Instance.CurrentUser = Cache.CurrentUser;
                        }

                        Messenger.Publish(new RegistrationMessage(this));
                        Logger.TrackEvent(Cache.CurrentUser.Name, EventType.UserLogged);
                    }

                    IsBusy = false;
                    ShowViewModel<MainViewModel>();
                }));
            }
        }
    }
}