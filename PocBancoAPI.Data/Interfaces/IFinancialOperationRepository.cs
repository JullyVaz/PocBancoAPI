using PocBancoAPI.Entities;
using PocBancoAPI.ViewModels.Filters;

namespace PocBancoAPI.Data.Interfaces
{
    public interface IFinancialOperationRepository
    {
        Task<int> InsertAsync(FinancialOperation transfer);
        Task<int> UpdateAsync(FinancialOperation transfer);
        Task<List<FinancialOperation>> GetAllAsync(FinancialOperationFilter transferFilter);
        Task<FinancialOperation> GetByIdAsync(int Id);

    }
}
