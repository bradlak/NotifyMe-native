using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotifyMe.Core.ViewModels
{
    public class BaseViewModel : MvxViewModel
    {
        private bool isBusy;

        private MvxCommand resumeCommand;

        private MvxCommand exitCommand;

        protected bool IsBusy
        {
            get { return isBusy; }
            set { isBusy = value; RaisePropertyChanged(); }
        }

        public MvxCommand ResumeCommand
        {
            get
            {
                return resumeCommand ?? (resumeCommand = new MvxCommand(OnResume));
            }
        }

        public MvxCommand ExitCommand
        {
            get
            {
                return exitCommand ?? (exitCommand = new MvxCommand(OnExit));
            }
        }

        protected virtual void OnResume()
        {
        }

        protected virtual void OnExit()
        {
        }
    }
}
