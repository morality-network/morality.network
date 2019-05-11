using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Services.Interfaces
{
    public interface IUserReportService
    {
        int GetAllUsersReportsCount(long userId);
    }
}
