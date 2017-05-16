using System;
using MvvmCross.Core.ViewModels;

namespace NotifyMe.Core.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private MvxCommand loginCommand;

        public MvxCommand LoginCommand
        {
            get
            {
                return loginCommand ?? (loginCommand = new MvxCommand(LoginExecute));
            }
        }

        private void LoginExecute()
        {
            ShowViewModel<MainViewModel>();
        }
    }
}
