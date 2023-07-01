using PocBancoAPI.ViewModels;

namespace PocBancoAPI.API.Interfaces
{
    public interface IAccountService
    {
     Task <ServiceResponseViewModel<AccountViewModel>> Insert()
    }

}
