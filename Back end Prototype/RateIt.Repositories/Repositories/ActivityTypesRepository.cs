using RateIt.Model;
using RateIt.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Repositories.Repositories
{
    public class ActivityTypesRepository : BaseRepository, IRepository<ActivityType>
    {

        public ActivityTypesRepository(MoralityNetworkEntities entities) : base(entities)
        { }

        public ActivityType Add(ActivityType item)
        {
            _entities.ActivityTypes.Add(item);
            return item;
        }

        public IEnumerable<ActivityType> GetAll()
        {
            return _entities.ActivityTypes;
        }

        public ActivityType Remove(ActivityType item)
        {
            _entities.ActivityTypes.Remove(item);
            return item;
        }

        public IList<ActivityType> RemoveList(IList<ActivityType> items)
        {
            _entities.ActivityTypes.RemoveRange(items);
            return items;
        }

        public ActivityType Update(ActivityType item)
        {
            _entities.Entry(item).State = System.Data.Entity.EntityState.Modified;
            return item;
        }
    }
}
