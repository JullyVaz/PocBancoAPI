using PocBancoAPI.Entities;
using PocBancoAPI.ViewModels.Filters;

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
