using Moq;
using NUnit.Framework;
using RateIt.Model;
using RateIt.Repositories.Interfaces;
using RateIt.Services;
using RateIt.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.TestSuite.Service
{
    public class SubDirectoryServiceTests
    {
        private ISubDirectoryService _subdirectoryService;
        private Mock<IRepository<SubDirectory>> _subDirectoryRepository;
        private Mock<ISiteService> _siteService;

        [SetUp]
        public void Setup()
        {
            _subDirectoryRepository = new Mock<IRepository<SubDirectory>>();
            _siteService = new Mock<ISiteService>();

            _siteService.Setup(x => x.FindOrInsertSite(It.Is<string>(s => s == "https://my.gearhost.com/Databases/Details/moralitynetwork")));

            _subdirectoryService = new SubDirectoryService(_subDirectoryRepository.Object, _siteService.Object);
        }

        [Test]
        public void Test()
        {
            var cleanName = _subdirectoryService.CleanSubDirectoryName("https://my.gearhost.com/Databases/Details/moralitynetwork");
            Assert.IsNotNull(cleanName);
        }

    }
}
