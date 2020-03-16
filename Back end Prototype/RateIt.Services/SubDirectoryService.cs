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
                if (subDirectoryName != null)
                    return AddSubDirectory(site, subDirectoryName);
            }
            return null;
        }

        public SubDirectory AddSubDirectory(Site site, string subDirectoryName)
        {
            var subDirectory = _subDirectoryRepository.GetAll().FirstOrDefault(x => x.Name == subDirectoryName && x.SiteId == site.Id);
            if (subDirectory == null)
            {
                // Then we need to add (first time been)
                subDirectory = new SubDirectory()
                {
                    SiteId = site.Id,
                    Name = subDirectoryName,
                    Timestamp = DateTime.Now
                };
                _subDirectoryRepository.Add(subDirectory);
                // Return if saved
                if (Convert.ToBoolean(_subDirectoryRepository.Save()))
                    return subDirectory;
                // Didnt save, return null
                return null;
            }
            // Return existing
            return subDirectory;
        }

        public string CleanSubDirectoryName(string url)
        {
            if (!string.IsNullOrEmpty(url))
            {
                var uri = new Uri(url);
                var subDirectory = uri.AbsolutePath.ToLower();
                if (subDirectory.Count() == 1 && subDirectory[0] == '/') return string.Empty;
                return subDirectory.Replace("/", "");
            }
            return null;
        }
    }
}
