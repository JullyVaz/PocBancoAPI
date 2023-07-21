using PocBancoAPI.Data.Context;
using PocBancoAPI.Data.Interfaces;
using PocBancoAPI.Entities;
using PocBancoAPI.ViewModels.Filters;

namespace PocBancoAPI.Data.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AppDbContext _appDbContext;
        public AccountRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Task<List<Account>> GetAllAsync(AccountFilter accountFilter)
        {
            throw new NotImplementedException();
        }

        public async Task<int> InsertAsync(Account account)
        {
            await _appDbContext.Set<Account>().AddAsync(account);
            await _appDbContext.SaveChangesAsync();
            int IdAccount = account.IdAccount;
            return IdAccount;
        }

        public Task<int> UpdateAsync(Account account)
        {
            throw new NotImplementedException();
        }
    }
}
