using RateIt.Model;
using RateIt.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Repositories.Repositories
{
    public class PaymentTransferRepository : BaseRepository, IRepository<PaymentTransfer>
    {

        public PaymentTransferRepository(MoralityNetworkEntities entities) : base(entities)
        { }

        public PaymentTransfer Add(PaymentTransfer item)
        {
            _entities.PaymentTransfers.Add(item);
            return item;
        }

        public IEnumerable<PaymentTransfer> GetAll()
        {
            return _entities.PaymentTransfers;
        }

        public PaymentTransfer Remove(PaymentTransfer item)
        {
            _entities.PaymentTransfers.Remove(item);
            return item;
        }

        public IList<PaymentTransfer> RemoveList(IList<PaymentTransfer> items)
        {
            _entities.PaymentTransfers.RemoveRange(items);
            return items;
        }

        public PaymentTransfer Update(PaymentTransfer item)
        {
            _entities.Entry(item).State = System.Data.Entity.EntityState.Modified;
            return item;
        }
    }
}
