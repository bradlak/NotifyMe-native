using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Plugins.Messenger;

namespace NotifyMe.Core.ViewModels
{
    public class CreateMessageViewModel : BaseViewModel
    {
        public CreateMessageViewModel(IMvxMessenger messenger) : base(messenger)
        {

        }
    }
}
