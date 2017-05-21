using MvvmCross.Plugins.Messenger;

namespace NotifyMe.Core.Infrastructure.Messages
{
    public class RefreshHistoryMessage : MvxMessage
    {
        public RefreshHistoryMessage(object sender) : base(sender)
        {

        }
    }
}
