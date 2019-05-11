using RateIt.Common.Models;
using RateIt.Model;
using RateIt.Repositories.Interfaces;
using RateIt.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Services
{
    public class ReportConfirmService : IReportConfirmService
    {
        private readonly IRepository<ReportConfirm> _reportConfirmRepository;

        public ReportConfirmService(IRepository<ReportConfirm> reportConfirmRepository)
        {
            _reportConfirmRepository = reportConfirmRepository;
        }

        public bool HasUserReviewedAlready(long userId, long investigationId)
        {
            var existingRecord = _reportConfirmRepository.GetAll()
                .FirstOrDefault(x => x.UserId == userId && x.InvestigationId == investigationId && !x.IsDeactivated);
            if (existingRecord != null) return true;
            return false;
        }

        public bool AddReportConfirm(long userId, long investigationId, Mining confirmData)
        {
            _reportConfirmRepository.Add(new ReportConfirm()
            {
                UserId = userId,
                InvestigationId = investigationId,
                Hate = confirmData.IsIdentityHate,
                Insult = confirmData.IsInsult,
                Obscene = confirmData.IsObscence,
                Racism = confirmData.IsRacism,
                RemoveComment = confirmData.Remove,
                Spam = confirmData.IsSpam,
                Threat = confirmData.IsThreat,
                Toxic = confirmData.IsToxic
            });
            return Convert.ToBoolean(_reportConfirmRepository.Save());
        }

        public IList<ReportConfirm> GetAllOpenReportConfirmsByInvestigationId(long investigationId)
        {
            return _reportConfirmRepository.GetAll()
                .Where(x => x.InvestigationId == investigationId && !x.IsDeactivated)
                .ToList();
        }

        public IList<ReportConfirm> GetAllReportConfirmsByInvestigationId(long investigationId)
        {
            return _reportConfirmRepository.GetAll()
                .Where(x => x.InvestigationId == investigationId)
                .ToList();
        }

        public bool DeactivateAllForInvestigation(long investigationId)
        {
            var reportConfirms = GetAllReportConfirmsByInvestigationId(investigationId);
            foreach (var reportConfirm in reportConfirms)
            {
                if (!reportConfirm.IsDeactivated)
                {
                    reportConfirm.IsDeactivated = true;
                    _reportConfirmRepository.Update(reportConfirm);
                }
            }
            return Convert.ToBoolean(_reportConfirmRepository.Save());
        }

        public bool RemoveAllReportConfirms(IList<ReportConfirm> reportConfirms)
        {
            if (reportConfirms != null && reportConfirms.Any())
            {
                _reportConfirmRepository.RemoveList(reportConfirms);
                return Convert.ToBoolean(_reportConfirmRepository.Save());
            }
            return false;
        }
    }
}
