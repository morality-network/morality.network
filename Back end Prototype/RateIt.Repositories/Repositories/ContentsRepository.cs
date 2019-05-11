using RateIt.Model;
using RateIt.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Repositories.Repositories
{
    public class ContentsRepository : BaseRepository, IRepository<Content>
    {

        public ContentsRepository(MoralityNetworkEntities entities) : base(entities)
        { }

        public Content Add(Content item)
        {
            _entities.Contents.Add(item);
            return item;
        }

        public IEnumerable<Content> GetAll()
        {
            return _entities.Contents;
        }

        public Content Remove(Content item)
        {
            _entities.Contents.Remove(item);
            return item;
        }

        public IList<Content> RemoveList(IList<Content> items)
        {
            _entities.Contents.RemoveRange(items);
            return items;
        }

        public Content Update(Content item)
        {
            _entities.Entry(item).State = System.Data.Entity.EntityState.Modified;
            return item;
        }
    }
}
