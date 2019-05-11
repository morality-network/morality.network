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
    public class InvestigationRepositoryTests
    {
        private List<Investigation> _data;
        private Mock<DbSet<Investigation>> _mockSet;
        private Mock<DbSet<ReportConfirm>> _mockRCSet;
        private Mock<RIEntities> _mockContext;
        private IReportConfirmRepository _reportConfirmRepository;
        private IInvestigationRepository _investigationRepository;

        [SetUp]
        public void Setup()
        {
            _data = this.GetTestData();
            _mockSet = new Mock<DbSet<Investigation>>();
            _mockSet.As<IDbAsyncEnumerable<Investigation>>().Setup(m => m.GetAsyncEnumerator()).Returns(new TestDbAsyncEnumerator<Investigation>(_data.AsQueryable().GetEnumerator()));
            _mockSet.As<IQueryable<Investigation>>().Setup(m => m.Provider).Returns(new TestDbAsyncQueryProvider<Investigation>(_data.AsQueryable().Provider));
            _mockSet.As<IQueryable<Investigation>>().Setup(m => m.Expression).Returns(_data.AsQueryable().Expression);
            _mockSet.As<IQueryable<Investigation>>().Setup(m => m.ElementType).Returns(_data.AsQueryable().ElementType);
            _mockSet.As<IQueryable<Investigation>>().Setup(m => m.GetEnumerator()).Returns(_data.AsQueryable().GetEnumerator());
            _mockSet.Setup(x => x.Add(It.IsAny<Investigation>())).Callback<Investigation>((s) => _data.Add(s)).Returns((Investigation u) => u);
            _mockSet.Setup(x => x.Remove(It.IsAny<Investigation>())).Callback<Investigation>((s) => _data.Remove(s));
            _mockSet.Setup(x => x.Find(It.IsAny<object[]>())).Returns<object[]>(x => (_data as List<Investigation>).FirstOrDefault(y => y.Id == (int)x[0]) as Investigation);

            _mockContext = new Mock<RIEntities>();
            _mockContext.Setup(c => c.Investigations).Returns(_mockSet.Object);
            _mockContext.Setup(m => m.Set<Investigation>()).Returns(_mockSet.Object);
            _mockContext.Setup(x => x.SaveChanges()).Returns(1);

             var _rcData = this.GetTestRCData();
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
            _investigationRepository = new InvestigationRepository(_mockContext.Object);
        }

        [Test]
        public void AddInvestigationTest()
        {
            var addInvestigation = _investigationRepository.AddInvestigation(12, 46);
            int count = _mockSet.Object.Count();
            Assert.AreEqual(true, addInvestigation);
            Assert.AreEqual(5, count);
        }

        [Test]
        public void DoesInvestigationExistForCommentTest()
        {
            var exists = _investigationRepository.DoesInvestigationExistForComment(12);
            Assert.IsTrue(exists);
        }

        [Test]
        public void DoesInvestigationExistForCommentNoneExistTest()
        {
            var exists = _investigationRepository.DoesInvestigationExistForComment(24);
            Assert.IsFalse(exists);
        }

        [Test]
        public void GetInvestigationsTest()
        {
            var investigations = _investigationRepository.GetInvestigations(1, 18);
            Assert.AreEqual(1, investigations.Count());

            var investigations2 = _investigationRepository.GetInvestigations(5, 18);
            Assert.AreEqual(2, investigations2.Count());
        }

        [Test]
        public void GetInvestigationsNoneExistTest()
        {
            var investigations = _investigationRepository.GetInvestigations(5, 34);
            Assert.IsNotNull(investigations);
            Assert.AreEqual(0, investigations.Count());
        }

        [Test]
        public void GetInvestigationByIdExistTest()
        {
            var investigation = _investigationRepository.GetInvestigationById(2);
            Assert.IsNotNull(investigation);
            Assert.AreEqual(2, investigation.Id);

            var investigation2 = _investigationRepository.GetInvestigationById(3);
            Assert.IsNotNull(investigation2);
            Assert.AreEqual(3, investigation2.Id);
        }

        [Test]
        public void GetInvestigationByIdNoneExistTest()
        {
            var investigation = _investigationRepository.GetInvestigationById(9);
            Assert.IsNull(investigation);
        }

        [Test]
        public void ResolveInvestigationTest()
        {
            var success = _investigationRepository.ResolveInvestigation(4);
            Assert.IsInstanceOf<bool>(success);
            Assert.IsTrue(success);
            var totalInvestigations = _mockSet.Object.Count();
            Assert.AreEqual(3, totalInvestigations);
        }

        public List<Investigation> GetTestData()
        {
            return new List<Investigation>()
            {
                new Investigation()
                {
                    Id = 1,
                    comment_id = 12,
                    ReportConfirms = new List<ReportConfirm>()
                    {
                        new ReportConfirm()
                        {
                            user_id = 999
                        }
                    }
                },
                new Investigation()
                {
                    Id = 2,
                    comment_id = 37,
                    ReportConfirms = new List<ReportConfirm>()
                    {
                        new ReportConfirm()
                        {
                            user_id = 999
                        }
                    }
                },
                new Investigation()
                {
                    Id = 3,
                    comment_id = 87
                },
                new Investigation()
                {
                    Id = 4,
                    comment_id = 29
                }
            };
        }

        public List<ReportConfirm> GetTestRCData()
        {
            return new List<ReportConfirm>()
            {
                new ReportConfirm()
                {
                    id = 12,
                    user_id = 19,
                    Investigation = new Investigation()
                    {
                        Id = 262
                    }
                },
                new ReportConfirm()
                {
                    id = 13,
                    user_id = 17,
                    Investigation = new Investigation()
                    {
                        Id = 265
                    }
                },
                new ReportConfirm()
                {
                    id = 14,
                    user_id = 18,
                    Investigation = new Investigation()
                    {
                        Id = 265
                    }
                },
                new ReportConfirm()
                {
                    id = 15,
                    user_id = 18,
                    Investigation = new Investigation()
                    {
                        Id = 266
                    }
                }
            };
        }
    }
}
