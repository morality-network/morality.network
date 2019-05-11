using RateIt.Model;
using RateIt.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Repositories.Repositories
{
    public class TransactionsRepository : BaseRepository, IRepository<Transaction>
    {

        public TransactionsRepository(MoralityNetworkEntities entities) : base(entities)
        { }

        public Transaction Add(Transaction item)
        {
            _entities.Transactions.Add(item);
            return item;
        }

        public IEnumerable<Transaction> GetAll()
        {
            return _entities.Transactions;
        }

        public Transaction Remove(Transaction item)
        {
            _entities.Transactions.Remove(item);
            return item;
        }

        public IList<Transaction> RemoveList(IList<Transaction> items)
        {
            _entities.Transactions.RemoveRange(items);
            return items;
        }

        public Transaction Update(Transaction item)
        {
            _entities.Entry(item).State = System.Data.Entity.EntityState.Modified;
            return item;
        }
    }
}
