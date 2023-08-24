using Microsoft.EntityFrameworkCore;
using PocBancoAPI.Data.Context;
using PocBancoAPI.Data.Interfaces;
using PocBancoAPI.Entities;
using PocBancoAPI.ViewModels.Filters;

namespace PocBancoAPI.Data.Repositories
{
    public class FinancialOperationRespository : IFinancialOperationRepository
    {
        private readonly AppDbContext _appDbContext;
        public FinancialOperationRespository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<FinancialOperation>> GetAllAsync(FinancialOperationFilter transferFilter)
        {
            IQueryable<FinancialOperation> transfersQuery = _appDbContext.Set<FinancialOperation>()
                .Where(_transfer => transferFilter.IdTransfer != (int?)null ? _transfer.Idtransfer == (int)transferFilter.IdTransfer : true);

            List<FinancialOperation> transfers = await transfersQuery
                .AsNoTracking()
                .ToListAsync();

            return transfers;
        }

        public async Task<FinancialOperation> GetByIdAsync(int Id)
        {
            FinancialOperation transfer = await _appDbContext
                .Set<FinancialOperation>()
                .AsNoTracking()
                .FirstOrDefaultAsync(_transfer => _transfer.IdTransfer == Id);

            return transfer;

        }

        public async Task<int> InsertAsync(FinancialOperation transfer)
        {
            await _appDbContext.Set<FinancialOperation>().AddAsync(transfer);
            await _appDbContext.SaveChangesAsync();
            int IdTransfer = transfer.IdTransfer;
            return IdTransfer;
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

