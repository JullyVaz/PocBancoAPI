using PocBancoAPI.ViewModels;
using PocBancoAPI.ViewModels.Filters;

namespace PocBancoAPI.Services.Interfaces
{
    public interface ITransferService
    {
        Task<ServiceResponseViewModel<TransferViewModel>> InsertAsync(TransferViewModel transferViewModel);
        Task<ServiceResponseViewModel<TransferViewModel>> UpdateAsync(TransferViewModel TransferViewModel);
        Task<ServiceResponseViewModel<TransferViewModel>> GetByIdAsync(int id);
        Task<ServiceResponseViewModel<List<TransferViewModel>>> GetAllAsync(TransferFilter transferFilter);
    }
}
