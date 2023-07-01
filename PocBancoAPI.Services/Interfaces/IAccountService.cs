using PocBancoAPI.ViewModels;

namespace PocBancoAPI.Services.Interfaces
{
    public interface IAccountService
    {
        Task<ServiceResponseViewModel<AccountViewModel>> Insert(AccountViewModel accountViewModel);
    }
}
