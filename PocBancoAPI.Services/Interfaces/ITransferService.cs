using PocBancoAPI.ViewModels;
using PocBancoAPI.ViewModels.Filters;

namespace PocBancoAPI.Services.Interfaces
{
    public interface ITransferService
    {
        Task<ServiceResponseViewModel<List<TransferViewModel>>> GetAllAsync(TransferFilter transferFilter);
        Task<ServiceResponseViewModel<TransferViewModel>> InsertAsync(TransferViewModel transferViewModel);
    }
}
