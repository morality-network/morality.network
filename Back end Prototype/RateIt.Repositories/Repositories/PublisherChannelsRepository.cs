using RateIt.Model;
using RateIt.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Repositories.Repositories
{
    public class PublisherChannelsRepository : BaseRepository, IRepository<PublisherChannel>
    {

        public PublisherChannelsRepository(MoralityNetworkEntities entities) : base(entities)
        { }

        public PublisherChannel Add(PublisherChannel item)
        {
            _entities.PublisherChannels.Add(item);
            return item;
        }

        public IEnumerable<PublisherChannel> GetAll()
        {
            return _entities.PublisherChannels;
        }

        public PublisherChannel Remove(PublisherChannel item)
        {
            _entities.PublisherChannels.Add(item);
            return item;
        }

        public IList<PublisherChannel> RemoveList(IList<PublisherChannel> items)
        {
            _entities.PublisherChannels.RemoveRange(items);
            return items;
        }

        public PublisherChannel Update(PublisherChannel item)
        {
            _entities.Entry(item).State = System.Data.Entity.EntityState.Modified;
            return item;
        }
    }
}
