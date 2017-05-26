using System;
using System.Net.Http;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NotifyMe.Core.Enumerations;
using NotifyMe.Core.Infrastructure;
using NotifyMe.Core.Infrastructure.Messages;
using NotifyMe.Core.Services;
using NotifyMe.Models;
using NotifyMe.Models.Entities;

namespace NotifyMe.Core.ViewModels
{
    public class CreateMessageViewModel : BaseViewModel
    {
        private string messageRecipient;

        private string messageBody;

        private bool messageSent;

        private MvxCommand sendMessageCommand;

        public CreateMessageViewModel(
            IApplicationCache cache,
            IDatabaseService dbService,
            IMobileCenterLogger logger,
            IMvxMessenger messenger) : base(messenger)
        {
            Cache = cache;
            DatabaseService = dbService;
            Logger = logger;
        }

        protected IApplicationCache Cache { get; private set; }

        protected IDatabaseService DatabaseService { get; private set; }

        protected IMobileCenterLogger Logger { get; private set; }

        public string MessageRecipient
        {
            get
            {
                return messageRecipient;
            }
            set
            {
                messageRecipient = value;
                RaisePropertyChanged();
            }
        }

        public string MessageBody
        {
            get
            {
                return messageBody;
            }
            set
            {
                messageBody = value;
                RaisePropertyChanged();
            }
        }

        public bool MessageSent
        {
            get
            {
                return messageSent;
            }
            set
            {
                messageSent = value;
                RaisePropertyChanged();
            }
        }

        public MvxCommand SendMessageCommand
        {
            get
            {
                return sendMessageCommand ?? (sendMessageCommand = new MvxCommand(async () =>
                {
                    await SendMessage();
                }));
            }
        }

        protected override void OnResume()
        {
            base.OnResume();
            MessageRecipient = Cache.SelectedFriend.Name;
        }

        private async Task SendMessage()
        {
            IsBusy = true;

            Message message = new Message()
            {
                Body = MessageBody,
                From = Cache.CurrentUser.Name,
                RecipientId = Cache.SelectedFriend.Id
            };

            var serialized = JsonConvert.SerializeObject(message);
            var jtoken = JToken.Parse(serialized);
            try
            {
                var result = await MobileServiceClientWrapper.Instance.Client.InvokeApiAsync("notifications/send", jtoken, HttpMethod.Post, null);
            }
            catch (Exception ex)
            {
                MessageRecipient = "Not found";
                await Task.Delay(1000);
            }

            DatabaseService.Add<SentMessage>(new SentMessage(Cache.SelectedFriend.Name, MessageBody, DateTime.Now.ToString()));
            Logger.TrackEvent(Cache.CurrentUser.Name, EventType.MessageSent);

            IsBusy = false;
            MessageSent = true;
        }
    }
}
