using RateIt.Model;
using RateIt.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Repositories.Repositories
{
    public class SubDirectorysRepository : BaseRepository, IRepository<SubDirectory>
    {

        public SubDirectorysRepository(MoralityNetworkEntities entities) : base(entities)
        { }

        public SubDirectory Add(SubDirectory item)
        {
            _entities.SubDirectorys.Add(item);
            return item;
        }

        public IEnumerable<SubDirectory> GetAll()
        {
            return _entities.SubDirectorys;
        }

        public SubDirectory Remove(SubDirectory item)
        {
            _entities.SubDirectorys.Remove(item);
            return item;
        }

        public IList<SubDirectory> RemoveList(IList<SubDirectory> items)
        {
            _entities.SubDirectorys.RemoveRange(items);
            return items;
        }

        public SubDirectory Update(SubDirectory item)
        {
            _entities.Entry(item).State = System.Data.Entity.EntityState.Modified;
            return item;
        }
    }
}
