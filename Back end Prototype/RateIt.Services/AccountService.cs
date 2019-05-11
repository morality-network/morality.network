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
    public class AccountService : IAccountService
    {
        private readonly IRepository<Account> _accountRepository;

        public AccountService(IRepository<Account> accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public Account GetAccountForUser(long userId)
        {
            return _accountRepository.GetAll()
                .FirstOrDefault(x => x.UserId == userId);
        }

        public Account GetAdminAccount()
        {
            return _accountRepository.GetAll()
                .FirstOrDefault(x => x.IsAdmin && x.Active);
        }
    }
}
