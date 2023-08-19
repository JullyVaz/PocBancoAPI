using PocBancoAPI.ViewModels;

namespace PocBancoAPI.Services.Interfaces
{
    public interface IAuthServiceBase
    {

        public Task<ServiceResponseViewModel<string>> Login(UserViewModel userLoginViewModel);
        public Task<ServiceResponseViewModel<UserViewModel>> Register(UserToInsertViewModel userToInsertViewModel);
    }
}