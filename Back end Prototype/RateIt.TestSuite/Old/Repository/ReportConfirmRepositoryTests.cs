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
    public class ReportConfirmRepositoryTests
    {
        private Mock<DbSet<ReportConfirm>> _mockRCSet;
        private Mock<RIEntities> _mockContext;
        private IReportConfirmRepository _reportConfirmRepository;

        [SetUp]
        public void Setup()
        {         
            _mockContext = new Mock<RIEntities>();

             var _rcData = this.GetTestData();
            _mockRCSet = new Mock<DbSet<ReportConfirm>>();
            _mockRCSet.As<IDbAsyncEnumerable<ReportConfirm>>().Setup(m => m.GetAsyncEnumerator()).Returns(new TestDbAsyncEnumerator<ReportConfirm>(_rcData.AsQueryable().GetEnumerator()));
            _mockRCSet.As<IQueryable<ReportConfirm>>().Setup(m => m.Provider).Returns(new TestDbAsyncQueryProvider<ReportConfirm>(_rcData.AsQueryable().Provider));
            _mockRCSet.As<IQueryable<ReportConfirm>>().Setup(m => m.Expression).Returns(_rcData.AsQueryable().Expression);
            _mockRCSet.As<IQueryable<ReportConfirm>>().Setup(m => m.ElementType).Returns(_rcData.AsQueryable().ElementType);
            _mockRCSet.As<IQueryable<ReportConfirm>>().Setup(m => m.GetEnumerator()).Returns(_rcData.AsQueryable().GetEnumerator());
            _mockRCSet.Setup(x => x.Add(It.IsAny<ReportConfirm>())).Callback<ReportConfirm>((s) => _rcData.Add(s)).Returns((ReportConfirm u) => u);
            _mockRCSet.Setup(x => x.Remove(It.IsAny<ReportConfirm>())).Callback<ReportConfirm>((s) => _rcData.Remove(s));
            _mockRCSet.Setup(x => x.Find(It.IsAny<object[]>())).Returns<object[]>(x => (_rcData as List<ReportConfirm>).FirstOrDefault(y => y.id == (int)x[0]) as ReportConfirm);

            _mockContext.Setup(c => c.ReportConfirms).Returns(_mockRCSet.Object);
            _mockContext.Setup(m => m.Set<ReportConfirm>()).Returns(_mockRCSet.Object);
            _mockContext.Setup(x => x.SaveChanges()).Returns(1);

            _reportConfirmRepository = new ReportConfirmRepository(_mockContext.Object);
        }

        [Test]
        public void AddReportConfirmTest()
        {
            var success = _reportConfirmRepository.AddReportConfirm(12, 2, new Common.Models.MiningDTO()
            {
                IsIdentityHate = true,
                IsInsult = false,
                IsObscence = true,
                IsSevereToxic = false,
                IsSpam = true,
                IsThreat = false,
                IsToxic = true, 
                Remove = true
            });

            Assert.IsTrue(success);
            var totalCount = _mockRCSet.Object.Count();
            Assert.AreEqual(5, totalCount);
        }

        [Test]
        public void AddReportConfirmNullTest()
        {
            var success = _reportConfirmRepository.AddReportConfirm(12, 2, null);
            Assert.IsFalse(success);
        }

        [Test]
        public void HasUserReviewedTrueTest()
        {
            var success = _reportConfirmRepository.HasUserReviewedAlready(12, 19);
            Assert.IsTrue(success);
        }

        [Test]
        public void HasUserReviewedFalseTest()
        {
            var success = _reportConfirmRepository.HasUserReviewedAlready(12, 92);
            Assert.IsFalse(success);
        }

        [Test]
        public void RemoveAllForInvestigationFailTest()
        {
            var success = _reportConfirmRepository.RemoveAllForInvestigation(245);
            var count = _mockRCSet.Object.Count();
            Assert.IsFalse(success);
            Assert.AreEqual(4, count);
        }

        [Test]
        public void RemoveAllForInvestigationSuccessTest()
        {
            var success = _reportConfirmRepository.RemoveAllForInvestigation(19);
            //var shouldBeNone = _mockRCSet.Object.Where(x => x.investigation_id == 19).Count();
            Assert.IsTrue(success);
            //Assert.AreEqual(0, shouldBeNone);
        }

        public List<ReportConfirm> GetTestData()
        {
            return new List<ReportConfirm>()
            {
                new ReportConfirm()
                {
                    id = 34,
                    investigation_id = 19,
                    user_id = 12
                },
                new ReportConfirm()
                {
                    id = 35,
                    investigation_id = 10,
                    user_id = 13
                },
                new ReportConfirm()
                {
                    id = 36,
                    investigation_id = 19,
                    user_id = 13
                },
                new ReportConfirm()
                {
                    id = 37,
                    investigation_id = 13,
                    user_id = 21
                }
            };
        }
    }
}
