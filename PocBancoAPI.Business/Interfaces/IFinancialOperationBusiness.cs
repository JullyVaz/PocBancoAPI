using PocBancoAPI.DTOs;
using PocBancoAPI.ViewModels.Filters;
using PocBancoAPI.ViewModels;

namespace PocBancoAPI.Business.Interfaces
{
    public interface IFinancialOperationBusiness
    {
        Task<int> InsertAsync(FinancialOperationDTO financialoperationDTO);
        Task<List<FinancialOperationDTO>> GetAllAsync(FinancialOperationFilter financialoperationFilter);
        Task<FinancialOperationDTO> UpdateAsync(FinancialOperationDTO financialoperationDTO);
        Task<FinancialOperationDTO> GetByIdAsync(int id);
      
    }
}




