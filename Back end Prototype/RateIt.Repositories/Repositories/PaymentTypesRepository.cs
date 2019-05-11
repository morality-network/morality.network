using RateIt.Model;
using RateIt.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Repositories.Repositories
{
    public class PaymentTypeRepository : BaseRepository, IRepository<PaymentType>
    {

        public PaymentTypeRepository(MoralityNetworkEntities entities) : base(entities)
        { }

        public PaymentType Add(PaymentType item)
        {
            _entities.PaymentTypes.Add(item);
            return item;
        }

        public IEnumerable<PaymentType> GetAll()
        {
            return _entities.PaymentTypes;
        }

        public PaymentType Remove(PaymentType item)
        {
            _entities.PaymentTypes.Remove(item);
            return item;
        }

        public IList<PaymentType> RemoveList(IList<PaymentType> items)
        {
            _entities.PaymentTypes.RemoveRange(items);
            return items;
        }

        public PaymentType Update(PaymentType item)
        {
            _entities.Entry(item).State = System.Data.Entity.EntityState.Modified;
            return item;
        }
    }
}
