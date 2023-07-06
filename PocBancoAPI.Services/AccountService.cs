
using PocBancoAPI.Services.Interfaces;
using PocBancoAPI.ViewModels;

namespace PocBancoAPI.Services;

public class AccountService : IAccountService
{
    public async Task<ServiceResponseViewModel<AccountViewModel>> Insert(AccountViewModel accountViewModel)
    {
        ServiceResponseViewModel<AccountViewModel> serviceResponseViewModel = new ServiceResponseViewModel<AccountViewModel>();
        try
        {

        }
        catch (Exception ex)
        {
            serviceResponseViewModel.Message = ex.GetBaseException().Message;
            throw;
        }
        return serviceResponseViewModel;
    }
}
