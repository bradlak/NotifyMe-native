using System;
using System.Collections.ObjectModel;
using System.Linq;
using MvvmCross.Plugins.Messenger;
using NotifyMe.Core.Services;
using NotifyMe.Models.Entities;
using NotifyMe.Core.Infrastructure.Messages;

namespace NotifyMe.Core.ViewModels
{
    public class HistoryViewModel : BaseViewModel
    {
        private ObservableCollection<SentMessage> sentMessages = new ObservableCollection<SentMessage>();

        public HistoryViewModel(
			IDatabaseService dbService,
			IApplicationCache cache,
			IMobileCenterLogger logger,
            IMvxMessenger messenger) : base(messenger)
        {
            DatabaseService = dbService;
            Cache = cache;
            Logger = logger;
            LoadHistory();
        }

        protected IDatabaseService DatabaseService { get; private set; }

        protected IApplicationCache Cache { get; private set; }

        protected IMobileCenterLogger Logger { get; private set; }

		public ObservableCollection<SentMessage> SentMessages
		{
			get { return sentMessages; }
			set { sentMessages = value; RaisePropertyChanged(); }
		}

		public void LoadHistory()
		{
			var data = DatabaseService.GetAll<SentMessage>().OrderByDescending(z => DateTime.Parse(z.Date));
			SentMessages = new ObservableCollection<SentMessage>(data);
		}

        protected override void OnResume()
        {
            LoadHistory();
        }
    }
}
