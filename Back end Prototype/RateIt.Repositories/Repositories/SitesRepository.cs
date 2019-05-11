using RateIt.Model;
using RateIt.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Repositories.Repositories
{
    public class SitesRepository : BaseRepository, IRepository<Site>
    {

        public SitesRepository(MoralityNetworkEntities entities) : base(entities)
        { }

        public Site Add(Site item)
        {
            _entities.Sites.Add(item);
            return item;
        }

        public IEnumerable<Site> GetAll()
        {
            return _entities.Sites;
        }

        public Site Remove(Site item)
        {
            _entities.Sites.Remove(item);
            return item;
        }

        public IList<Site> RemoveList(IList<Site> items)
        {
            _entities.Sites.RemoveRange(items);
            return items;
        }

        public Site Update(Site item)
        {
            _entities.Entry(item).State = System.Data.Entity.EntityState.Modified;
            return item;
        }
    }
}
