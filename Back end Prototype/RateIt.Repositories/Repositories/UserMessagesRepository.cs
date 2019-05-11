using RateIt.Model;
using RateIt.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Repositories.Repositories
{
    public class UserMessagesRepository : BaseRepository, IRepository<UserMessage>
    {

        public UserMessagesRepository(MoralityNetworkEntities entities) : base(entities)
        { }

        public UserMessage Add(UserMessage item)
        {
            _entities.UserMessages.Add(item);
            return item;
        }

        public IEnumerable<UserMessage> GetAll()
        {
            return _entities.UserMessages;
        }

        public UserMessage Remove(UserMessage item)
        {
            _entities.UserMessages.Remove(item);
            return item;
        }

        public IList<UserMessage> RemoveList(IList<UserMessage> items)
        {
            _entities.UserMessages.RemoveRange(items);
            return items;
        }

        public UserMessage Update(UserMessage item)
        {
            _entities.Entry(item).State = System.Data.Entity.EntityState.Modified;
            return item;
        }
    }
}
