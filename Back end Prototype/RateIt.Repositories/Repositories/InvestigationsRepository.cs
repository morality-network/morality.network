using RateIt.Model;
using RateIt.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Repositories.Repositories
{
    public class InvestigationsRepository : BaseRepository, IRepository<Investigation>
    {

        public InvestigationsRepository(MoralityNetworkEntities entities) : base(entities)
        { }

        public Investigation Add(Investigation item)
        {
            _entities.Investigations.Add(item);
            return item;
        }

        public IEnumerable<Investigation> GetAll()
        {
            return _entities.Investigations;
        }

        public Investigation Remove(Investigation item)
        {
            _entities.Investigations.Remove(item);
            return item;
        }

        public IList<Investigation> RemoveList(IList<Investigation> items)
        {
            _entities.Investigations.RemoveRange(items);
            return items;
        }

        public Investigation Update(Investigation item)
        {
            _entities.Entry(item).State = System.Data.Entity.EntityState.Modified;
            return item;
        }
    }
}
