using RateIt.Model;
using RateIt.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Repositories.Repositories
{
    public class CrowdfundingCampaignsRepository : BaseRepository, IRepository<CrowdfundingCampaign>
    {

        public CrowdfundingCampaignsRepository(MoralityNetworkEntities entities) : base(entities)
        { }

        public CrowdfundingCampaign Add(CrowdfundingCampaign item)
        {
            _entities.CrowdfundingCampaigns.Add(item);
            return item;
        }

        public IEnumerable<CrowdfundingCampaign> GetAll()
        {
            return _entities.CrowdfundingCampaigns;
        }

        public CrowdfundingCampaign Remove(CrowdfundingCampaign item)
        {
            _entities.CrowdfundingCampaigns.Remove(item);
            return item;
        }

        public IList<CrowdfundingCampaign> RemoveList(IList<CrowdfundingCampaign> items)
        {
            _entities.CrowdfundingCampaigns.RemoveRange(items);
            return items;
        }

        public CrowdfundingCampaign Update(CrowdfundingCampaign item)
        {
            _entities.Entry(item).State = System.Data.Entity.EntityState.Modified;
            return item;
        }
    }
}
