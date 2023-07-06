using PocBancoAPI.Data.Interfaces;
using PocBancoAPI.Entities;
using PocBancoAPI.Shared.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocBancoAPI.Data.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        public Task<List<Account>> GetAllAsync(AccountFilter accountFilter)
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertAsync(Account account)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(Account account)
        {
            throw new NotImplementedException();
        }
    }
}
