using RateIt.Common.Models.Enums;
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
    public class InvestigationService : IInvestigationService
    {
        private readonly IRepository<Investigation> _investigationRepository;
        private readonly IReportConfirmService _reportConfirmService;

        public InvestigationService(IRepository<Investigation> investigationRepository, IReportConfirmService reportConfirmService)
        {
            _investigationRepository = investigationRepository;
            _reportConfirmService = reportConfirmService;
        }

        public Investigation GetInvestigationById(long id)
        {
            return _investigationRepository.GetAll().FirstOrDefault(x => x.Id == id);
        }

        public IList<Investigation> GetEligableInvestigations(int limit, long userId)
        {
            return _investigationRepository.GetAll()
                .OrderBy(x => x.Timestamp)
                .Where(x => !(x.ReportConfirms.Select(y => y.UserId)).Contains(userId))
                .Take(limit)
                .ToList();
        }

        public IList<Investigation> GetAllInvestigations(int limit, long userId)
        {
            return _investigationRepository.GetAll()
                .OrderBy(x => x.Timestamp)
                .Take(limit)
                .ToList();
        }

        public bool ResolveInvestigation(long investigationId, InvestigationType type)
        {
            var investigation = GetInvestigationById(investigationId);
            if(investigation != null)
            {
                var reportConfirms = _reportConfirmService.GetAllReportConfirmsByInvestigationId(investigationId);
                _reportConfirmService.RemoveAllReportConfirms(reportConfirms);
                investigation.Resolved = true;
                investigation.Removed = type==InvestigationType.Remove? true : false;
                _investigationRepository.Update(investigation);
                return Convert.ToBoolean(_investigationRepository.Save());
            }
            return false;
        }

        public bool UpInvestigationCounter(long investigationId)
        {
            var investigation = GetInvestigationById(investigationId);
            if(investigation != null)
            {
                investigation.PassCounter++;
                _investigationRepository.Update(investigation);
                return Convert.ToBoolean(_investigationRepository.Save());
            }
            return false;
        }

        public Investigation GetInvestigationByCommentId(long commentId)
        {
            return _investigationRepository.GetAll()
                .FirstOrDefault(x => x.CommentId == commentId);
        }

        public bool DoesInvestigationExistForComment(long commentId)
        {
            if (GetInvestigationByCommentId(commentId) != null) return true;
            return false;
        }

        public bool AddInvestigation(long userid, long commentId)
        {
            _investigationRepository.Add(new Investigation()
            {
                CommentId = commentId,
                OverallKeep = 0,
                OverallRemove = 0,
                PassCounter = 0,
                Removed = false,
                Resolved = false,
                Timestamp = DateTime.Now
            });
            return Convert.ToBoolean(_investigationRepository.Save());
        }

    }
}
