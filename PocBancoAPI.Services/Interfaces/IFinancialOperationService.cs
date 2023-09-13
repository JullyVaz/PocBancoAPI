using PocBancoAPI.ViewModels;
using PocBancoAPI.ViewModels.Filters;

namespace PocBancoAPI.Services.Interfaces
{
    public interface IFinancialOperationService
    {
        Task<ServiceResponseViewModel<FinancialOperationViewModel>> InsertAsync(FinancialOperationViewModel financialoperationViewModel);
        Task<ServiceResponseViewModel<FinancialOperationViewModel>> UpdateAsync(FinancialOperationViewModel financialoperationViewModel);
        Task<ServiceResponseViewModel<FinancialOperationViewModel>> GetByIdAsync(int id);
        Task<ServiceResponseViewModel<List<FinancialOperationViewModel>>> GetAllAsync(FinancialOperationFilter financialoperationFilter);
    }
}
