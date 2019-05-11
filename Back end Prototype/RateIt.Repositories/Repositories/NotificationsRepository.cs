using RateIt.Model;
using RateIt.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Repositories.Repositories
{
    public class NotificationsRepository : BaseRepository, IRepository<Notification>
    {

        public NotificationsRepository(MoralityNetworkEntities entities) : base(entities)
        { }

        public Notification Add(Notification item)
        {
            _entities.Notifications.Add(item);
            return item;
        }

        public IEnumerable<Notification> GetAll()
        {
            return _entities.Notifications;
        }

        public Notification Remove(Notification item)
        {
            _entities.Notifications.Remove(item);
            return item;
        }

        public IList<Notification> RemoveList(IList<Notification> items)
        {
            _entities.Notifications.RemoveRange(items);
            return items;
        }

        public Notification Update(Notification item)
        {
            _entities.Entry(item).State = System.Data.Entity.EntityState.Modified;
            return item;
        }
    }
}
