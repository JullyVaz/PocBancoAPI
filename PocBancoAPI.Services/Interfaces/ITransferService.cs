using PocBancoAPI.ViewModels;
using PocBancoAPI.ViewModels.Filters;

namespace PocBancoAPI.Services.Interfaces
{
    public interface ITransferService
    {
        Task<ServiceResponseViewModel<List<TransferViewModel>>> GetAll(TransferFilter transferFilter);
        Task<ServiceResponseViewModel<TransferViewModel>> Insert(TransferViewModel transferViewModel);
    }
}
