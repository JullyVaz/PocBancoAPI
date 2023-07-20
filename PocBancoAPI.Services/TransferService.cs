﻿using AutoMapper;
using PocBancoAPI.Business.Interfaces;
using PocBancoAPI.DTOs;
using PocBancoAPI.Services.Interfaces;
using PocBancoAPI.ViewModels;

namespace PocBancoAPI.Services;

public class TransferService : ITransferService
{
    private readonly ITransferBusiness _transferBusiness;
    private readonly IMapper _mapper;

    public TransferService(ITransferBusiness transferBusiness, IMapper mapper)
    {
        _transferBusiness = transferBusiness;
        _mapper = mapper;
    }

    public async Task<ServiceResponseViewModel<TransferViewModel>> Insert(TransferViewModel transferViewModel)
    {
        ServiceResponseViewModel<TransferViewModel> serviceResponseViewModel = new ServiceResponseViewModel<TransferViewModel>();
        try
        {
            TransferDTO transferDTO = _mapper.Map<TransferDTO>(transferViewModel);
        }
        catch (Exception ex)
        {
            serviceResponseViewModel.Message = ex.GetBaseException().Message;
            throw;
        }
        return serviceResponseViewModel;
    }
}