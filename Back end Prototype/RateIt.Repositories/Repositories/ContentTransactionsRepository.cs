using RateIt.Model;
using RateIt.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Repositories.Repositories
{
    public class ContentTransactionsRepository : BaseRepository, IRepository<ContentTransaction>
    {

        public ContentTransactionsRepository(MoralityNetworkEntities entities) : base(entities)
        { }

        public ContentTransaction Add(ContentTransaction item)
        {
            _entities.ContentTransactions.Add(item);
            return item;
        }

        public IEnumerable<ContentTransaction> GetAll()
        {
            return _entities.ContentTransactions;
        }

        public ContentTransaction Remove(ContentTransaction item)
        {
            _entities.ContentTransactions.Remove(item);
            return item;
        }

        public IList<ContentTransaction> RemoveList(IList<ContentTransaction> items)
        {
            _entities.ContentTransactions.RemoveRange(items);
            return items;
        }

        public ContentTransaction Update(ContentTransaction item)
        {
            _entities.Entry(item).State = System.Data.Entity.EntityState.Modified;
            return item;
        }
    }
}
