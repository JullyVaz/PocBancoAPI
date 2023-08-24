using PocBancoAPI.DTOs;
using PocBancoAPI.ViewModels.Filters;
using PocBancoAPI.ViewModels;

namespace PocBancoAPI.Business.Interfaces
{
    public interface IFinancialOperationBusiness
    {
        Task<int> InsertAsync(FinancialOperationDTO transferDTO);
        Task<ServiceResponseViewModel<List<FinancialOperationDTO>>> GetAllAsync(FinancialOperationFilter transferFilter);
        Task<FinancialOperationDTO> UpdateAsync(FinancialOperationDTO accountDTO);
        Task<FinancialOperationDTO> GetByIdAsync(int id);
        //Task<List<TransferDTO>> GetAllAsync(TransferFilter transferFilter);
    }
}




