using NUnit.Framework;
using RateItRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.TestSuite.Repository
{
    public class BaseRepositoryTests
    {
        private BaseTestRepository _baseRepo = new BaseTestRepository();

        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public void FormattedSiteNameTest()
        {
            var formattedSiteName = _baseRepo.GetSiteName("https://www.google.com");
            Assert.IsInstanceOf<string>(formattedSiteName);
            Assert.IsNotNull(formattedSiteName);
            Assert.AreEqual("www.google.com", formattedSiteName);
        }

        [Test]
        public void FormattedSiteNameFailTest()
        {
            var ex = Assert.Throws<System.UriFormatException>(() => _baseRepo.GetSiteName("www.google.com"));
        }

        [Test]
        public void FormattedSiteNameDudAddressTest()
        {
            var ex = Assert.Throws<System.ArgumentNullException>(() => _baseRepo.GetSiteName(null));
        }

    }
    //To use above (as base repository is abstract -> cannot instantiate
    public class BaseTestRepository : BaseRepository { }
}
