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
    public class UserReportService : IUserReportService
    {
        private readonly IRepository<ReportClaim> _userReportRepository; 

        public UserReportService(IRepository<ReportClaim> userReportRepository)
        {
            _userReportRepository = userReportRepository;
        }

        public int GetAllUsersReportsCount(long userId)
        {
            return _userReportRepository.GetAll()
                .Where(x => x.ByUser == userId)
                .Count();
        }
    }
}
