using RateIt.Model;
using RateIt.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Repositories.Repositories
{
    public class ActivitiesRepository : BaseRepository, IRepository<Activity>
    {

        public ActivitiesRepository(MoralityNetworkEntities entities) : base(entities)
        { }

        public Activity Add(Activity item)
        {
            _entities.Activitys.Add(item);
            return item;
        }

        public IEnumerable<Activity> GetAll()
        {
            return _entities.Activitys;
        }

        public Activity Remove(Activity item)
        {
            _entities.Activitys.Remove(item);
            return item;
        }

        public IList<Activity> RemoveList(IList<Activity> items)
        {
            _entities.Activitys.RemoveRange(items);
            return items;
        }

        public Activity Update(Activity item)
        {
            _entities.Entry(item).State = System.Data.Entity.EntityState.Modified;
            return item;
        }
    }
}
