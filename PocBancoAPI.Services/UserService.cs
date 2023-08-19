using AutoMapper;
using PocBancoAPI.Business.Interfaces;
using PocBancoAPI.Data.UnitOfWork;
using PocBancoAPI.DTOs;
using PocBancoAPI.Services.Interfaces;
using PocBancoAPI.ViewModels;

namespace PocBancoAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserBusiness _userBusiness;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUserBusiness userBusiness, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _userBusiness = userBusiness;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceResponseViewModel<UserViewModel>> Delete(UserViewModel userViewModel)
        {
            ServiceResponseViewModel<UserViewModel> serviceResponseViewModel = new ServiceResponseViewModel<UserViewModel>();
            try
            {
                UserDTO userDTO = _mapper.Map<UserDTO>(userViewModel);
                userDTO.IsActive = false;
                userDTO = await _userBusiness.Update(userDTO);
                userViewModel = _mapper.Map<UserViewModel>(userDTO);
                serviceResponseViewModel.Data = userViewModel;
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                serviceResponseViewModel.IsSucess = false;
                serviceResponseViewModel.Message = ex.GetBaseException().Message;
                await _unitOfWork.RollbackAscync();
            }

            return serviceResponseViewModel;
        }

        public async Task<ServiceResponseViewModel<UserViewModel>> Update(UserViewModel userViewModel)
        {
            ServiceResponseViewModel<UserViewModel> serviceResponseViewModel = new ServiceResponseViewModel<UserViewModel>();
            try
            {
                UserDTO userDTO = _mapper.Map<UserDTO>(userViewModel);
                userDTO = await _userBusiness.Update(userDTO);
                userViewModel = _mapper.Map<UserViewModel>(userDTO);
                serviceResponseViewModel.Data = userViewModel;
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                serviceResponseViewModel.IsSucess = false;
                serviceResponseViewModel.Message = ex.GetBaseException().Message;
                await _unitOfWork.RollbackAscync();
            }

            return serviceResponseViewModel;
        }
    }
}

