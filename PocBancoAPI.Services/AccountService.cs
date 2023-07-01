
using PocBancoAPI.Services.Interfaces;
using PocBancoAPI.ViewModels;

namespace PocBancoAPI.Services;

public class AccountService : IAccountService
{
    public async Task<ServiceResponseViewModel<AccountViewModel>> Insert(AccountViewModel accountViewModel)
    {
        await Task.Delay(100);
       return new ServiceResponseViewModel<AccountViewModel> ()
       { Data = new AccountViewModel {Id=1,FirstName="Juliane arrasouuuuuuuuuu!!!!" } };
    }
}
