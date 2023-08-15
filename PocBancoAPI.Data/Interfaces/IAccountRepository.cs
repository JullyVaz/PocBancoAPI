using PocBancoAPI.Entities;
using PocBancoAPI.ViewModels.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PocBancoAPI.Data.Interfaces
{
    public interface IAccountRepository
    {
        Task<Account> GetByIdAsync(int Id);
        Task<int> InsertAsync(Account account);
        Task<int> UpdateAsync(Account account);
        Task<List<Account>> GetAllAsync(AccountFilter accountFilter);
    }
}
