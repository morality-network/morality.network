using RateIt.Model;
using RateIt.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Repositories.Repositories
{
    public class SystemValuesRepository : BaseRepository, IRepository<SystemValue>
    {

        public SystemValuesRepository(MoralityNetworkEntities entities) : base(entities)
        { }

        public SystemValue Add(SystemValue item)
        {
            _entities.SystemValues.Add(item);
            return item;
        }

        public IEnumerable<SystemValue> GetAll()
        {
            return _entities.SystemValues;
        }

        public SystemValue Remove(SystemValue item)
        {
            _entities.SystemValues.Remove(item);
            return item;
        }

        public IList<SystemValue> RemoveList(IList<SystemValue> items)
        {
            _entities.SystemValues.RemoveRange(items);
            return items;
        }

        public SystemValue Update(SystemValue item)
        {
            _entities.Entry(item).State = System.Data.Entity.EntityState.Modified;
            return item;
        }
    }
}
