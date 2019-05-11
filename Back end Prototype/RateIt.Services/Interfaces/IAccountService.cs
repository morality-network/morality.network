using RateIt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateIt.Services.Interfaces
{
    public interface IAccountService
    {
        Account GetAccountForUser(long userId);
        Account GetAdminAccount();
    }
}
