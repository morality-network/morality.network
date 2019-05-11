using RateIt.Model;
using RateIt.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Repositories.Repositories
{
    public class LogsRepository : BaseRepository, IRepository<Log>
    {

        public LogsRepository(MoralityNetworkEntities entities) : base(entities)
        { }

        public Log Add(Log item)
        {
            _entities.Logs.Add(item);
            return item;
        }

        public IEnumerable<Log> GetAll()
        {
            return _entities.Logs;
        }

        public Log Remove(Log item)
        {
            _entities.Logs.Remove(item);
            return item;
        }

        public IList<Log> RemoveList(IList<Log> items)
        {
            _entities.Logs.RemoveRange(items);
            return items;
        }

        public Log Update(Log item)
        {
            _entities.Entry(item).State = System.Data.Entity.EntityState.Modified;
            return item;
        }
    }
}
