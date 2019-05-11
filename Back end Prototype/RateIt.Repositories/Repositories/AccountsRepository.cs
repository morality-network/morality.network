using RateIt.Model;
using RateIt.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Repositories.Repositories
{
    public class AccountsRepository : BaseRepository, IRepository<Account>
    {

        public AccountsRepository(MoralityNetworkEntities entities) : base(entities)
        { }

        public Account Add(Account item)
        {
            _entities.Accounts.Add(item);
            return item;
        }

        public IEnumerable<Account> GetAll()
        {
            return _entities.Accounts;
        }

        public Account Remove(Account item)
        {
            _entities.Accounts.Remove(item);
            return item;
        }

        public IList<Account> RemoveList(IList<Account> items)
        {
            _entities.Accounts.RemoveRange(items);
            return items;
        }

        public Account Update(Account item)
        {
            _entities.Entry(item).State = System.Data.Entity.EntityState.Modified;
            return item;
        }
    }
}
