using Realms;
using System.Collections.Generic;

namespace NotifyMe.Core.Services
{
    public interface IDatabaseService
    {
        IEnumerable<T> GetAll<T>() where T : RealmObject;

        void Add<T>(T obj) where T : RealmObject;

        void RemoveAll<T>() where T : RealmObject;
    }
}
