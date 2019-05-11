using RateIt.Common.Models;
using RateIt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Services.Interfaces
{
    public interface IReportConfirmService
    {
        bool HasUserReviewedAlready(long userId, long investigationId);
        bool AddReportConfirm(long userId, long investigationId, Mining confirmData);
        IList<ReportConfirm> GetAllOpenReportConfirmsByInvestigationId(long investigationId);
        IList<ReportConfirm> GetAllReportConfirmsByInvestigationId(long investigationId);
        bool DeactivateAllForInvestigation(long investigationId);
        bool RemoveAllReportConfirms(IList<ReportConfirm> reportConfirms);
    }
}
