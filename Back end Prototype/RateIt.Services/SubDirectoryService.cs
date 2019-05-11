using RateIt.Model;
using RateIt.Repositories.Interfaces;
using RateIt.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Services
{
    public class SubDirectoryService : ISubDirectoryService
    {
        private readonly IRepository<SubDirectory> _subDirectoryRepository;
        private readonly ISiteService _siteService;

        public SubDirectoryService(IRepository<SubDirectory> subDirectoryRepository, ISiteService siteService)
        {
            _subDirectoryRepository = subDirectoryRepository;
            _siteService = siteService;
        }

        public SubDirectory FindOrInsertSite(string url)
        {
            var site = _siteService.FindOrInsertSite(url);
            if(site != null)
            {
                var subDirectoryName = CleanSubDirectoryName(url);
                if (!string.IsNullOrEmpty(subDirectoryName))
                {
                    var subDirectory = new SubDirectory()
                    {
                        SiteId = site.Id,
                        Name = subDirectoryName,
                        Timestamp = DateTime.Now
                    };
                    _subDirectoryRepository.Add(subDirectory);
                    _subDirectoryRepository.Save();
                    return subDirectory;
                }
            }
            return null;
        }

        public string CleanSubDirectoryName(string url)
        {
            if (!string.IsNullOrEmpty(url))
            {
                var uri = new Uri(url);
                var subDirectory = uri.AbsolutePath.ToLower();
                if (subDirectory.Count() == 1 && subDirectory[0] == '/') return string.Empty;
                return subDirectory;
            }
            return null;
        }
    }
}
