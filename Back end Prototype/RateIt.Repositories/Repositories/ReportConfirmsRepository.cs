using RateIt.Model;
using RateIt.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Repositories.Repositories
{
    public class ReportConfirmsRepository : BaseRepository, IRepository<ReportConfirm>
    {

        public ReportConfirmsRepository(MoralityNetworkEntities entities) : base(entities)
        { }

        public ReportConfirm Add(ReportConfirm item)
        {
            _entities.ReportConfirms.Add(item);
            return item;
        }

        public IEnumerable<ReportConfirm> GetAll()
        {
            return _entities.ReportConfirms;
        }

        public ReportConfirm Remove(ReportConfirm item)
        {
            _entities.ReportConfirms.Remove(item);
            return item;
        }

        public IList<ReportConfirm> RemoveList(IList<ReportConfirm> items)
        {
            _entities.ReportConfirms.RemoveRange(items);
            return items;
        }

        public ReportConfirm Update(ReportConfirm item)
        {
            _entities.Entry(item).State = System.Data.Entity.EntityState.Modified;
            return item;
        }
    }
}
