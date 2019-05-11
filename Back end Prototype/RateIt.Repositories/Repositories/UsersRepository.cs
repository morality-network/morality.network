using RateIt.Model;
using RateIt.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Repositories.Repositories
{
    public class UsersRepository : BaseRepository, IRepository<User>
    {

        public UsersRepository(MoralityNetworkEntities entities) : base(entities)
        { }

        public User Add(User item)
        {
            _entities.Users.Add(item);
            return item;
        }

        public IEnumerable<User> GetAll()
        {
            return _entities.Users;
        }

        public User Remove(User item)
        {
            _entities.Users.Remove(item);
            return item;
        }

        public IList<User> RemoveList(IList<User> items)
        {
            _entities.Users.RemoveRange(items);
            return items;
        }

        public User Update(User item)
        {
            _entities.Entry(item).State = System.Data.Entity.EntityState.Modified;
            return item;
        }
    }
}
