using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Plugins.Messenger;

namespace NotifyMe.Core.ViewModels
{
    public class HistoryViewModel : BaseViewModel
    {
        public HistoryViewModel(IMvxMessenger messenger) : base(messenger)
        {

        }

        public string text = "History here";

        public string Info
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
            }
        }
    }
}
