using RateIt.Model;
using RateIt.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Repositories.Repositories
{
    public class CurrencysRepository : BaseRepository, IRepository<Currency>
    {

        public CurrencysRepository(MoralityNetworkEntities entities) : base(entities)
        { }

        public Currency Add(Currency item)
        {
            _entities.Currencys.Add(item);
            return item;
        }

        public IEnumerable<Currency> GetAll()
        {
            return _entities.Currencys;
        }

        public Currency Remove(Currency item)
        {
            _entities.Currencys.Remove(item);
            return item;
        }

        public IList<Currency> RemoveList(IList<Currency> items)
        {
            _entities.Currencys.RemoveRange(items);
            return items;
        }

        public Currency Update(Currency item)
        {
            _entities.Entry(item).State = System.Data.Entity.EntityState.Modified;
            return item;
        }
    }
}
