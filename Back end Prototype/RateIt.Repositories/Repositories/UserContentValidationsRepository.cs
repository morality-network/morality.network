using RateIt.Model;
using RateIt.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Repositories.Repositories
{
    public class UserContentValidationsRepository : BaseRepository, IRepository<UserContentValidation>
    {

        public UserContentValidationsRepository(MoralityNetworkEntities entities) : base(entities)
        { }

        public UserContentValidation Add(UserContentValidation item)
        {
            _entities.UserContentValidations.Add(item);
            return item;
        }

        public IEnumerable<UserContentValidation> GetAll()
        {
            return _entities.UserContentValidations;
        }

        public UserContentValidation Remove(UserContentValidation item)
        {
            _entities.UserContentValidations.Remove(item);
            return item;
        }

        public IList<UserContentValidation> RemoveList(IList<UserContentValidation> items)
        {
            _entities.UserContentValidations.RemoveRange(items);
            return items;
        }

        public UserContentValidation Update(UserContentValidation item)
        {
            _entities.Entry(item).State = System.Data.Entity.EntityState.Modified;
            return item;
        }
    }
}
