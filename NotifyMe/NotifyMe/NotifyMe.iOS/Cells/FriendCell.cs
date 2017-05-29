using System;
using System.Net.Http;
using System.Threading.Tasks;
using CoreAnimation;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using NotifyMe.Models;
using UIKit;

namespace NotifyMe.iOS
{
    public partial class FriendCell : MvxTableViewCell
    {
        public static readonly NSString Key = new NSString("FriendCellView");

        public static readonly UINib Nib;

        static FriendCell()
        {
            Nib = UINib.FromName("FriendCellView", NSBundle.MainBundle);
        }

        protected FriendCell(IntPtr handle) : base(handle)
        {
            this.DelayBind(() =>
             {
                 var set = this.CreateBindingSet<FriendCell, FacebookFriend>();
                 set.Bind(friendName).To(m => m.Name);
                 set.Apply();
             });
        }

        public async void UpdateCell(FacebookFriend friend)
        {
            CALayer profileImageCircle = friendImage.Layer;
            profileImageCircle.CornerRadius = 30;
            profileImageCircle.MasksToBounds = true;
            friendImage.Image = await LoadImage(friend.ImageUrl);
        }

        public async Task<UIImage> LoadImage(string imageUrl)
        {
            var httpClient = new HttpClient();

            Task<byte[]> contentsTask = httpClient.GetByteArrayAsync(imageUrl);

            var contents = await contentsTask;

            return UIImage.LoadFromData(NSData.FromArray(contents));
        }
    }
}
