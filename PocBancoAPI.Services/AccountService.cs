using AutoMapper;
using PocBancoAPI.Business.Interfaces;
using PocBancoAPI.Data.UnitOfWork;
using PocBancoAPI.DTOs;
using PocBancoAPI.Services.Interfaces;
using PocBancoAPI.ViewModels;
using PocBancoAPI.ViewModels.Filters;
using System.Collections.Generic;
using System.Net;

namespace PocBancoAPI.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountBusiness _accountBusiness;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public AccountService(IAccountBusiness accountBusiness, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _accountBusiness = accountBusiness;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceResponseViewModel<List<AccountViewModel>>> GetAllAsync(AccountFilter accountFilter)
        {
            ServiceResponseViewModel<List<AccountViewModel>> serviceResponseViewModel = new ServiceResponseViewModel<List<AccountViewModel>>();
            try
            {
            }
            catch (Exception ex)
            {
                serviceResponseViewModel = new ServiceResponseViewModel<List<AccountViewModel>>(ex);
                await _unitOfWork.RollBackAsync();
            }
            return serviceResponseViewModel;
        }

        public async Task<ServiceResponseViewModel<AccountViewModel>> GetByIdAsync(int Id)
        {
            ServiceResponseViewModel<AccountViewModel> serviceResponseViewModel = new ServiceResponseViewModel<AccountViewModel>();
            try
            {
                AccountDTO accountDTO = await _accountBusiness.GetByIdAsync(Id);
                AccountViewModel accountViewModel = _mapper.Map<AccountViewModel>(accountDTO);
                serviceResponseViewModel.Data = accountViewModel;
            }
            catch (Exception ex)
            {
                serviceResponseViewModel = new ServiceResponseViewModel<AccountViewModel>(ex);
                await _unitOfWork.RollBackAsync();
            }
            return serviceResponseViewModel;
        }

        public async Task<ServiceResponseViewModel<AccountViewModel>> InsertAsync(AccountViewModel accountViewModel)
        {
            ServiceResponseViewModel<AccountViewModel> serviceResponseViewModel = new ServiceResponseViewModel<AccountViewModel>();
            try
            {
                AccountDTO accountDTO = _mapper.Map<AccountDTO>(accountViewModel);
                accountViewModel.IdAccount = await _accountBusiness.InsertAsync(accountDTO);
                serviceResponseViewModel.StatusCode = HttpStatusCode.Created;
                serviceResponseViewModel.Data = accountViewModel;
                await _unitOfWork.CommitAsync();
            }
            catch (ArgumentException ex)
            {
                serviceResponseViewModel = new ServiceResponseViewModel<AccountViewModel>(ex);
                serviceResponseViewModel.StatusCode = HttpStatusCode.UnprocessableEntity;
                await _unitOfWork.RollBackAsync();
            }
            catch (Exception ex)
            {
                serviceResponseViewModel = new ServiceResponseViewModel<AccountViewModel>(ex);
                await _unitOfWork.RollBackAsync();
            }
            return serviceResponseViewModel;
        }

        public async Task<ServiceResponseViewModel<AccountViewModel>> UpdateAsync(AccountViewModel accountViewModel)
        {
            ServiceResponseViewModel<AccountViewModel> serviceResponseViewModel = new ServiceResponseViewModel<AccountViewModel>();
            try
            {
                AccountDTO accountDTO = _mapper.Map<AccountDTO>(accountViewModel);
                accountDTO = await _accountBusiness.UpdateAsync(accountDTO);
                serviceResponseViewModel.StatusCode = HttpStatusCode.OK;
                serviceResponseViewModel.Data = _mapper.Map<AccountViewModel>(accountDTO);
                await _unitOfWork.CommitAsync();
            }
            catch (ArgumentException ex)
            {
                serviceResponseViewModel = new ServiceResponseViewModel<AccountViewModel>(ex);
                serviceResponseViewModel.StatusCode = HttpStatusCode.UnprocessableEntity;
                await _unitOfWork.RollBackAsync();
            }

            catch (Exception ex)
            {
                serviceResponseViewModel = new ServiceResponseViewModel<AccountViewModel>(ex);
                await _unitOfWork.RollBackAsync();
            }
            return serviceResponseViewModel;
        }
    }

}

