using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RateIt.Model;

namespace RateIt.Services.Interfaces
{
    public interface ISiteService
    {
        Site GetSiteByUrl(string url);
        string GetCleanName(string url);
        Site AddSite(string url);
        Site FindOrInsertSite(string url);
        Site GetSiteById(long siteId);
    }
}
