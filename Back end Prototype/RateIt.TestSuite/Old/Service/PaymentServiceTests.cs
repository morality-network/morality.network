using Moq;
using NUnit.Framework;
using RateIt.Model;
using RateIt.Services;
using RateIt.Utilities;
using RateItRepository;
using RateItRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RateIt.TestSuite.Service
{
    public class PaymentServiceTests
    {
        private IPaymentService _paymentService;
        private Mock<IUserService> _userService;
        private Mock<ICreditTransactionService> _creditTransactionService;
        private Mock<ICreditWalletService> _creditWalletService;
        private Mock<IUserMessageRepository> _userMessageRepository;

        [SetUp]
        public void Setup()
        {
            _userService = new Mock<IUserService>();
            _creditTransactionService = new Mock<ICreditTransactionService>();
            _creditWalletService = new Mock<ICreditWalletService>();
            _userMessageRepository = new Mock<IUserMessageRepository>();

            _userService.Setup(x => x.GetAllUsersCount(It.IsAny< Utilities.TimeSpan>())).Returns(1000);
            _userService.Setup(x => x.GetRandomUsers(It.IsAny<int>(), It.IsAny<DateTime>())).Returns(GetUsers());

            _creditWalletService.Setup(x => x.Transfer(1, It.IsAny<long>(), It.IsAny<string>())).Returns(true);
            _creditTransactionService.Setup(x => x.AddMoCreditsTransaction(It.IsAny<long>(), 1, It.IsAny<string>(), null, 
                null, TransferType.StraightTransfer)).Returns(true);

            _userMessageRepository.Setup(x => x.AddUserMessage(It.IsAny<string>(), It.IsAny<long>(), It.IsAny<string>())).Returns(true);

            _paymentService = new PaymentService(_userService.Object, _creditTransactionService.Object, _creditWalletService.Object,
                _userMessageRepository.Object);
        }

        [Test]
        public void MakeRandomMoCPaymentTest()
        {
            var payment = _paymentService.MakeRandomMoCPayment(TimeSpanUtilities.GetLast3Months());
            Assert.AreEqual(true, payment);
        }

        [Test]
        public void RandomNumberTest()
        {
            var randomNumbers = new BigInteger[10];
            for (int i = 0; i < 3; i++)
            {
                //Need thread.sleep as i think random.next is seeded by a timestamp 
                //- the loop runs too quick otherwise and you get the same seed and therefore same random value
                Thread.Sleep(100);
                var randomNumber = _paymentService.GetRandomBigInteger(9, 0, 20);
                var numberAsString = randomNumber.ToString();
                Assert.AreEqual(true, 20 >= numberAsString.Length);
                Assert.AreEqual(false, randomNumbers.Contains(randomNumber));
                randomNumbers[i] = randomNumber;
            }

        }

        public List<User> GetUsers()
        {
            return new List<User>()
            {
                new User()
                {
                    id = 4,
                    active = true
                },
                 new User()
                {
                    id = 5,
                    active = true
                },
                  new User()
                {
                    id = 6,
                    active = true
                }
            };
        }
    }
}
