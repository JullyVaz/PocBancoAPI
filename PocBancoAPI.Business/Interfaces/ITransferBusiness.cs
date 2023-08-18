using PocBancoAPI.DTOs;
using PocBancoAPI.ViewModels.Filters;
using PocBancoAPI.ViewModels;

namespace PocBancoAPI.Business.Interfaces
{
    public interface ITransferBusiness
    {
        Task<int> InsertAsync(TransferDTO transferDTO);
        Task<List<TransferDTO>> GetAllAsync(TransferFilter transferFilter);
        Task<TransferDTO> UpdateAsync(TransferDTO transferDTO);
        Task<TransferDTO> GetByIdAsync(int id);       
    }
}

