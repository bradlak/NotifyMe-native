using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;
using NotifyMe.Core.Enumerations;
using NotifyMe.Core.Services;
using NotifyMe.Models;

namespace NotifyMe.Core.ViewModels
{
    public class FriendsViewModel : BaseViewModel
    {
        private MvxCommand getFriendsCommand;

        private FacebookFriend selectedFriend;

        private ObservableCollection<FacebookFriend> friends;

        public FriendsViewModel(
               IApplicationCache cache,
               IFacebookService fbservice,
               IMobileCenterLogger logger,
               IMvxMessenger messenger) : base(messenger)
        {
            FacebookService = fbservice;
            Cache = cache;
            Logger = logger;
        }

        protected IFacebookService FacebookService { get; private set; }

        protected IApplicationCache Cache { get; private set; }

        protected IMobileCenterLogger Logger { get; private set; }


        public FacebookFriend SelectedFriend
        {
            get { return selectedFriend; }
            set
            {
                selectedFriend = value;
                RaisePropertyChanged();

                if (value != null)
                {
                    Cache.SelectedFriend = SelectedFriend;
                    ShowViewModel<CreateMessageViewModel>();
                }
            }
        }

        public ObservableCollection<FacebookFriend> Friends
        {
            get { return friends; }
            set { friends = value; RaisePropertyChanged(); }
        }

        public MvxCommand GetFriendsCommand
        {
            get
            {
                return getFriendsCommand ?? (getFriendsCommand = new MvxCommand(async () =>
                {
                    IsBusy = true;
                    if (Friends != null) Friends.Clear();
                    Friends = new ObservableCollection<FacebookFriend>(await FacebookService.GetFacebookFriends());
                    Logger.TrackEvent(Cache.CurrentUser.Name, EventType.FriendsCollected);
                    IsBusy = false;
                }));
            }
        }

        protected override void OnResume()
        {
            base.OnResume();
            SelectedFriend = null;
        }
    }
}