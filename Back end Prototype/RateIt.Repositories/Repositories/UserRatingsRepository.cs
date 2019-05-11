using RateIt.Model;
using RateIt.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Repositories.Repositories
{
    public class UserRatingsRepository : BaseRepository, IRepository<UserRating>
    {

        public UserRatingsRepository(MoralityNetworkEntities entities) : base(entities)
        { }

        public UserRating Add(UserRating item)
        {
            _entities.UserRatings.Add(item);
            return item;
        }

        public IEnumerable<UserRating> GetAll()
        {
            return _entities.UserRatings;
        }

        public UserRating Remove(UserRating item)
        {
            _entities.UserRatings.Remove(item);
            return item;
        }

        public IList<UserRating> RemoveList(IList<UserRating> items)
        {
            _entities.UserRatings.RemoveRange(items);
            return items;
        }

        public UserRating Update(UserRating item)
        {
            _entities.Entry(item).State = System.Data.Entity.EntityState.Modified;
            return item;
        }
    }
}
