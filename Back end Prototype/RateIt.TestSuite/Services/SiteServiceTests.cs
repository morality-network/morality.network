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
    public class SiteServiceTests
    {
        private ISiteService _siteService;
        private Mock<IRepository<Site>> _siteRepository;

        [SetUp]
        public void Setup()
        {
            _siteRepository = new Mock<IRepository<Site>>();


            _siteService = new SiteService(_siteRepository.Object);
        }

        [Test]
        public void CleanSubDirectoryNameV1Test()
        {
            var google = "https://www.google.com/search?q=c%23+working+with+url&rlz=1C1CHBD_en-GBGB777GB777&oq=c%23+working+with+url&aqs=chrome..69i57j69i60j69i58j69i65j69i60j69i61.6282j0j4&sourceid=chrome&ie=UTF-8";
            var cleanName = _siteService.GetCleanName(google);
            Assert.IsNotNull(cleanName);
            Assert.IsInstanceOf<string>(cleanName);
            Assert.AreEqual("www.google.com", cleanName);
        }

        [Test]
        public void CleanSubDirectoryNameV2Test()
        {
            var gearHost = "https://my.gearhost.com/Databases/Details/moralitynetwork";
            var cleanName = _siteService.GetCleanName(gearHost);
            Assert.IsNotNull(cleanName);
            Assert.IsInstanceOf<string>(cleanName);
            Assert.AreEqual("my.gearhost.com", cleanName);
        }

    }
}
