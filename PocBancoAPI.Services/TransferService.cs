using AutoMapper;
using PocBancoAPI.Business.Interfaces;
using PocBancoAPI.Data.UnitOfWork;
using PocBancoAPI.DTOs;
using PocBancoAPI.Services.Interfaces;
using PocBancoAPI.ViewModels;
using PocBancoAPI.ViewModels.Filters;
using System.Net;

namespace PocBancoAPI.Services;

public class TransferService : ITransferService
{
    private readonly ITransferBusiness _transferBusiness;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public TransferService(ITransferBusiness transferBusiness, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _transferBusiness = transferBusiness;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<ServiceResponseViewModel<List<TransferViewModel>>> GetAllAsync(TransferFilter transferFilter)
    {
        ServiceResponseViewModel<List<TransferViewModel>> serviceResponseViewModel = new ServiceResponseViewModel<List<TransferViewModel>>();
        try
        {
        }
        catch (Exception ex)
        {
            serviceResponseViewModel = new ServiceResponseViewModel<List<TransferViewModel>>(ex);
            await _unitOfWork.RollBackAsync();
        }
        return serviceResponseViewModel;
    }

    public async Task<ServiceResponseViewModel<TransferViewModel>> GetByIdAsync(int Id)
    {
        ServiceResponseViewModel<TransferViewModel> serviceResponseViewModel = new ServiceResponseViewModel<TransferViewModel>();
        try
        {
            TransferDTO transferDTO = await _transferBusiness.GetByIdAsync(Id);
            TransferViewModel transferViewModel = _mapper.Map<TransferViewModel>(transferDTO);
            serviceResponseViewModel.Data = transferViewModel;
        }
        catch (Exception ex)
        {
            serviceResponseViewModel = new ServiceResponseViewModel<TransferViewModel>(ex);
            await _unitOfWork.RollBackAsync();
        }
        return serviceResponseViewModel;
    }

    public async Task<ServiceResponseViewModel<TransferViewModel>> InsertAsync(TransferViewModel transferViewModel)
    {
        ServiceResponseViewModel<TransferViewModel> serviceResponseViewModel = new ServiceResponseViewModel<TransferViewModel>();
        try
        {
            TransferDTO transferDTO = _mapper.Map<TransferDTO>(transferViewModel);
            transferViewModel.IdTransfer = await _transferBusiness.InsertAsync(transferDTO);
            serviceResponseViewModel.StatusCode = HttpStatusCode.Created;
            serviceResponseViewModel.Data = transferViewModel;
            await _unitOfWork.CommitAsync();
        }
        catch (Exception ex)
        {
            serviceResponseViewModel = new ServiceResponseViewModel<TransferViewModel>(ex);
            await _unitOfWork.RollBackAsync();
        }
        return serviceResponseViewModel;
    }

    public async Task<ServiceResponseViewModel<TransferViewModel>> UpdateAsync(TransferViewModel transferViewModel)
    {
        ServiceResponseViewModel<TransferViewModel> serviceResponseViewModel = new ServiceResponseViewModel<TransferViewModel>();
        try
        {
            TransferDTO transferDTO = _mapper.Map<TransferDTO>(transferViewModel);
            transferDTO = await _transferBusiness.UpdateAsync(transferDTO);
            serviceResponseViewModel.StatusCode = HttpStatusCode.OK;
            serviceResponseViewModel.Data = _mapper.Map<TransferViewModel>(transferDTO);
            await _unitOfWork.CommitAsync();
        }
        catch (Exception ex)
        {
            serviceResponseViewModel = new ServiceResponseViewModel<TransferViewModel>(ex);
            await _unitOfWork.RollBackAsync();
        }
        return serviceResponseViewModel;
    }
}

