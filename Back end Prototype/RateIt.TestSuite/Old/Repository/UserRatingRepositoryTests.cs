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
    public class UserRatingRepositoryTests
    {

        private Mock<DbSet<UserRating>> _mockRCSet;
        private Mock<RIEntities> _mockContext;
        private IUserRatingRepository _userRatingRepository;

        [SetUp]
        public void Setup()
        {
            _mockContext = new Mock<RIEntities>();

            var _rcData = this.GetTestData();
            _mockRCSet = new Mock<DbSet<UserRating>>();
            _mockRCSet.As<IDbAsyncEnumerable<UserRating>>().Setup(m => m.GetAsyncEnumerator()).Returns(new TestDbAsyncEnumerator<UserRating>(_rcData.AsQueryable().GetEnumerator()));
            _mockRCSet.As<IQueryable<UserRating>>().Setup(m => m.Provider).Returns(new TestDbAsyncQueryProvider<UserRating>(_rcData.AsQueryable().Provider));
            _mockRCSet.As<IQueryable<UserRating>>().Setup(m => m.Expression).Returns(_rcData.AsQueryable().Expression);
            _mockRCSet.As<IQueryable<UserRating>>().Setup(m => m.ElementType).Returns(_rcData.AsQueryable().ElementType);
            _mockRCSet.As<IQueryable<UserRating>>().Setup(m => m.GetEnumerator()).Returns(_rcData.AsQueryable().GetEnumerator());
            _mockRCSet.Setup(x => x.Add(It.IsAny<UserRating>())).Callback<UserRating>((s) => _rcData.Add(s)).Returns((UserRating u) => u);
            _mockRCSet.Setup(x => x.Remove(It.IsAny<UserRating>())).Callback<UserRating>((s) => _rcData.Remove(s));
            _mockRCSet.Setup(x => x.Find(It.IsAny<object[]>())).Returns<object[]>(x => 
            (_rcData as List<UserRating>).FirstOrDefault(y => y.Id == (int)x[0]) as UserRating);

            _mockContext.Setup(c => c.UserRatings).Returns(_mockRCSet.Object);
            _mockContext.Setup(m => m.Set<UserRating>()).Returns(_mockRCSet.Object);
            _mockContext.Setup(x => x.SaveChanges()).Returns(1);

            _userRatingRepository = new UserRatingRepository(_mockContext.Object);
        }

        public List<UserRating> GetTestData()
        {
            return new List<UserRating>()
            {
                new UserRating()
                {

                }
            };
        }
    }
}
