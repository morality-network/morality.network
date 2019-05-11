using Moq;
using NUnit.Framework;
using RateIt.Services;
using RateItRepository.Interfaces;
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

        [SetUp]
        public void SetUp()
        {
            var mockRepository = new Mock<ISiteRepository>();
            mockRepository.Setup(x => x.GetSiteIdByName(It.Is<string>(y => y == "https://www.google.com"))).Returns(6);
            mockRepository.Setup(x => x.AddSite(It.Is<string>(y => y == "http://www.bbc.com"))).Returns(47);

            _siteService = new SiteService(mockRepository.Object);
        }

        [Test]
        public void FindOrInsertSiteExistTest()
        {
            var id = _siteService.FindOrInsertSite("https://www.google.com");
            Assert.IsInstanceOf<long>(id);
            Assert.AreEqual(6, id);
        }

        [Test]
        public void FindOrInsertSiteNoneExistTest()
        {
            var id = _siteService.FindOrInsertSite("http://www.bbc.com");
            Assert.IsInstanceOf<long>(id);
            Assert.AreEqual(47, id);
        }

        [Test]
        public void FindOrInsertSiteUrlNullTest()
        {
            var id = _siteService.FindOrInsertSite(null);
            Assert.IsInstanceOf<long>(id);
            Assert.AreEqual(-1, id);
        }
    }
}
