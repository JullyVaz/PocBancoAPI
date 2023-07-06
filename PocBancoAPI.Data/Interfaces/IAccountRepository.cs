using PocBancoAPI.Entities;
using PocBancoAPI.Shared.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocBancoAPI.Data.Interfaces
{
    public interface IAccountRepository
    {
        Task<int> InsertAsync(Account account);
        Task<int> UpdateAsync(Account account);
        Task <List<Account>> GetAllAsync(AccountFilter accountFilter);  
    }
}
