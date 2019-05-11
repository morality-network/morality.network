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
        public void CleanSubDirectoryNameV1Test()
        {
            var google = "https://www.google.com/search?q=c%23+working+with+url&rlz=1C1CHBD_en-GBGB777GB777&oq=c%23+working+with+url&aqs=chrome..69i57j69i60j69i58j69i65j69i60j69i61.6282j0j4&sourceid=chrome&ie=UTF-8";
            var cleanName = _subdirectoryService.CleanSubDirectoryName(google);
            Assert.IsNotNull(cleanName);
            Assert.IsInstanceOf<string>(cleanName);
            Assert.AreEqual("/search", cleanName);
        }

        [Test]
        public void CleanSubDirectoryNameV2Test()
        {
            var gearHost = "https://my.gearhost.com/Databases/Details/moralitynetwork";
            var cleanName = _subdirectoryService.CleanSubDirectoryName(gearHost);
            Assert.IsNotNull(cleanName);
            Assert.IsNotNull(cleanName);
            Assert.IsInstanceOf<string>(cleanName);
            Assert.AreEqual("/databases/details/moralitynetwork", cleanName);
        }

        [Test]
        public void CleanSubDirectoryNameV3Test()
        {
            var gearHost = "https://my.gearhost.com/";
            var cleanName = _subdirectoryService.CleanSubDirectoryName(gearHost);
            Assert.IsNotNull(cleanName);
            Assert.IsNotNull(cleanName);
            Assert.IsInstanceOf<string>(cleanName);
            Assert.AreEqual("", cleanName);
        }
    }
}
