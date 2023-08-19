using PocBancoAPI.ViewModels;

namespace PocBancoAPI.Services.Interfaces
{
    public interface IUserService
    {
        Task<ServiceResponseViewModel<UserViewModel>> Update(UserViewModel userViewModel);

        Task<ServiceResponseViewModel<UserViewModel>> Delete(UserViewModel userViewModel);
    }
}
