using Microsoft.EntityFrameworkCore;
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

        public async Task<List<Account>> GetAllAsync(AccountFilter accountFilter)
        {
            IQueryable<Account> accountsQuery = _appDbContext.Set<Account>()
                .Where(_account => accountFilter.IdAccount != (int?)null ? _account.IdAccount == (int)accountFilter.IdAccount : true);

            List<Account> accounts = await accountsQuery
                .AsNoTracking()
                .ToListAsync();

            return accounts;
        }

        public async Task<Account> GetByIdAsync(int Id)
        {
            Account account = await _appDbContext
                .Set<Account>()
                .AsNoTracking()
                .FirstOrDefaultAsync(_account => _account.IdAccount == Id);

            return account;

        }

        public async Task<int> InsertAsync(Account account)
        {
            await _appDbContext.Set<Account>().AddAsync(account);
            await _appDbContext.SaveChangesAsync();
            int IdAccount = account.IdAccount;
            return IdAccount;
        }

        public async Task<int> UpdateAsync(Account account)
        {
            _appDbContext.Set<Account>().Update(account);
            int result = await _appDbContext.SaveChangesAsync();
            return result;
        }
    }
}
