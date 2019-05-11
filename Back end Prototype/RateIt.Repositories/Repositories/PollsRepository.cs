using RateIt.Model;
using RateIt.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Repositories.Repositories
{
    public class PollsRepository : BaseRepository, IRepository<Poll>
    {

        public PollsRepository(MoralityNetworkEntities entities) : base(entities)
        { }

        public Poll Add(Poll item)
        {
            _entities.Polls.Add(item);
            return item;
        }

        public IEnumerable<Poll> GetAll()
        {
            return _entities.Polls;
        }

        public Poll Remove(Poll item)
        {
            _entities.Polls.Remove(item);
            return item;
        }

        public IList<Poll> RemoveList(IList<Poll> items)
        {
            _entities.Polls.RemoveRange(items);
            return items;
        }

        public Poll Update(Poll item)
        {
            _entities.Entry(item).State = System.Data.Entity.EntityState.Modified;
            return item;
        }
    }
}
