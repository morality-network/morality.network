using RateIt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly MoralityNetworkEntities _entities;

        public BaseRepository(MoralityNetworkEntities entities)
        {
            _entities = entities;
        }

        public int Save()
        {
            return _entities.SaveChanges();
        }

    }
}
