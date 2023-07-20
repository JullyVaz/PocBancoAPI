using PocBancoAPI.Business.Interfaces;
using PocBancoAPI.DTOs;

namespace PocBancoAPI.Business
{
    public class TransferBusiness : ITransferBusiness
    {
        public Task<int> InsertAsync(TransferDTO transferDTO)
        {
            throw new NotImplementedException();
        }
    }
}
