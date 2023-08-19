using PocBancoAPI.ViewModels;
using PocBancoAPI.DTOs;

namespace PocBancoAPI.Services.Interfaces
{
    public interface IAuthService
    {
        public Task<ServiceResponseViewModel<UserViewModel>> Register(UserToInsertViewModel userToInsertViewModel);

        public Task<ServiceResponseViewModel<string>> Login(UserViewModel userLoginViewModel);

    }
}

