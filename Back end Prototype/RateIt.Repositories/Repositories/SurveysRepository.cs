using RateIt.Model;
using RateIt.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Repositories.Repositories
{
    public class SurveysRepository : BaseRepository, IRepository<Survey>
    {

        public SurveysRepository(MoralityNetworkEntities entities) : base(entities)
        { }

        public Survey Add(Survey item)
        {
            _entities.Surveys.Add(item);
            return item;
        }

        public IEnumerable<Survey> GetAll()
        {
            return _entities.Surveys;
        }

        public Survey Remove(Survey item)
        {
            _entities.Surveys.Remove(item);
            return item;
        }

        public IList<Survey> RemoveList(IList<Survey> items)
        {
            _entities.Surveys.RemoveRange(items);
            return items;
        }

        public Survey Update(Survey item)
        {
            _entities.Entry(item).State = System.Data.Entity.EntityState.Modified;
            return item;
        }
    }
}
