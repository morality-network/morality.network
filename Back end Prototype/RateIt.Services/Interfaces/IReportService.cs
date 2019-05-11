using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Services.Interfaces
{
    public interface IReportService
    {
        bool ReportComment(long userid,int commentId);
        bool HasUserAlreadyReported(long userId, long commentId);
        int GetReportClaimCountForComment(long commentId);
    }
}
