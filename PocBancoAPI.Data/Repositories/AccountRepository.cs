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
                .Include(x => x.User).AsNoTracking()
                .Include(x => x.FinancialOperations).AsNoTracking()
                .ToListAsync();

            return accounts;
        }

        public async Task<Account> GetByIdAsync(int Id)
        {
            Account account = await _appDbContext
                .Set<Account>()
                .AsNoTracking()
                .Include(x => x.User).AsNoTracking()
                .Include(x  => x.FinancialOperations).AsNoTracking()
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
            // Verificando se a conta existe
            Account existingAccount = await _appDbContext.Set<Account>()
                .FirstOrDefaultAsync(_account => _account.IdAccount == account.IdAccount);

            if (existingAccount != null)
            {
                // Atualiza as propriedades da conta existente com os novos valores
                _appDbContext.Entry(existingAccount).CurrentValues.SetValues(account);

                // Salva as alterações no banco de dados
                int result = await _appDbContext.SaveChangesAsync();
                return result;
            }
            else
            {
                return NotFound();
            }
        }

        private int NotFound()
        {
            throw new ArgumentException("O Id Account não foi encontrado");
        }
    }
}
