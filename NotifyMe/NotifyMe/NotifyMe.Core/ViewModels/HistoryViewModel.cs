using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotifyMe.Core.ViewModels
{
    public class HistoryViewModel : BaseViewModel
    {
        public string text = "Heheszki";

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
