using PocBancoAPI.Entities;
using PocBancoAPI.ViewModels.Filters;

namespace PocBancoAPI.Data.Interfaces
{
    public interface IFinancialOperationRepository
    {
        Task<int> InsertAsync(FinancialOperation financialoperation);
        Task<int> UpdateAsync(FinancialOperation financialoperation);
        Task<List<FinancialOperation>> GetAllAsync(FinancialOperationFilter financialoperationFilter);
        Task<FinancialOperation> GetByIdAsync(int Id);

    }
}
