using AutoMapper;
using PocBancoAPI.Business.Interfaces;
using PocBancoAPI.Data.UnitOfWork;
using PocBancoAPI.DTOs;
using PocBancoAPI.Services.Interfaces;
using PocBancoAPI.ViewModels;

namespace PocBancoAPI.Services;

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

    public async Task<ServiceResponseViewModel<AccountViewModel>> Insert(AccountViewModel accountViewModel)
    {
        ServiceResponseViewModel<AccountViewModel> serviceResponseViewModel = new ServiceResponseViewModel<AccountViewModel>();
        try
        {
            AccountDTO accountDTO = _mapper.Map<AccountDTO>(accountViewModel);
            accountViewModel.IdAccount = await _accountBusiness.InsertAsync(accountDTO);
            //throw new Exception("Erro contexto de transacao");
            serviceResponseViewModel.Data = accountViewModel;
            await _unitOfWork.CommitAsync();
        }
        catch (Exception ex)
        {
            serviceResponseViewModel.Message = ex.GetBaseException().Message;
            await _unitOfWork.RollBackAsync();
        }
        return serviceResponseViewModel;
    }
}
