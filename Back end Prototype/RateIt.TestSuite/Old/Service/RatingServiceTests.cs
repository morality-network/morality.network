using Moq;
using NUnit.Framework;
using RateIt.Model;
using RateIt.Services;
using RateItRepository;
using RateItRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.TestSuite.Service
{
    public class RatingServiceTests
    {

        private IRatingService _ratingService;
        private Mock<IRatingRepository> _ratingRepository;
        private Mock<IUserRepository> _userRepository;
        private Mock<ISiteRepository> _siteRepository;
        private Mock<ISiteService> _siteService;
        private Mock<IUserRatingRepository> _userRatingRepository;

        [SetUp]
        public void SetUp()
        {
            _ratingRepository = new Mock<IRatingRepository>();
            _userRepository = new Mock<IUserRepository>();
            _siteRepository = new Mock<ISiteRepository>();
            _siteService = new Mock<ISiteService>();
            _userRatingRepository = new Mock<IUserRatingRepository>();

            _userRepository.Setup(x => x.GetUserById(It.Is<long>(n => n == 12))).Returns(new Model.User() { id = 12, active = true });
            _userRepository.Setup(x => x.CalculateUserStat(It.Is<User>(n => n.id == 12)));
            _siteRepository.Setup(x => x.GetSiteName(It.Is<string>(s => s == "https://www.google.com"))).Returns("www.google.com");
            _ratingRepository.Setup(x => x.GetRatingBySiteName(It.Is<string>(s => s == "https://www.google.com"))).Returns(
                GetRating()
            );
            _ratingRepository.Setup(x => x.GetRatingObjByUrl(It.Is<string>(s => s == "https://www.google.com"))).Returns(GetRating());
            _ratingRepository.Setup(x => x.AddRating(It.Is<long>(n => n == 5), It.Is<double>(v => v == 3.0))).Returns(true);
            _ratingRepository.Setup(x => x.UpdateRating(It.Is<long>(n => n == 78), 3)).Returns(true);
            _userRatingRepository.Setup(x => x.AddUserRating(It.Is<long>(n => n == 12), It.Is<string>(s => s == "https://www.google.com"),
                It.Is<double>(v => v == 3.0))).Returns(true);
            _userRatingRepository.Setup(x => x.CountTotalRated(It.Is<long>(n => n == 78))).Returns(10);
            _userRatingRepository.Setup(x => x.SumUserRatings(It.Is<long>(n => n == 78))).Returns(30);
            _userRatingRepository.Setup(x => x.GetUserRating((It.Is<long>(n => n == 12)), It.Is<long>(n => n == 78))).Returns(new UserRating());
            _siteService.Setup(x => x.FindOrInsertSite(It.Is<string>(s => s == "www.google.com"))).Returns(5);

            _ratingService = new RatingService(_ratingRepository.Object, _userRepository.Object, _siteRepository.Object,
                _siteService.Object, _userRatingRepository.Object);
        }

        private Rating GetRating()
        {
            return new Rating()
            {
                id = 78,
                rating1 = 4.2,
                site_id = 5
            };
        }

        [Test]
        public void AddRatingAlreadyRated()
        {
            var success = _ratingService.AddRating(12, "https://www.google.com", 2.4);
            Assert.AreEqual(false, success);
        }

        [Test]
        public void AddRatingSuccess()
        {
            var success = _ratingService.AddRating(12, "https://www.google2.com", 3.0);
            Assert.AreEqual(true, success);
        }

        [Test]
        public void UpdateRatingSuccess()
        {
            var success = _ratingService.UpdateRating(78, 3);
            Assert.AreEqual(true, success);
        }

        [Test]
        public void CheckUsersRatedAlready()
        {
            var hasRated = _ratingService.CheckUsersRated(12, "https://www.google.com");
            Assert.AreEqual(true, hasRated);
        }

        [Test]
        public void CheckUsersRatedAlreadyV2()
        {
            _userRatingRepository.Setup(x => x.GetUserRating((It.Is<long>(n => n == 12)), It.Is<long>(n => n == 78))).Returns(new UserRating());
            var hasRated = _ratingService.CheckUsersRated(12, "https://www.google.com");
            Assert.AreEqual(true, hasRated);
        }

        [Test]
        public void CheckUserHasntRatedAlready()
        {
            _userRatingRepository.Setup(x => x.GetUserRating((It.Is<long>(n => n == 12)), It.Is<long>(n => n == 79))).Returns(new UserRating());
            var hasRated = _ratingService.CheckUsersRated(12, "https://www.google.com");
            Assert.AreEqual(true, hasRated);
        }

    }
}
