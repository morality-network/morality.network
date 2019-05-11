using RateIt.Model;
using RateIt.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Repositories.Repositories
{
    public class ReportClaimsRepository : BaseRepository, IRepository<ReportClaim>
    {

        public ReportClaimsRepository(MoralityNetworkEntities entities) : base(entities)
        { }

        public ReportClaim Add(ReportClaim item)
        {
            _entities.ReportClaims.Add(item);
            return item;
        }

        public IEnumerable<ReportClaim> GetAll()
        {
            return _entities.ReportClaims;
        }

        public ReportClaim Remove(ReportClaim item)
        {
            _entities.ReportClaims.Remove(item);
            return item;
        }

        public IList<ReportClaim> RemoveList(IList<ReportClaim> items)
        {
            _entities.ReportClaims.RemoveRange(items);
            return items;
        }

        public ReportClaim Update(ReportClaim item)
        {
            _entities.Entry(item).State = System.Data.Entity.EntityState.Modified;
            return item;
        }
    }
}
