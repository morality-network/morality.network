using RateIt.Common.Models.Enums;
using RateIt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Services.Interfaces
{
    public interface IInvestigationService
    {
        IList<Investigation> GetEligableInvestigations(int limit, long userId);
        IList<Investigation> GetAllInvestigations(int limit, long userId);
        Investigation GetInvestigationById(long id);
        bool ResolveInvestigation(long investigationId, InvestigationType type);
        bool UpInvestigationCounter(long investigationId);
        Investigation GetInvestigationByCommentId(long commentId);
        bool DoesInvestigationExistForComment(long commentId);
        bool AddInvestigation(long userid, long commentId);
    }
}
