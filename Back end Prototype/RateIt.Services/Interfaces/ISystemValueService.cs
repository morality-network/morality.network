using RateIt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Services.Interfaces
{
    public interface ISystemValueService
    {
        double GetCurrentMiningAmount();
        SystemValue GetNewestSystemValue();
        long GetAdminId();
    }
}
