using Android.App;
using NotifyMe.Core.ViewModels;

namespace NotifyMe.Droid.Views
{
    [Activity]
    public class CreateMessageView : BaseAppCompatActivity<CreateMessageViewModel>
    {
        public CreateMessageView() 
            : base(Resource.Layout.CreateMessageView)
        {
        }
    }
}