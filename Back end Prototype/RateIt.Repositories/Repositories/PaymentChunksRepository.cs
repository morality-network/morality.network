using RateIt.Model;
using RateIt.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Repositories.Repositories
{
    public class PaymentChunksRepository : BaseRepository, IRepository<PaymentChunk>
    {

        public PaymentChunksRepository(MoralityNetworkEntities entities) : base(entities)
        { }

        public PaymentChunk Add(PaymentChunk item)
        {
            _entities.PaymentChunks.Add(item);
            return item;
        }

        public IEnumerable<PaymentChunk> GetAll()
        {
            return _entities.PaymentChunks;
        }

        public PaymentChunk Remove(PaymentChunk item)
        {
            _entities.PaymentChunks.Remove(item);
            return item;
        }

        public IList<PaymentChunk> RemoveList(IList<PaymentChunk> items)
        {
            _entities.PaymentChunks.RemoveRange(items);
            return items;
        }

        public PaymentChunk Update(PaymentChunk item)
        {
            _entities.Entry(item).State = System.Data.Entity.EntityState.Modified;
            return item;
        }
    }
}
