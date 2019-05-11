using Moq;
using NUnit.Framework;
using RateIt.Model;
using RateItRepository;
using RateItRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.TestSuite.Repository
{
    public class SiteRepositoryTests
    {
        private List<Site> _data;
        private Mock<DbSet<Site>> _mockSet;
        private Mock<RIEntities> _mockContext;
        private ISiteRepository _siteRepository;

        [SetUp]
        public void Setup()
        {
            _data = this.GetTestData();
            _mockSet = new Mock<DbSet<Site>>();
            _mockSet.As<IDbAsyncEnumerable<Site>>().Setup(m => m.GetAsyncEnumerator()).Returns(new TestDbAsyncEnumerator<Site>(_data.AsQueryable().GetEnumerator()));
            _mockSet.As<IQueryable<Site>>().Setup(m => m.Provider).Returns(new TestDbAsyncQueryProvider<Site>(_data.AsQueryable().Provider));
            _mockSet.As<IQueryable<Site>>().Setup(m => m.Expression).Returns(_data.AsQueryable().Expression);
            _mockSet.As<IQueryable<Site>>().Setup(m => m.ElementType).Returns(_data.AsQueryable().ElementType);
            _mockSet.As<IQueryable<Site>>().Setup(m => m.GetEnumerator()).Returns(_data.AsQueryable().GetEnumerator());
            _mockSet.Setup(x => x.Add(It.IsAny<Site>())).Callback<Site>((s) => _data.Add(s)).Returns((Site u) => u);
            _mockSet.Setup(x => x.Remove(It.IsAny<Site>())).Callback<Site>((s) => _data.Remove(s));
            _mockSet.Setup(x => x.Find(It.IsAny<object[]>())).Returns<object[]>(x => (_data as List<Site>).FirstOrDefault(y => y.id == (int)x[0]) as Site);

            _mockContext = new Mock<RIEntities>();
            _mockContext.Setup(c => c.Sites).Returns(_mockSet.Object);
            _mockContext.Setup(m => m.Set<Site>()).Returns(_mockSet.Object);
            _mockContext.Setup(x => x.SaveChanges()).Returns(1);

            _siteRepository = new SiteRepository(_mockContext.Object);
        }
      
        [Test]
        public void GetSiteIdByNameExistsTest()
        {
            var successId = _siteRepository.GetSiteIdByName("http://www.google.com");
            Assert.IsInstanceOf<long>(successId);
            Assert.AreEqual(7, successId);
        }

        [Test]
        public void GetSiteIdByNameNoneExistsTest()
        {
            var successId = _siteRepository.GetSiteIdByName("http://www.google2.com");
            Assert.IsInstanceOf<long>(successId);
            Assert.AreEqual(-1, successId);
        }

        [Test]
        public void AddSiteTests()
        {
            var successId = _siteRepository.AddSite("http://www.google2.com");
            Assert.IsInstanceOf<long>(successId);
            Assert.AreEqual(0, successId);
        }
        [Test]
        public void AddSiteNullCheckTests()
        {
            var successId = _siteRepository.AddSite(null);
            Assert.IsInstanceOf<long>(successId);
            Assert.AreEqual(-1, successId);
        }

        private List<Site> GetTestData()
        {
            return new List<Site>()
            {
                new Site()
                {
                    id = 7,
                    name = "www.google.com"
                },
                new Site()
                {
                    id = 12,
                    name = "www.bbc.co.uk"
                }
            };
        }
    }
}
