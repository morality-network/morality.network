using RateIt.Model;
using RateIt.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Repositories.Repositories
{
    public class CreditTransactionRepository : BaseRepository, IRepository<CreditTransaction>
    {

        public CreditTransactionRepository(MoralityNetworkEntities entities) : base(entities)
        { }

        public CreditTransaction Add(CreditTransaction item)
        {
            _entities.CreditTransactions.Add(item);
            return item;
        }

        public IEnumerable<CreditTransaction> GetAll()
        {
            return _entities.CreditTransactions;
        }

        public CreditTransaction Remove(CreditTransaction item)
        {
            _entities.CreditTransactions.Remove(item);
            return item;
        }

        public IList<CreditTransaction> RemoveList(IList<CreditTransaction> items)
        {
            _entities.CreditTransactions.RemoveRange(items);
            return items;
        }

        public CreditTransaction Update(CreditTransaction item)
        {
            _entities.Entry(item).State = System.Data.Entity.EntityState.Modified;
            return item;
        }
    }
}
