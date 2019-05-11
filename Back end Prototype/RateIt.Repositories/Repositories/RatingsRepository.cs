using RateIt.Model;
using RateIt.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Repositories.Repositories
{
    public class RatingsRepository : BaseRepository, IRepository<Rating>
    {

        public RatingsRepository(MoralityNetworkEntities entities) : base(entities)
        { }

        public Rating Add(Rating item)
        {
            _entities.Ratings.Add(item);
            return item;
        }

        public IEnumerable<Rating> GetAll()
        {
            return _entities.Ratings;
        }

        public Rating Remove(Rating item)
        {
            _entities.Ratings.Remove(item);
            return item;
        }

        public IList<Rating> RemoveList(IList<Rating> items)
        {
            _entities.Ratings.RemoveRange(items);
            return items;
        }

        public Rating Update(Rating item)
        {
            _entities.Entry(item).State = System.Data.Entity.EntityState.Modified;
            return item;
        }
    }
}
