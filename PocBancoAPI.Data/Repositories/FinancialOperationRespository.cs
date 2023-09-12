using Microsoft.EntityFrameworkCore;
using PocBancoAPI.Data.Context;
using PocBancoAPI.Data.Interfaces;
using PocBancoAPI.Entities;
using PocBancoAPI.ViewModels.Filters;


namespace PocBancoAPI.Data.Repositories
{
<<<<<<<< HEAD:PocBancoAPI.Data/Repositories/FinancialOperationRepository.cs
    public class FinancialOperationRepository : IFinancialOperationRepository
    {
        private readonly AppDbContext _appDbContext;
        public FinancialOperationRepository(AppDbContext appDbContext)
========
    public class FinancialOperationRespository : IFinancialOperationRepository
    {
        private readonly AppDbContext _appDbContext;
        public FinancialOperationRespository(AppDbContext appDbContext)
>>>>>>>> 3f420d68db60afbb122f30957d364e5e5b11514d:PocBancoAPI.Data/Repositories/FinancialOperationRespository.cs
        {
            _appDbContext = appDbContext;
        }

<<<<<<<< HEAD:PocBancoAPI.Data/Repositories/FinancialOperationRepository.cs
        public async Task<List<FinancialOperation>> GetAllAsync(FinancialOperationFilter financialoperationFilter)
        {
            IQueryable<FinancialOperation> financialoperationsQuery = _appDbContext.Set<FinancialOperation>()
                .Where(_financialoperation => financialoperationFilter.IdFinancialOperation != 0 ? 
                _financialoperation.IdFinancialOperation == (int)financialoperationFilter.IdFinancialOperation : true);

            List<FinancialOperation> financialoperations = await financialoperationsQuery
========
        public async Task<List<FinancialOperation>> GetAllAsync(FinancialOperationFilter transferFilter)
        {
            IQueryable<FinancialOperation> transfersQuery = _appDbContext.Set<FinancialOperation>()
                .Where(_transfer => transferFilter.IdTransfer != (int?)null ? _transfer.Idtransfer == (int)transferFilter.IdTransfer : true);

            List<FinancialOperation> transfers = await transfersQuery
>>>>>>>> 3f420d68db60afbb122f30957d364e5e5b11514d:PocBancoAPI.Data/Repositories/FinancialOperationRespository.cs
                .AsNoTracking()
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

<<<<<<<< HEAD:PocBancoAPI.Data/Repositories/FinancialOperationRepository.cs
        public async Task<int> InsertAsync(FinancialOperation financialoperation)
        {
            await _appDbContext.Set<FinancialOperation>().AddAsync(financialoperation);
========
        public async Task<int> InsertAsync(FinancialOperation transfer)
        {
            await _appDbContext.Set<FinancialOperation>().AddAsync(transfer);
>>>>>>>> 3f420d68db60afbb122f30957d364e5e5b11514d:PocBancoAPI.Data/Repositories/FinancialOperationRespository.cs
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

