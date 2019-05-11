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
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.TestSuite.Repository
{
    public class CreditWalletRepositoryTests
    {

        private Mock<DbSet<CreditWallet>> _mockRCSet;
        private Mock<RIEntities> _mockContext;
        private ICreditWalletRepository _creditWalletRepository;

        [SetUp]
        public void Setup()
        {
            _mockContext = new Mock<RIEntities>();

            var _rcData = this.GetTestData();
            _mockRCSet = new Mock<DbSet<CreditWallet>>();
            _mockRCSet.As<IDbAsyncEnumerable<CreditWallet>>().Setup(m => m.GetAsyncEnumerator()).Returns(new TestDbAsyncEnumerator<CreditWallet>(_rcData.AsQueryable().GetEnumerator()));
            _mockRCSet.As<IQueryable<CreditWallet>>().Setup(m => m.Provider).Returns(new TestDbAsyncQueryProvider<CreditWallet>(_rcData.AsQueryable().Provider));
            _mockRCSet.As<IQueryable<CreditWallet>>().Setup(m => m.Expression).Returns(_rcData.AsQueryable().Expression);
            _mockRCSet.As<IQueryable<CreditWallet>>().Setup(m => m.ElementType).Returns(_rcData.AsQueryable().ElementType);
            _mockRCSet.As<IQueryable<CreditWallet>>().Setup(m => m.GetEnumerator()).Returns(_rcData.AsQueryable().GetEnumerator());
            _mockRCSet.Setup(x => x.Add(It.IsAny<CreditWallet>())).Callback<CreditWallet>((s) => _rcData.Add(s)).Returns((CreditWallet u) => u);
            _mockRCSet.Setup(x => x.Remove(It.IsAny<CreditWallet>())).Callback<CreditWallet>((s) => _rcData.Remove(s));
            _mockRCSet.Setup(x => x.Find(It.IsAny<object[]>())).Returns<object[]>(x => (_rcData as List<CreditWallet>).FirstOrDefault(y => y.Id == (int)x[0]) as CreditWallet);

            _mockContext.Setup(c => c.CreditWallets).Returns(_mockRCSet.Object);
            _mockContext.Setup(m => m.Set<CreditWallet>()).Returns(_mockRCSet.Object);
            _mockContext.Setup(x => x.SaveChanges()).Returns(1);

            _creditWalletRepository = new CreditWalletRepository(_mockContext.Object);
        }

        [Test]
        public void GetCurrentCreditTest()
        {
            var amountCredit = _creditWalletRepository.GetCurrentCredit(23);
            Assert.IsNotNull(amountCredit);
            Assert.IsInstanceOf<BigInteger>(amountCredit);
            Assert.AreEqual(BigInteger.Parse("100000000000000000000"), amountCredit);
        }


        [Test]
        public void GetCreditWalletTest()
        {
            var wallet = _creditWalletRepository.GetCreditWallet(23);
            Assert.IsNotNull(wallet);
            Assert.AreEqual(823, wallet.Id);
        }

        [Test]
        public void GetCreditWalletNoneExistTest()
        {
            var wallet = _creditWalletRepository.GetCreditWallet(2223);
            Assert.IsNull(wallet);
        }

        [Test]
        public void PayIntoWalletTest()
        {
            var paidIn = _creditWalletRepository.PayIntoWallet(new List<ReportConfirm>()
                {
                    new ReportConfirm()
                    {
                        id = 8,
                        investigation_id = 41,
                        user_id = 23
                    }
                }, 
                BigInteger.Parse("100000000000000000000")
            );
            Assert.AreEqual(true, paidIn);
            var newAmount = _mockRCSet.Object.Where(x => x.userid == 23).First().current_amount_string;
            Assert.AreEqual("200000000000000000000", newAmount);
        }

        [Test]
        public void UpdateWalletTest()
        {
            var success = _creditWalletRepository.UpdateWallet(new CreditWallet()
            {
                userid = 23,
                //100 mo
                current_amount_string = "27300000000000000000000"
            });
            var newAmount = _mockRCSet.Object.Where(x => x.userid == 23).First().current_amount_string;
            Assert.IsTrue(success);
            Assert.AreEqual("27300000000000000000000", newAmount);
        }

        [Test]
        public void CreateWalletTest()
        {
            var created = _creditWalletRepository.CreateWallet(24, new BigInteger(0));
            Assert.IsNotNull(created);
            Assert.AreEqual("0", created.current_amount_string);
        }

        public List<CreditWallet> GetTestData()
        {
            return new List<CreditWallet>()
            {
                new CreditWallet()
                {
                    Id = 823,
                    userid = 23,
                    //100 mo
                    current_amount_string = "100000000000000000000"
                }
            };
       }
    }
}
