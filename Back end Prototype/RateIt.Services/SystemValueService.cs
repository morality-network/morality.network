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
    public class SystemValueService : ISystemValueService
    {
        private readonly IRepository<SystemValue> _systemValueRepository;

        public SystemValueService(IRepository<SystemValue> systemValueRepository)
        {
            _systemValueRepository = systemValueRepository;
        }

        public SystemValue GetNewestSystemValue()
        {
           return _systemValueRepository.GetAll()
                .OrderByDescending(x => x.Timestamp)
                .FirstOrDefault();
        }

        public double GetCurrentMiningAmount()
        {
            var systemValue = GetNewestSystemValue();
            if (systemValue != null) return systemValue.AmountToPayForTraining;
            return 0;
        }

        public long GetAdminId()
        {
            var systemValue = GetNewestSystemValue();
            if (systemValue != null) return systemValue.AdminUserId;
            return 0;
        }
    }
}
