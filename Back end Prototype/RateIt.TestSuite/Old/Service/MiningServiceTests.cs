using Moq;
using NUnit.Framework;
using RateIt.Model;
using RateIt.Services;
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

namespace RateIt.TestSuite.Service
{
    public class MiningServiceTests
    {

        private IMiningService _miningService;

        public Mock<IInvestigationRepository> _investigationService;
        public Mock<IReportConfirmRepository> _reportConfirmRepository;
        public Mock<ICreditWalletRepository> _creditWalletRepository;
        public Mock<ISystemValuesRepository> _systemValuesRepository;

        [SetUp]
        public void SetUp()
        {
            _investigationService = new Mock<IInvestigationRepository>();
            _reportConfirmRepository = new Mock<IReportConfirmRepository>();
            _creditWalletRepository = new Mock<ICreditWalletRepository>();
            _systemValuesRepository = new Mock<ISystemValuesRepository>();

            _investigationService.Setup(x => x.GetInvestigations(It.Is<int>(n => n == 3), It.Is<long>(n => n == 15)))
                .Returns(GetInvestigations());

            //Try conclude
            _investigationService.Setup(x => x.GetInvestigationById(3)).Returns(GetInvestigations().Where(x => x.Id == 3).First());
            _investigationService.Setup(x => x.ResolveInvestigation(It.Is<int>(n => n==3))).Returns(true);
            _creditWalletRepository.Setup(x => x.PayIntoWallet(It.IsAny<IList<ReportConfirm>>(), It.IsAny<BigInteger>()));
            _reportConfirmRepository.Setup(x => x.RemoveAllForInvestigation(It.Is<int>(n => n == 3)));

            _miningService = new MiningService(_investigationService.Object, _reportConfirmRepository.Object, _creditWalletRepository.Object,
                _systemValuesRepository.Object);
        }

        [Test]
        public void TryToConcludeInvestigationSuccessTest()
        {
            //Try conclude
            _investigationService.Setup(x => x.GetInvestigationById(2)).Returns(GetInvestigations().Where(x => x.Id == 2).First());
            _investigationService.Setup(x => x.ResolveInvestigation(It.Is<int>(n => n == 2))).Returns(true);
            _creditWalletRepository.Setup(x => x.PayIntoWallet(It.IsAny<IList<ReportConfirm>>(), It.IsAny<BigInteger>()));
            _reportConfirmRepository.Setup(x => x.RemoveAllForInvestigation(It.Is<int>(n => n == 2)));

            _miningService = new MiningService(_investigationService.Object, _reportConfirmRepository.Object, _creditWalletRepository.Object,
                _systemValuesRepository.Object);
            var success = _miningService.TryToConcludeInvestigation(2);
            Assert.AreEqual(true, success);
        }

        [Test]
        public void TryToConcludeInvestigationFalseTest()
        {
            var success = _miningService.TryToConcludeInvestigation(3);
            Assert.AreEqual(false, success);
        }

        [Test]
        public void AddReviewTest()
        {
            var success = _miningService.AddReview(15, 775, GetMiningDTO());
            Assert.AreEqual(true, success);
        }

        [Test]
        public void GetTopInvestigationsTest()
        {
            var topInvestigations = _miningService.GetTopInvestigations(3, 15);
            Assert.IsInstanceOf<IList<Investigation>>(topInvestigations);
            Assert.AreEqual(3, topInvestigations.Count());
        }

        [Test]
        public void GetTopInvestigationsNoneExistTest()
        {
            var topInvestigations = _miningService.GetTopInvestigations(5, 19);
            Assert.IsNotNull(topInvestigations);
            Assert.IsInstanceOf<IList<Investigation>>(topInvestigations);
            Assert.AreEqual(0, topInvestigations.Count());
        }

        public List<Investigation> GetInvestigations()
        {
            return new List<Investigation>() {
                new Investigation() {
                    Id = 1
                },
                 new Investigation()
                {
                    Id = 2,
                    comment_id = 24,
                    overall_keep = 2,
                    overall_remove = 18,
                    time_created = DateTime.Now,
                    ReportConfirms = new List<ReportConfirm>()
                    {
                        new ReportConfirm()
                        {
                            id = 353,
                            investigation_id = 3,
                            hate = true,
                            remove = 1,
                            remove_comment = true,
                            obscene = true
                        },
                        new ReportConfirm()
                        {
                            id = 354,
                            investigation_id = 3,
                            hate = true,
                            remove_comment = true,
                            obscene = true
                        },
                        new ReportConfirm()
                        {
                            id = 355,
                            investigation_id = 3,
                            hate = true,
                            remove_comment = true,
                            obscene = true
                        },
                        new ReportConfirm()
                        {
                            id = 356,
                            investigation_id = 3,
                            hate = true,
                            remove_comment = true,
                            obscene = true
                        },
                        new ReportConfirm()
                        {
                            id = 357,
                            investigation_id = 3,
                            hate = true,
                            remove_comment = true,
                            obscene = true
                        },
                        new ReportConfirm()
                        {
                            id = 358,
                            investigation_id = 3,
                            hate = true,
                            remove_comment = true,
                            obscene = true
                        },
                        new ReportConfirm()
                        {
                            id = 359,
                            investigation_id = 3,
                            hate = true,
                            remove_comment = true,
                            obscene = true
                        },
                        new ReportConfirm()
                        {
                            id = 360,
                            investigation_id = 3,
                            hate = true,
                            remove_comment = true,
                            obscene = true
                        },
                        new ReportConfirm()
                        {
                            id = 361,
                            investigation_id = 3,
                            hate = true,
                            remove_comment = true,
                            obscene = true
                        },
                        new ReportConfirm()
                        {
                            id = 362,
                            investigation_id = 3,
                            hate = true,
                            remove_comment = true,
                            obscene = true
                        },
                        new ReportConfirm()
                        {
                            id = 363,
                            investigation_id = 3,
                            hate = true,
                            remove_comment = true,
                            obscene = true
                        },
                        new ReportConfirm()
                        {
                            id = 364,
                            investigation_id = 3,
                            hate = true,
                            remove = 1,
                            obscene = true
                        },
                        new ReportConfirm()
                        {
                            id = 365,
                            investigation_id = 3,
                            hate = true,
                            remove_comment = true,
                            obscene = true
                        },
                        new ReportConfirm()
                        {
                            id = 366,
                            investigation_id = 3,
                            hate = true,
                            remove_comment = true,
                            obscene = true
                        },
                        new ReportConfirm()
                        {
                            id = 367,
                            investigation_id = 3,
                            hate = true,
                            remove_comment = true,
                            obscene = true
                        },
                        new ReportConfirm()
                        {
                            id = 368,
                            investigation_id = 3,
                            hate = true,
                            remove_comment = false,
                            obscene = true
                        },
                        new ReportConfirm()
                        {
                            id = 369,
                            investigation_id = 3,
                            hate = true,
                            remove_comment = true,
                            obscene = true
                        },
                         new ReportConfirm()
                        {
                            id = 369,
                            investigation_id = 3,
                            hate = true,
                            remove_comment = true,
                            obscene = true
                        },
                        new ReportConfirm()
                        {
                            id = 370,
                            investigation_id = 3,
                            hate = true,
                            remove_comment = false,
                            obscene = true
                        },
                         new ReportConfirm()
                        {
                            id = 371,
                            investigation_id = 3,
                            hate = true,
                            remove_comment = true,
                            obscene = true
                        }
                    }
                },
                new Investigation()
                {
                    Id = 3,
                    comment_id = 24,
                    overall_keep = 9,
                    overall_remove = 10,
                    time_created = DateTime.Now,
                    ReportConfirms = new List<ReportConfirm>()
                    {
                        new ReportConfirm()
                        {
                            id = 353,
                            investigation_id = 3,
                            hate = true,
                            remove = 1,
                            obscene = true
                        },
                        new ReportConfirm()
                        {
                            id = 354,
                            investigation_id = 3,
                            hate = true,
                            remove = 1,
                            obscene = true
                        },
                        new ReportConfirm()
                        {
                            id = 355,
                            investigation_id = 3,
                            hate = true,
                            remove = 1,
                            obscene = true
                        },
                        new ReportConfirm()
                        {
                            id = 356,
                            investigation_id = 3,
                            hate = true,
                            remove = 1,
                            obscene = true
                        },
                        new ReportConfirm()
                        {
                            id = 357,
                            investigation_id = 3,
                            hate = true,
                            remove = 1,
                            obscene = true
                        },
                        new ReportConfirm()
                        {
                            id = 358,
                            investigation_id = 3,
                            hate = true,
                            remove = 1,
                            obscene = true
                        },
                        new ReportConfirm()
                        {
                            id = 359,
                            investigation_id = 3,
                            hate = true,
                            remove = 1,
                            obscene = true
                        },
                        new ReportConfirm()
                        {
                            id = 360,
                            investigation_id = 3,
                            hate = true,
                            remove = 1,
                            obscene = true
                        },
                        new ReportConfirm()
                        {
                            id = 361,
                            investigation_id = 3,
                            hate = true,
                            remove = 1,
                            obscene = true
                        },
                        new ReportConfirm()
                        {
                            id = 362,
                            investigation_id = 3,
                            hate = true,
                            remove = 1,
                            obscene = true
                        },
                        new ReportConfirm()
                        {
                            id = 363,
                            investigation_id = 3,
                            hate = true,
                            remove = 1,
                            obscene = true
                        },
                        new ReportConfirm()
                        {
                            id = 364,
                            investigation_id = 3,
                            hate = true,
                            remove = 1,
                            obscene = true
                        },
                        new ReportConfirm()
                        {
                            id = 365,
                            investigation_id = 3,
                            hate = true,
                            remove = 1,
                            obscene = true
                        },
                        new ReportConfirm()
                        {
                            id = 366,
                            investigation_id = 3,
                            hate = true,
                            remove = 1,
                            obscene = true
                        },
                        new ReportConfirm()
                        {
                            id = 367,
                            investigation_id = 3,
                            hate = true,
                            remove = 1,
                            obscene = true
                        },
                        new ReportConfirm()
                        {
                            id = 368,
                            investigation_id = 3,
                            hate = true,
                            remove = 0,
                            obscene = true
                        },
                        new ReportConfirm()
                        {
                            id = 369,
                            investigation_id = 3,
                            hate = true,
                            remove = 0,
                            obscene = true
                        },
                        new ReportConfirm()
                        {
                            id = 370,
                            investigation_id = 3,
                            hate = true,
                            remove = 0,
                            obscene = true
                        },
                         new ReportConfirm()
                        {
                            id = 371,
                            investigation_id = 3,
                            hate = true,
                            remove = 0,
                            obscene = true
                        }
                    }
                }
            };
        }

        public Common.Models.MiningDTO GetMiningDTO()
        {
            return new Common.Models.MiningDTO()
            {
                IsIdentityHate = true,
                IsInsult = true,
                IsObscence = true,
                IsSevereToxic = true,
                IsSpam = true,
                IsThreat = true,
                IsToxic = true,
                Remove = true
            };
        }

    }
}
