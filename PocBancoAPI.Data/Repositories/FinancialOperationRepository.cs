using Microsoft.EntityFrameworkCore;
using PocBancoAPI.Data.Context;
using PocBancoAPI.Data.Interfaces;
using PocBancoAPI.Entities;
using PocBancoAPI.ViewModels.Filters;


namespace PocBancoAPI.Data.Repositories
{
    public class FinancialOperationRepository : IFinancialOperationRepository
    {
        private readonly AppDbContext _appDbContext;
        public FinancialOperationRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<FinancialOperation>> GetAllAsync(FinancialOperationFilter financialOperationFilter)
        {
            IQueryable<FinancialOperation> financialoperationsQuery = _appDbContext.Set<FinancialOperation>()
                .Where(_financialoperation => financialOperationFilter.IdFinancialOperation != 0 ?
                _financialoperation.IdFinancialOperation == (int)financialOperationFilter.IdFinancialOperation : true);

            List<FinancialOperation> financialoperations = await financialoperationsQuery
                .AsNoTracking()
                .Skip(financialOperationFilter.skip)
                .Take(financialOperationFilter.pageSize)
                .ToListAsync();

            return financialoperations;
        }

        public async Task<FinancialOperation> GetByIdAsync(int Id)
        {
            FinancialOperation transfer = await _appDbContext
                .Set<FinancialOperation>()
                .AsNoTracking()
                .FirstOrDefaultAsync(_transfer => _transfer.IdFinancialOperation == Id);

            return transfer;

        }

        public async Task<int> InsertAsync(FinancialOperation financialoperation)
        {
            await _appDbContext.Set<FinancialOperation>().AddAsync(financialoperation);
            await _appDbContext.SaveChangesAsync();
            int IdFinancialOperation = financialoperation.IdFinancialOperation;
            return IdFinancialOperation;
        }

        public Task<int> UpdateAsync(FinancialOperation transfer)
        {
            throw new NotImplementedException();
        }

        //public async Task<int> UpdateAsync(Transfer transfer)
        //{
        //    // Verificando se a conta origem e destino existem???
        //    Account existingAccount = await _appDbContext.Set<Account>()
        //        .FirstOrDefaultAsync(_account => _account.IdAccount == account.IdAccount);

        //    if (existingAccount != null)
        //    {
        //        // Atualiza as propriedades da conta existente com os novos valores
        //        _appDbContext.Entry(existingAccount).CurrentValues.SetValues(account);

        //        // Salva as alterações no banco de dados
        //        int result = await _appDbContext.SaveChangesAsync();
        //        return result;
        //    }
        //    else
        //    {
        //        return NotFound();
        //    }
        //}

        //private int NotFound()
        //{
        //    throw new ArgumentException("O Id Account não foi encontrado");
        //}


        //public async Task<int> UpdateAsync(Account account)
        //{
        //_appDbContext.Set<Account>().Update(account);
        //int result = await _appDbContext.SaveChangesAsync();
        //return result;
        //}
    }
}
