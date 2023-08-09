using PocBancoAPI.ViewModels;
using PocBancoAPI.ViewModels.Filters;

namespace PocBancoAPI.Services.Interfaces
{
    public interface IAccountService
    {
        Task<ServiceResponseViewModel<AccountViewModel>> InsertAsync(AccountViewModel accountViewModel);
        Task<ServiceResponseViewModel<AccountViewModel>> UpdateAsync(AccountViewModel accountViewModel);
        Task<ServiceResponseViewModel<AccountViewModel>> GetByIdAsync(int id);
        Task<ServiceResponseViewModel<List<AccountViewModel>>> GetAllAsync(AccountFilter accountFilter);
    }
}