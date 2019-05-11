using RateIt.Model;
using RateIt.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Repositories.Repositories
{
    public class WithdrawTransfersRepository : BaseRepository, IRepository<WithdrawTransfer>
    {

        public WithdrawTransfersRepository(MoralityNetworkEntities entities) : base(entities)
        { }

        public WithdrawTransfer Add(WithdrawTransfer item)
        {
            _entities.WithdrawTransfers.Add(item);
            return item;
        }

        public IEnumerable<WithdrawTransfer> GetAll()
        {
            return _entities.WithdrawTransfers;
        }

        public WithdrawTransfer Remove(WithdrawTransfer item)
        {
            _entities.WithdrawTransfers.Remove(item);
            return item;
        }

        public IList<WithdrawTransfer> RemoveList(IList<WithdrawTransfer> items)
        {
            _entities.WithdrawTransfers.RemoveRange(items);
            return items;
        }

        public WithdrawTransfer Update(WithdrawTransfer item)
        {
            _entities.Entry(item).State = System.Data.Entity.EntityState.Modified;
            return item;
        }
    }
}
