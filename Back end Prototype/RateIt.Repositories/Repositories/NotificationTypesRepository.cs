using RateIt.Model;
using RateIt.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Repositories.Repositories
{
    public class NotificationTypesRepository : BaseRepository, IRepository<NotificationType>
    {

        public NotificationTypesRepository(MoralityNetworkEntities entities) : base(entities)
        { }

        public NotificationType Add(NotificationType item)
        {
            _entities.NotificationTypes.Add(item);
            return item;
        }

        public IEnumerable<NotificationType> GetAll()
        {
            return _entities.NotificationTypes;
        }

        public NotificationType Remove(NotificationType item)
        {
            _entities.NotificationTypes.Remove(item);
            return item;
        }

        public IList<NotificationType> RemoveList(IList<NotificationType> items)
        {
            _entities.NotificationTypes.RemoveRange(items);
            return items;
        }

        public NotificationType Update(NotificationType item)
        {
            _entities.Entry(item).State = System.Data.Entity.EntityState.Modified;
            return item;
        }
    }
}
