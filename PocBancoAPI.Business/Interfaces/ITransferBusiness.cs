using PocBancoAPI.DTOs;

namespace PocBancoAPI.Business.Interfaces
{
    public interface ITransferBusiness
    {
        Task<int> InsertAsync(TransferDTO transferDTO);
    }
}

