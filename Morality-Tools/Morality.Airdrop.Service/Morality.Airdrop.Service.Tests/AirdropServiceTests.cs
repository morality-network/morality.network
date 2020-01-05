using Microsoft.VisualStudio.TestTools.UnitTesting;
using Morality.Airdrop.Service.Models;
using System.Collections.Generic;
using System.Linq;

namespace Morality.Airdrop.Service.Tests
{
    [TestClass]
    public class AirdropServiceTests
    {
        private AirdropService _airdropService;
        public void Setup(int minBound = 500, int maxBound = 1000, int maxAmountToSend = 1000)
        {
            _airdropService = new AirdropService(minBound, maxBound, maxAmountToSend);
        }

        [TestMethod]
        [DataRow(500, 500)]
        [DataRow(499, 500)]
        [DataRow(0, 500)]
        [DataRow(501, 501)]
        [DataRow(999, 999)]
        [DataRow(1000, 1000)]
        [DataRow(1001, 1000)]
        public void BoundValueTest(double valueToBound, double expectedValue)
        {
            Setup();
            var boundValue = _airdropService.BoundValue(valueToBound);
            Assert.AreEqual(boundValue, expectedValue);
        }

        [TestMethod]
        [DataRow(3000.0, new double[] { 499, 499, 1001, 1001 })]
        [DataRow(7934.0, new double[] { 1001.0, 1000.0, 499.0, 501.0, 1500.0, 933.0, 4999.0, 10000.0, 30.0, 99.0 })]
        public void CalculateTotalMoHeldTest(double expectedValue, double[] amounts)
        {
            Setup();
            var users = new List<User>();
            var Id = 0;
            foreach (var amount in amounts)
            {
                users.Add(new User()
                {
                    Id = Id++,
                    MoHeldByReserve = amount
                });
            }
            var total = _airdropService.CalculateTotalMoHeld(users);
            Assert.AreEqual(expectedValue, total);
        }

        [TestMethod]
        [DataRow(0.15, new double[] { 0.16, 0.32, 0.66, 1 }, 1)]
        [DataRow(0.17, new double[] { 0.16, 0.32, 0.66, 1 }, 2)]
        [DataRow(0.33, new double[] { 0.16, 0.32, 0.66, 1 }, 3)]
        [DataRow(0.65, new double[] { 0.16, 0.32, 0.66, 1 }, 3)]
        [DataRow(0.69, new double[] { 0.16, 0.32, 0.66, 1 }, 4)]
        public void IdentifyWinnerTest(double value, double[] amounts, int expectedValue)
        {
            Setup();
            var users = new List<User>();
            var Id = 1;
            foreach (var amount in amounts)
            {
                users.Add(new User()
                {
                    Id = Id++,
                    CumulitiveProbability = amount
                });
            }
            var winner = _airdropService.IdentifyWinner(users, value);
            Assert.AreEqual(expectedValue, winner);
        }

        [TestMethod]
        [DataRow(3000.0, new double[] { 499, 499, 1001, 1001 })]
        [DataRow(7934.0, new double[] { 1001.0, 1000.0, 499.0, 501.0, 1500.0, 933.0, 4999.0, 10000.0, 30.0, 99.0 })]
        public void GenerateProbabilities(double expectedValue, double[] amounts)
        {
            Setup();
            var users = GenerateUsers(amounts).ToList();
            var total = _airdropService.CalculateTotalMoHeld(users);
            var updatedUsers = _airdropService.GenerateProbabilities(users, total);
            // Check that probs have been calculated and that they are correct
            var cp = 0.0;
            foreach (var user in users)
            {
                cp += user.Probability;
                Assert.AreEqual(user.BoundedMo / total, user.Probability);
                Assert.AreEqual(cp, user.CumulitiveProbability);
            }
            // Check they all add up as they should
            Assert.AreEqual(1, users.Sum(x => x.Probability));
        }

        [TestMethod]
        [DataRow(5000, new double[] { 499, 499, 1001, 1001, 499, 499, 1001, 1001, 499, 499, 1001, 1001 }, 10000)]
        [DataRow(10000, new double[] { 1001.0, 1000.0, 499.0, 501.0, 1500.0, 933.0, 4999.0, 10000.0, 30.0, 99.0 }, 5000)]
        public void GetAirdropTest(int airdropCount, double[] amounts, int maxAmount)
        {
            Setup(500, 1000, maxAmount);
            var users = GenerateUsers(amounts).ToList();
            var winners = _airdropService.GetAirdrops(users, airdropCount);
            Assert.IsNotNull(winners);
            Assert.AreEqual(airdropCount, winners.Count);
            winners.ForEach(x =>
            {
                Assert.IsTrue(x.Amount >= 0);
                Assert.IsTrue(x.Amount <= maxAmount);
                Assert.IsTrue(x.Id > 0);
                Assert.IsTrue(x.Id <= users.Count);
            });
            var distinctIds = winners.GroupBy(x => x.Id).Select(x => x.FirstOrDefault().Id);
            Assert.AreEqual(users.Count, distinctIds.Count());
        }

        [TestMethod]
        [DataRow(10000, new double[] { 1001.0, 1000.0, 499.0, 501.0, 1500.0, 1000.0, 4999.0, 10000.0, 30.0, 99.0 }, 5000)]
        public void GetAirdropCheckDistributionTest(int airdropCount, double[] amounts, int maxAmount)
        {
            Setup(500, 1000, maxAmount);
            GetAirdropTest(airdropCount, amounts, maxAmount);
            var map = _airdropService.Map;
            var highCount = amounts.Where(x => x >= 1000).Count();
            var lowCount = amounts.Where(x => x < 1000).Count();
            var currentHighCount = 0;
            var currentLowCount = 0;
            foreach (var winner in map.Keys)
            {
                if (amounts[winner - 1] >= 1000)
                    ++currentHighCount;

                if (amounts[winner - 1] < 1000)
                    ++currentLowCount;
            }
            Assert.AreEqual(highCount, currentHighCount);
            Assert.AreEqual(lowCount, currentLowCount);
            Assert.AreEqual(amounts.Count(), highCount + lowCount);
        }

        #region Helpers

        private IEnumerable<User> GenerateUsers(double[] amounts)
        {
            var Id = 0;
            foreach (var amount in amounts)
            {
                yield return new User()
                {
                    Id = ++Id,
                    MoHeldByReserve = amount
                };
            }
        }

        #endregion
    }
}
