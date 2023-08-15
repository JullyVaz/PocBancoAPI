using PocBancoAPI.DTOs;
using PocBancoAPI.ViewModels.Filters;
using PocBancoAPI.ViewModels;

namespace PocBancoAPI.Business.Interfaces
{
    public interface ITransferBusiness
    {
        Task<int> InsertAsync(TransferDTO transferDTO);
        Task<ServiceResponseViewModel<List<TransferDTO>>> GetAllAsync(TransferFilter transferFilter);
        Task<TransferDTO> UpdateAsync(TransferDTO accountDTO);
        Task<TransferDTO> GetByIdAsync(int id);
        //Task<List<TransferDTO>> GetAllAsync(TransferFilter transferFilter);
    }
}




