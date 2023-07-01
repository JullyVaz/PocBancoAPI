using PocBancoAPI.API.Interfaces;
using PocBancoAPI.ViewModels;

namespace PocBancoAPI.Services;

public class AccountService : IAccountService
{
    public Task<ServiceResponseViewModel<AccountViewModel>> Insert(AccountViewModel accountViewModel)
    {
        throw new NotImplementedException();
    }
}
