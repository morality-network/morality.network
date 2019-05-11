using RateIt.Model;
using RateIt.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Repositories.Repositories
{
    public class ContentTypeRepository : BaseRepository, IRepository<ContentType>
    {

        public ContentTypeRepository(MoralityNetworkEntities entities) : base(entities)
        { }

        public ContentType Add(ContentType item)
        {
            _entities.ContentTypes.Add(item);
            return item;
        }

        public IEnumerable<ContentType> GetAll()
        {
            return _entities.ContentTypes;
        }

        public ContentType Remove(ContentType item)
        {
            _entities.ContentTypes.Remove(item);
            return item;
        }

        public IList<ContentType> RemoveList(IList<ContentType> items)
        {
            _entities.ContentTypes.RemoveRange(items);
            return items;
        }

        public ContentType Update(ContentType item)
        {
            _entities.Entry(item).State = System.Data.Entity.EntityState.Modified;
            return item;
        }
    }
}
