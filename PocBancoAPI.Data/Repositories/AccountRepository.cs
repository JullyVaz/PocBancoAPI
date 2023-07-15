using PocBancoAPI.Data.Interfaces;
using PocBancoAPI.Entities;
using PocBancoAPI.ViewModels.Filters;

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
