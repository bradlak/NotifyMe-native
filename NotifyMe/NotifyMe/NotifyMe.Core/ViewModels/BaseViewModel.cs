using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;

namespace NotifyMe.Core.ViewModels
{
    public class BaseViewModel : MvxViewModel
    {
        private bool isBusy;

        private MvxCommand resumeCommand;

        private MvxCommand exitCommand;

        public BaseViewModel(IMvxMessenger messenger)
        {
            Messenger = messenger;
        }

        public IMvxMessenger Messenger { get; private set; }

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
            Close(this);
        }
    }
}
