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
    public class CreditTransactionRepositoryTests
    {
        private List<CreditTransaction> _data;
        private Mock<DbSet<CreditTransaction>> _mockSet;
        private Mock<RIEntities> _mockContext;
        private ICreditTransactionRepository _CreditTransactionRepository;
        private Mock<ISiteRepository> _siteRepository;
        private Mock<IUserRepository> _userRepository;

        [SetUp]
        public void Setup()
        {
            _data = this.GetTestData();
            _mockSet = new Mock<DbSet<CreditTransaction>>();
            _mockSet.As<IDbAsyncEnumerable<CreditTransaction>>().Setup(m => m.GetAsyncEnumerator()).Returns(new TestDbAsyncEnumerator<CreditTransaction>(_data.AsQueryable().GetEnumerator()));
            _mockSet.As<IQueryable<CreditTransaction>>().Setup(m => m.Provider).Returns(new TestDbAsyncQueryProvider<CreditTransaction>(_data.AsQueryable().Provider));
            _mockSet.As<IQueryable<CreditTransaction>>().Setup(m => m.Expression).Returns(_data.AsQueryable().Expression);
            _mockSet.As<IQueryable<CreditTransaction>>().Setup(m => m.ElementType).Returns(_data.AsQueryable().ElementType);
            _mockSet.As<IQueryable<CreditTransaction>>().Setup(m => m.GetEnumerator()).Returns(_data.AsQueryable().GetEnumerator());
            _mockSet.Setup(x => x.Add(It.IsAny<CreditTransaction>())).Callback<CreditTransaction>((s) => _data.Add(s)).Returns((CreditTransaction u) => u);
            _mockSet.Setup(x => x.Remove(It.IsAny<CreditTransaction>())).Callback<CreditTransaction>((s) => _data.Remove(s));
            _mockSet.Setup(x => x.Find(It.IsAny<object[]>())).Returns<object[]>(x => (_data as List<CreditTransaction>).FirstOrDefault(y => y.Id == (int)x[0]) as CreditTransaction);

            _mockContext = new Mock<RIEntities>();
            _mockContext.Setup(c => c.CreditTransactions).Returns(_mockSet.Object);
            _mockContext.Setup(m => m.Set<CreditTransaction>()).Returns(_mockSet.Object);
            _mockContext.Setup(x => x.SaveChanges()).Returns(1);

            _siteRepository = new Mock<ISiteRepository>();
            _userRepository = new Mock<IUserRepository>();
 

            _CreditTransactionRepository = new CreditTransactionRepository(_mockContext.Object);
        }

        [Test]
        public void GetTransactionsExistTest()
        {
            var transactions = _CreditTransactionRepository.GetTransactions(33).ToList();
            Assert.IsInstanceOf<List<CreditTransaction>>(transactions);
            Assert.AreEqual(2, transactions.Count());
            var transactions2 = _CreditTransactionRepository.GetTransactions(22).ToList();
            Assert.IsInstanceOf<List<CreditTransaction>>(transactions2);
            Assert.AreEqual(1, transactions2.Count());
        }

        [Test]
        public void GetTransactionsNoneExistsTest()
        {
            var transactions = _CreditTransactionRepository.GetTransactions(922).Any();
            Assert.AreEqual(false, transactions);
        }

        [Test]
        public void GetTransactionsToExistsTest()
        {
            var transactions = _CreditTransactionRepository.GetTransactionsTo(33).ToList();
            Assert.IsInstanceOf<List<CreditTransaction>>(transactions);
            Assert.AreEqual(1, transactions.Count());
        }

        [Test]
        public void GetTransactionsToNoneExistTest()
        {
            var transactions = _CreditTransactionRepository.GetTransactionsTo(901).Any();
            Assert.AreEqual(false, transactions);
        }

        [Test]
        public void GetTransactionsFromExistsTest()
        {
            var transactions = _CreditTransactionRepository.GetTransactionsFrom(33).ToList();
            Assert.IsInstanceOf<List<CreditTransaction>>(transactions);
            Assert.AreEqual(1, transactions.Count());
        }

        [Test]
        public void GetTransactionsFromWhereNoneExistsTest()
        {
            var transactions = _CreditTransactionRepository.GetTransactionsFrom(901).Any();
            Assert.AreEqual(false, transactions);
        }

        [Test]
        public void AddCreditTransactionTest()
        {
            var success = _CreditTransactionRepository.AddTransaction(GetTransaction());
            var testCount = _mockSet.Object.Count();
            Assert.AreEqual(true, success);
        }

        public CreditTransaction GetTransaction()
        {
            return new CreditTransaction()
            {
                Id = 12,
                to_id = 33,
                from_id = 27,
                linked_comment_id = 0,
                linked_investion_id = 0,
                current_amount_string = "10000000000000000000"
            };
        }

        public List<CreditTransaction> GetTestData()
        {
            return new List<CreditTransaction>()
            {
                //Straight Transfer
                new CreditTransaction()
                {
                    Id = 4,
                    to_id = 33,
                    from_id = 27,
                    linked_comment_id = 0,
                    linked_investion_id = 0,
                    current_amount_string = "10000000000000000000"
                },
                //From mining
                new CreditTransaction()
                {
                    Id = 5,
                    to_id = 27,
                    from_id = 33,
                    linked_comment_id = 0,
                    linked_investion_id = 2,
                    current_amount_string = "20000000000000000000"
                },
                //From comment tip
                new CreditTransaction()
                {
                    Id = 6,
                    to_id = 39,
                    from_id = 22,
                    linked_comment_id = 8,
                    linked_investion_id = 0,
                    current_amount_string = "10000000000000000000"
                }
            };
        }

    }
}
