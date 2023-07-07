using PocBancoAPI.Entities;
using PocBancoAPI.Shared.Filters;

namespace PocBancoAPI.Data.Interfaces
{
    public interface IAccountRepository
    {
        Task<int> InsertAsync(Account account);
        Task<int> UpdateAsync(Account account);
        Task<List<Account>> GetAllAsync(AccountFilter accountFilter);
    }
}
