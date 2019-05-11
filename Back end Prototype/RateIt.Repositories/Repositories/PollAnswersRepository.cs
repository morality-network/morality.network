using RateIt.Model;
using RateIt.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Repositories.Repositories
{
    public class PollAnswersRepository : BaseRepository, IRepository<PollAnswer>
    {

        public PollAnswersRepository(MoralityNetworkEntities entities) : base(entities)
        { }

        public PollAnswer Add(PollAnswer item)
        {
            _entities.PollAnswers.Add(item);
            return item;
        }

        public IEnumerable<PollAnswer> GetAll()
        {
            return _entities.PollAnswers;
        }

        public PollAnswer Remove(PollAnswer item)
        {
            _entities.PollAnswers.Remove(item);
            return item;
        }

        public IList<PollAnswer> RemoveList(IList<PollAnswer> items)
        {
            _entities.PollAnswers.RemoveRange(items);
            return items;
        }

        public PollAnswer Update(PollAnswer item)
        {
            _entities.Entry(item).State = System.Data.Entity.EntityState.Modified;
            return item;
        }
    }
}
