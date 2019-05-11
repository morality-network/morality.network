using RateIt.Model;
using RateIt.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Repositories.Repositories
{
    public class UpvotesRepository : BaseRepository, IRepository<Upvote>
    {

        public UpvotesRepository(MoralityNetworkEntities entities) : base(entities)
        { }

        public Upvote Add(Upvote item)
        {
            _entities.Upvotes.Add(item);
            return item;
        }

        public IEnumerable<Upvote> GetAll()
        {
            return _entities.Upvotes;
        }

        public Upvote Remove(Upvote item)
        {
            _entities.Upvotes.Remove(item);
            return item;
        }

        public IList<Upvote> RemoveList(IList<Upvote> items)
        {
            _entities.Upvotes.RemoveRange(items);
            return items;
        }

        public Upvote Update(Upvote item)
        {
            _entities.Entry(item).State = System.Data.Entity.EntityState.Modified;
            return item;
        }
    }
}
