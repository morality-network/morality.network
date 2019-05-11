using Moq;
using NUnit.Framework;
using RateIt.Model;
using RateIt.Utilities;
using RateItRepository;
using RateItRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace RateIt.TestSuite.Repository
{
    public class TransactionRepositoryTests
    {

        private List<Transaction> _data;
        private Mock<DbSet<Transaction>> _mockSet;
        private Mock<RIEntities> _mockContext;
        private ITransactionRepository _transactionRepository;
        private Mock<ISiteRepository> _siteRepository;
        private Mock<IUserRepository> _userRepository;

        [SetUp]
        public void Setup()
        {
            _data = this.GetTestData();
            _mockSet = new Mock<DbSet<Transaction>>();
            _mockSet.As<IDbAsyncEnumerable<Transaction>>().Setup(m => m.GetAsyncEnumerator()).Returns(new TestDbAsyncEnumerator<Transaction>(_data.AsQueryable().GetEnumerator()));
            _mockSet.As<IQueryable<Transaction>>().Setup(m => m.Provider).Returns(new TestDbAsyncQueryProvider<Transaction>(_data.AsQueryable().Provider));
            _mockSet.As<IQueryable<Transaction>>().Setup(m => m.Expression).Returns(_data.AsQueryable().Expression);
            _mockSet.As<IQueryable<Transaction>>().Setup(m => m.ElementType).Returns(_data.AsQueryable().ElementType);
            _mockSet.As<IQueryable<Transaction>>().Setup(m => m.GetEnumerator()).Returns(_data.AsQueryable().GetEnumerator());
            _mockSet.Setup(x => x.Add(It.IsAny<Transaction>())).Callback<Transaction>((s) => _data.Add(s)).Returns((Transaction u) => u);
            _mockSet.Setup(x => x.Remove(It.IsAny<Transaction>())).Callback<Transaction>((s) => _data.Remove(s));
            _mockSet.Setup(x => x.Find(It.IsAny<object[]>())).Returns<object[]>(x => (_data as List<Transaction>).FirstOrDefault(y => y.id == (int)x[0]) as Transaction);

            _mockContext = new Mock<RIEntities>();
            _mockContext.Setup(c => c.Transactions).Returns(_mockSet.Object);
            _mockContext.Setup(m => m.Set<Transaction>()).Returns(_mockSet.Object);
            _mockContext.Setup(x => x.SaveChanges()).Returns(1);

            _siteRepository = new Mock<ISiteRepository>();
            _userRepository = new Mock<IUserRepository>();

            _transactionRepository = new TransactionRepository(_mockContext.Object);
        }

        [Test]
        public void AddTransactionTest()
        {
            var success = _transactionRepository.AddTransaction(new Transaction() { id = 20 });
            var count = _mockSet.Object.Count();
            Assert.IsTrue(success);
            Assert.AreEqual(5, count);
        }

        [Test]
        public void GetTransactionsInTimePeriodForUserNoFilterTest()
        {
            var transactions = _transactionRepository.GetTransactionsInTimePeriodForUser(TimeSpanUtilities.GetLast3Months(), 13, 
                RateItRepository.Enums.TransactionFilter.None);
            var count = transactions.Count();
            Assert.AreEqual(2, count);
        }

        [Test]
        public void GetTransactionsInTimePeriodForUserToTest()
        {
            var transactions = _transactionRepository.GetTransactionsInTimePeriodForUser(TimeSpanUtilities.GetLast3Months(), 13,
                RateItRepository.Enums.TransactionFilter.Inbound);
            var count = transactions.Count();
            Assert.AreEqual(1, count);
        }

        [Test]
        public void GetTransactionsInTimePeriodForUserFromTest()
        {
            var transactions = _transactionRepository.GetTransactionsInTimePeriodForUser(TimeSpanUtilities.GetLast3Months(), 13,
                RateItRepository.Enums.TransactionFilter.Outbound);
            var count = transactions.Count();
            Assert.AreEqual(1, count);
        }

        [Test]
        public void GetTransactionByHashTest()
        {
            var transaction = _transactionRepository.GetTransactionByHash("0xwerdbc4bab20a825edc72df441bde3102508111");
            Assert.IsNotNull(transaction);
        }

        [Test]
        public void GetTransactionByHashNoneExistTest()
        {
            var transaction = _transactionRepository.GetTransactionByHash("0xwerdbc4bab20a825edc72df441bde3102508119");
            Assert.IsNull(transaction);
        }

        [Test]
        public void GetTransactionByIdTest()
        {
            var transaction = _transactionRepository.GetTransactionById(332);
            Assert.IsNotNull(transaction);
        }

        [Test]
        public void GetTransactionByIdNoneExistTest()
        {
            var transaction = _transactionRepository.GetTransactionById(933);
            Assert.IsNull(transaction);
        }


        [Test]
        public void GetTopTransactionsTest()
        {
            var transactions = _transactionRepository.GetTopTransactions(13, 1, RateItRepository.Enums.TransactionFilter.None);
            Assert.IsNotNull(transactions);
            Assert.AreEqual(1, transactions.Count());

            var transactions2 = _transactionRepository.GetTopTransactions(13, 2, RateItRepository.Enums.TransactionFilter.None);
            Assert.IsNotNull(transactions2);
            Assert.AreEqual(2, transactions2.Count());
        }

        [Test]
        public void GetTopTransactionsNoneExistTest()
        {
            var transactions = _transactionRepository.GetTopTransactions(177, 1, RateItRepository.Enums.TransactionFilter.None);
            Assert.IsNotNull(transactions);
            Assert.AreEqual(0, transactions.Count());
        }

        [Test]
        public void GetTotalSpentTest()
        {
            BigInteger total = _transactionRepository.GetTotalSpent(new RateIt.Utilities.TimeSpan() { StartDate = DateTime.Now.AddMonths(-4)}, 13);
            Assert.AreEqual(BigInteger.Parse("100000000000000000"), total);

            BigInteger total2 = _transactionRepository.GetTotalSpent(new RateIt.Utilities.TimeSpan() { StartDate = DateTime.Now.AddMonths(-3) }, 14);
            Assert.AreEqual(BigInteger.Parse("0"), total2);

            BigInteger total3 = _transactionRepository.GetTotalSpent(new RateIt.Utilities.TimeSpan() { StartDate = DateTime.Now.AddMonths(-5) }, 14);
            Assert.AreEqual(BigInteger.Parse("900000000000000000"), total3);
        }


        [Test]
        public void GetTotalReceivedTest()
        {
            BigInteger total = _transactionRepository.GetTotalReceived(new RateIt.Utilities.TimeSpan()
            { StartDate = DateTime.Now.AddMonths(-3) }, 13);
            Assert.AreEqual(BigInteger.Parse("200000000000000000"), total);
        }
  
        public List<Transaction> GetTestData()
        {
            return new List<Transaction>()
            {

                new Transaction()
                {
                    id = 332,
                    address_from = ConfigReader.GetInstance().MoralityAdminAddress,
                    address_to =  "0x4a05e3c78c402c805ba737df0258c43e23b623aa",
                    amount_to_send ="100000000000000000",
                    contractAddress = "0x97e8dbc4bab20a825edc72df441bde3102508605",
                    transaction_hash = "0xwerdbc4bab20a825edc72df441bde3102508112",
                    user_from = 13,
                    user_to = 12,
                    timestamp = DateTime.Now
                },
                 new Transaction()
                {
                    id = 333,
                    address_from = "0x4a05e3c78c402c805ba737df0258c43e23b623aa",
                    address_to =  ConfigReader.GetInstance().MoralityAdminAddress,
                    amount_to_send ="200000000000000000",
                    transaction_hash = "0xwerdbc4bab20a825edc72df441bde3102508111",
                    contractAddress = "0x97e8dbc4bab20a825edc72df441bde3102508605",
                    user_from = 12,
                    user_to = 13,
                    timestamp = DateTime.Now
                 },
                  new Transaction()
                {
                    id = 334,
                    address_from = "0x4a05e3c78c402c805ba737df0258c43e23b623kk",
                    address_to =  "0x4a05e3c78c402c805ba737df0258c43e23b623aa",
                    amount_to_send ="700000000000000000",
                    contractAddress = "0x97e8dbc4bab20a825edc72df441bde3102508605",
                    transaction_hash = "0xwerdbc4bab20a825edc72df441bde3102508113",
                    user_from = 14,
                    user_to = 13,
                    timestamp = DateTime.Now.AddMonths(-4)
                },
                   new Transaction()
                {
                    id = 335,
                    address_from = "0x4a05e3c78c402c805ba737df0258c43e23b623kk",
                    address_to =  "0x4a05e3c78c402c805ba737df0258c43e23b623sd",
                    amount_to_send ="200000000000000000",
                    contractAddress = "0x97e8dbc4bab20a825edc72df441bde3102508605",
                    transaction_hash = "0xwerdbc4bab20a825edc72df441bde3102508118",
                    user_from = 14,
                    user_to = 19,
                    timestamp = DateTime.Now.AddMonths(-3)
                }
            };
        }
    }
}
