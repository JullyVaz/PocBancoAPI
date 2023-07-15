
using AutoMapper;
using PocBancoAPI.Business.Interfaces;
using PocBancoAPI.DTOs;
using PocBancoAPI.Services.Interfaces;
using PocBancoAPI.ViewModels;

namespace PocBancoAPI.Services;

public class AccountService : IAccountService
{
    private readonly IAccountBusiness _accountBusiness;
    private readonly IMapper _mapper;

    public AccountService(IAccountBusiness accountBusiness, IMapper mapper)
    {
        _accountBusiness = accountBusiness;
        _mapper = mapper;
    }

    public async Task<ServiceResponseViewModel<AccountViewModel>> Insert(AccountViewModel accountViewModel)
    {
        ServiceResponseViewModel<AccountViewModel> serviceResponseViewModel = new ServiceResponseViewModel<AccountViewModel>();
        try
        {
            AccountDTO accountDTO = _mapper.Map<AccountDTO>(accountViewModel);
        }
        catch (Exception ex)
        {
            serviceResponseViewModel.Message = ex.GetBaseException().Message;
            throw;
        }
        return serviceResponseViewModel;
    }
}
