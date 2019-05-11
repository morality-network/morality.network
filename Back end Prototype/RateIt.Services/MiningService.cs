using RateIt.Common.Models;
using RateIt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RateIt.Services.Interfaces;
using RateIt.Repositories.Interfaces;
using RateIt.Common.Models.Enums;

namespace RateIt.Services
{
    public class MiningService : IMiningService
    {
        public static int LIMIT = 30;
        public static int MAX_INVESTIGATION_SIZE = 20;
        public static double MIN_THRESHOLD = 80.0;//percent
        private readonly IInvestigationService _investigationService;
        private readonly IReportConfirmService _reportConfirmService;
        private readonly ICreditWalletService _creditWalletService;
        private readonly ISystemValueService _systemValuesService;

        public MiningService(IInvestigationService investigationService, IReportConfirmService reportConfirmService,
            ICreditWalletService creditWalletService, ISystemValueService systemValuesService)
        {
            _investigationService = investigationService;
            _reportConfirmService = reportConfirmService;
            _creditWalletService = creditWalletService;
            _systemValuesService = systemValuesService;
        }

        public IList<Investigation> GetTopInvestigations(int limit, long userId)
        {
            var investigations = _investigationService.GetAllInvestigations(limit, userId);
            if (investigations == null || !investigations.Any())
                return new List<Investigation>();
            return investigations;
        }

        public bool AddReview(long userid, long investigationId, Mining confirmData)
        {
            var investigation = _investigationService.GetInvestigationById(investigationId);
            if (investigation != null)
            {
                var hasntAlreadyVoted = _reportConfirmService.HasUserReviewedAlready(userid, investigation.Id);
                if (!hasntAlreadyVoted)
                {
                    bool voted = _reportConfirmService.AddReportConfirm(userid, investigation.Id, confirmData);
                    if (voted)
                    {
                        TryToConcludeInvestigation(investigation.Id);
                        return true;
                    }
                }
                else return false;
            }
            return true;
        }

        public bool TryToConcludeInvestigation(long investigationId)
        {
            var investigation = _investigationService.GetInvestigationById(investigationId);
            if (investigation != null)
            {
                var openReportConfirms = _reportConfirmService.GetAllOpenReportConfirmsByInvestigationId(investigationId);
                var investTotal = (investigation.OverallKeep + investigation.OverallRemove);
                if (investTotal >= MAX_INVESTIGATION_SIZE)
                {
                    //Conclude
                    double overallKeep = ((double)(investigation.OverallKeep)) / ((double)investTotal) * 100.0;
                    double overallRemove = ((double)(investigation.OverallRemove)) / ((double)investTotal) * 100.0;
                    IList<ReportConfirm> confirms;
                    double highestValue;
                    InvestigationType type;

                    //Set the groups
                    if (overallKeep >= overallRemove)
                    {
                        highestValue = overallKeep;
                        confirms = investigation.ReportConfirms.Where(rc => !rc.RemoveComment).ToList();
                        type = InvestigationType.Keep;
                    }
                    else
                    {
                        highestValue = overallRemove;
                        confirms = investigation.ReportConfirms.Where(rc => !rc.RemoveComment == true).ToList();
                        type = InvestigationType.Keep;
                    }

                    //Check we can close
                    if (highestValue >= MIN_THRESHOLD)
                    {
                        //Resolve the investigation
                        var resolved = _investigationService.ResolveInvestigation(investigation.Id, type);
                        if (resolved)
                        {
                            //Pay credit
                            var userIds = confirms.Select(x => x.User).ToList();
                            _creditWalletService.PayIntoWallets(userIds, _systemValuesService.GetCurrentMiningAmount());
                            return true;
                        }
                    }
                    else
                    {
                        //Noone is paid and investigation is reset (reopened)
                        _reportConfirmService.DeactivateAllForInvestigation(investigation.Id);
                        _investigationService.UpInvestigationCounter(investigation.Id);
                    }
                }
            }
            return false;
        }
    }

    public enum ConfirmResult
    {
        Keep = 0,
        Remove = 1
    }
}
