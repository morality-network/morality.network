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
    public class RateRepositoryTests
    {
        private List<Rating> _data;
        private Mock<DbSet<Rating>> _mockSet;
        private Mock<RIEntities> _mockContext;
        private IRatingRepository _ratingRepository;
        private Mock<ISiteRepository> _siteRepository;
        private Mock<IUserRepository> _userRepository;
        private Mock<IUserRatingRepository> _userRatingRepository;

        [SetUp]
        public void Setup()
        {
            _data = this.GetTestData();
            _mockSet = new Mock<DbSet<Rating>>();
            _mockSet.As<IDbAsyncEnumerable<Rating>>().Setup(m => m.GetAsyncEnumerator()).Returns(new TestDbAsyncEnumerator<Rating>(_data.AsQueryable().GetEnumerator()));
            _mockSet.As<IQueryable<Rating>>().Setup(m => m.Provider).Returns(new TestDbAsyncQueryProvider<Rating>(_data.AsQueryable().Provider));
            _mockSet.As<IQueryable<Rating>>().Setup(m => m.Expression).Returns(_data.AsQueryable().Expression);
            _mockSet.As<IQueryable<Rating>>().Setup(m => m.ElementType).Returns(_data.AsQueryable().ElementType);
            _mockSet.As<IQueryable<Rating>>().Setup(m => m.GetEnumerator()).Returns(_data.AsQueryable().GetEnumerator());
            _mockSet.Setup(x => x.Add(It.IsAny<Rating>())).Callback<Rating>((s) => _data.Add(s)).Returns((Rating u) => u);
            _mockSet.Setup(x => x.Remove(It.IsAny<Rating>())).Callback<Rating>((s) => _data.Remove(s));
            _mockSet.Setup(x => x.Find(It.IsAny<object[]>())).Returns<object[]>(x => (_data as List<Rating>).FirstOrDefault(y => y.id == (int)x[0]) as Rating);

            _mockContext = new Mock<RIEntities>();
            _mockContext.Setup(c => c.Ratings).Returns(_mockSet.Object);
            _mockContext.Setup(m => m.Set<Rating>()).Returns(_mockSet.Object);
            _mockContext.Setup(x => x.SaveChanges()).Returns(1);

            Mock<DbEntityEntry> mockDbEntry = new Mock<DbEntityEntry>();
            //_mockContext.Setup(c => c.Entry(It.IsAny<object>())).Returns(mockDbEntry.Object);

            _siteRepository = new Mock<ISiteRepository>();
             _userRepository = new Mock<IUserRepository>();
            _userRatingRepository = new Mock<IUserRatingRepository>();

           _ratingRepository = new RatingRepository(_mockContext.Object, _siteRepository.Object, _userRepository.Object,
               _userRatingRepository.Object);
        }

        [Test]
        public void GetRatingBySiteNameTest()
        {
            var result = _ratingRepository.GetRatingBySiteName("www.google.com");
            Assert.IsInstanceOf<Rating>(result);
            Assert.AreEqual(67, result.id);
        }

        [Test]
        public void GetRatingBySiteNameNoneExistTest()
        {
            var result = _ratingRepository.GetRatingBySiteName("www.as.com");
            Assert.IsNull(result);
        }

        [Test]
        public void GetRatingByUrlZeroTest()
        {
            var result = _ratingRepository.GetRatingByUrl("https://www.as.com");
            Assert.IsInstanceOf<double>(result);
            Assert.AreEqual(0.0, result);
        }

        [Test]
        public void GetRatingByUrlTest()
        {
            var result = _ratingRepository.GetRatingByUrl("https://www.google.com");
            Assert.IsInstanceOf<double>(result);
            Assert.AreEqual(1.2, result);
        }

        [Test]
        public void GetRatingByUrlErrorTest()
        {
            var ex = Assert.Throws<System.UriFormatException>(() => _ratingRepository.GetRatingByUrl("www.google.com"));
        }


        [Test]
        public void AddRatingTest()
        {
            var added = _ratingRepository.AddRating(38, 2.4);
            Assert.IsTrue(added);
        }

        [Test]
        public void UpdateRatingTest()
        {
            var updated = _ratingRepository.UpdateRating(67, 4.5);
            var rating = _mockSet.Object.Where(x => x.site_id == 36).First();
            int ratingCount = _mockSet.Object.Count() ;
            Assert.AreEqual(4, ratingCount); 
            Assert.IsTrue(updated);
            Assert.AreEqual(rating.rating1, 4.5);
        }

        [Test]
        public void GetRatingByObjUrlTest()
        {
            var rating = _ratingRepository.GetRatingObjByUrl("https://www.google.com");
            Assert.IsNotNull(rating);
            Assert.IsInstanceOf<Rating>(rating);
            Assert.AreEqual(67, rating.id);
        }

        [Test]
        public void GetRatingByObjUrlFailTest()
        {
            var ex = Assert.Throws<System.UriFormatException>(() => _ratingRepository.GetRatingObjByUrl("www.google.com"));
        }

        private List<Rating> GetTestData()
        {
            return new List<Rating>()
            {
                new Rating()
                {
                    id = 67,
                    site_id = 36,
                    rating1 = 1.2,
                    Site = new Site()
                    {
                        id = 36,
                        name = "www.google.com"
                    }
                },
                 new Rating()
                {
                    id = 68,
                    site_id = 37,
                    rating1 = 2.2,
                    Site = new Site()
                    {
                        id = 37,
                        name = "www.abc.com"
                    }
                },
                  new Rating()
                {
                    id = 69,
                    site_id = 38,
                    rating1 = 1.8,
                    Site = new Site()
                    {
                        id = 38,
                        name = "www.tyy.com"
                    }
                },
                 new Rating() {
                    id =79,
                    site_id =3,
                    rating1 = 1.1,
                    Site = new Site()
                    {
                        id = 3,
                        name = "www.bbc.com"
                    }
                }
            };
        }
    }
}
