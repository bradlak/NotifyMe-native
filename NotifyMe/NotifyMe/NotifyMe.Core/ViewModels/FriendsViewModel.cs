using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotifyMe.Core.ViewModels
{
    public class FriendsViewModel : BaseViewModel
    {
        public string text = "Hello";

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
