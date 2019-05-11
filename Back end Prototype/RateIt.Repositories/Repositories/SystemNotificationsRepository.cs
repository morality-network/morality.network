using RateIt.Model;
using RateIt.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Repositories.Repositories
{
    public class SystemNotificationsRepository : BaseRepository, IRepository<SystemNotification>
    {

        public SystemNotificationsRepository(MoralityNetworkEntities entities) : base(entities)
        { }

        public SystemNotification Add(SystemNotification item)
        {
            _entities.SystemNotifications.Add(item);
            return item;
        }

        public IEnumerable<SystemNotification> GetAll()
        {
            return _entities.SystemNotifications;
        }

        public SystemNotification Remove(SystemNotification item)
        {
            _entities.SystemNotifications.Remove(item);
            return item;
        }

        public IList<SystemNotification> RemoveList(IList<SystemNotification> items)
        {
            _entities.SystemNotifications.RemoveRange(items);
            return items;
        }

        public SystemNotification Update(SystemNotification item)
        {
            _entities.Entry(item).State = System.Data.Entity.EntityState.Modified;
            return item;
        }
    }
}
