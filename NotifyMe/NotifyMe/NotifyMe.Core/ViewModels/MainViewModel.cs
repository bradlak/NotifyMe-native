using MvvmCross.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Plugins.Messenger;

namespace NotifyMe.Core.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel(IMvxMessenger messenger) : base(messenger)
        {
            FriendsViewModel = Mvx.IocConstruct<FriendsViewModel>();
            HistoryViewModel = Mvx.IocConstruct<HistoryViewModel>();
        }

        public FriendsViewModel FriendsViewModel { get; set; }

        public HistoryViewModel HistoryViewModel { get; set; }
    }
}
