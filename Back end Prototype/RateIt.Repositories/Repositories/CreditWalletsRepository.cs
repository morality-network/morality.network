using RateIt.Model;
using RateIt.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Repositories.Repositories
{
    public class CreditWalletsRepository : BaseRepository, IRepository<CreditWallet>
    {

        public CreditWalletsRepository(MoralityNetworkEntities entities) : base(entities)
        { }

        public CreditWallet Add(CreditWallet item)
        {
            _entities.CreditWallets.Add(item);
            return item;
        }

        public IEnumerable<CreditWallet> GetAll()
        {
            return _entities.CreditWallets;
        }

        public CreditWallet Remove(CreditWallet item)
        {
            _entities.CreditWallets.Remove(item);
            return item;
        }

        public IList<CreditWallet> RemoveList(IList<CreditWallet> items)
        {
            _entities.CreditWallets.RemoveRange(items);
            return items;
        }

        public CreditWallet Update(CreditWallet item)
        {
            _entities.Entry(item).State = System.Data.Entity.EntityState.Modified;
            return item;
        }
    }
}
