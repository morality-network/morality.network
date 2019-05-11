using RateIt.Model;
using RateIt.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Repositories.Repositories
{
    public class UserPollingAnswersRepository : BaseRepository, IRepository<UserPollingAnswer>
    {

        public UserPollingAnswersRepository(MoralityNetworkEntities entities) : base(entities)
        { }

        public UserPollingAnswer Add(UserPollingAnswer item)
        {
            _entities.UserPollingAnswers.Add(item);
            return item;
        }

        public IEnumerable<UserPollingAnswer> GetAll()
        {
            return _entities.UserPollingAnswers;
        }

        public UserPollingAnswer Remove(UserPollingAnswer item)
        {
            _entities.UserPollingAnswers.Remove(item);
            return item;
        }

        public IList<UserPollingAnswer> RemoveList(IList<UserPollingAnswer> items)
        {
            _entities.UserPollingAnswers.RemoveRange(items);
            return items;
        }

        public UserPollingAnswer Update(UserPollingAnswer item)
        {
            _entities.Entry(item);
            return item;
        }
    }
}
