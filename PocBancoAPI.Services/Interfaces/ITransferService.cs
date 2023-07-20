using PocBancoAPI.ViewModels;

namespace PocBancoAPI.Services.Interfaces
{
    public interface ITransferService
    {
        Task<ServiceResponseViewModel<TransferViewModel>> Insert(TransferViewModel transferViewModel);
    }
}
