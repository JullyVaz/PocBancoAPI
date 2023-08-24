using AutoMapper;
using PocBancoAPI.Business.Interfaces;
using PocBancoAPI.Data.UnitOfWork;
using PocBancoAPI.DTOs;
using PocBancoAPI.Services.Interfaces;
using PocBancoAPI.ViewModels;
using PocBancoAPI.ViewModels.Filters;
using System.Net;

namespace PocBancoAPI.Services;

public class FinancialOperationService : IFinancialOperationService
{
    private readonly IFinancialOperationBusiness _financialOperationBusiness;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public FinancialOperationService(IFinancialOperationBusiness transferBusiness, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _financialOperationBusiness = transferBusiness;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public Task<ServiceResponseViewModel<List<FinancialOperationViewModel>>> GetAllAsync(FinancialOperationFilter transferFilter)
    {
        throw new NotImplementedException();
    }

    public async Task<ServiceResponseViewModel<FinancialOperationViewModel>> GetByIdAsync(int Id)
    {
        ServiceResponseViewModel<FinancialOperationViewModel> serviceResponseViewModel = new ServiceResponseViewModel<FinancialOperationViewModel>();
        try
        {
            FinancialOperationDTO financialOperationDTO = await _financialOperationBusiness.GetByIdAsync(Id);
            FinancialOperationViewModel financialOperationViewModel = _mapper.Map<FinancialOperationViewModel>(financialOperationDTO);
            serviceResponseViewModel.Data = financialOperationViewModel;
        }
        catch (Exception ex)
        {
            serviceResponseViewModel = new ServiceResponseViewModel<FinancialOperationViewModel>(ex);
            await _unitOfWork.RollBackAsync();
        }
        return serviceResponseViewModel;
    }

    public async Task<ServiceResponseViewModel<FinancialOperationViewModel>> InsertAsync(FinancialOperationViewModel transferViewModel)
    {
        ServiceResponseViewModel<FinancialOperationViewModel> serviceResponseViewModel = new ServiceResponseViewModel<FinancialOperationViewModel>();
        try
        {
            FinancialOperationDTO transferDTO = _mapper.Map<FinancialOperationDTO>(transferViewModel);
            transferViewModel.IdTransfer = await _financialOperationBusiness.InsertAsync(transferDTO);
            serviceResponseViewModel.StatusCode = HttpStatusCode.Created;
            serviceResponseViewModel.Data = transferViewModel;
            await _unitOfWork.CommitAsync();
        }
        catch (Exception ex)
        {
            serviceResponseViewModel = new ServiceResponseViewModel<FinancialOperationViewModel>(ex);
            await _unitOfWork.RollBackAsync();
        }
        return serviceResponseViewModel;
    }

    public async Task<ServiceResponseViewModel<FinancialOperationViewModel>> UpdateAsync(FinancialOperationViewModel transferViewModel)
    {
        ServiceResponseViewModel<FinancialOperationViewModel> serviceResponseViewModel = new ServiceResponseViewModel<FinancialOperationViewModel>();
        try
        {
            FinancialOperationDTO transferDTO = _mapper.Map<FinancialOperationDTO>(transferViewModel);
            transferDTO = await _financialOperationBusiness.UpdateAsync(transferDTO);
            serviceResponseViewModel.StatusCode = HttpStatusCode.OK;
            serviceResponseViewModel.Data = _mapper.Map<FinancialOperationViewModel>(transferDTO);
            await _unitOfWork.CommitAsync();
        }
        catch (Exception ex)
        {
            serviceResponseViewModel = new ServiceResponseViewModel<FinancialOperationViewModel>(ex);
            await _unitOfWork.RollBackAsync();
        }
        return serviceResponseViewModel;
    }
}

