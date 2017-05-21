using NotifyMe.Core.Enumerations;
using System;

namespace NotifyMe.Core.Services
{
    public interface IMobileCenterLogger
    {
        void TrackEvent(string userName, EventType type);

        void TrackCrash(Exception ex);
    }
}
