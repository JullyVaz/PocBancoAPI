using PocBancoAPI.Business.Interfaces;
using PocBancoAPI.DTOs;
using PocBancoAPI.ViewModels;
using PocBancoAPI.ViewModels.Filters;

namespace PocBancoAPI.Business
{
    public class TransferBusiness : ITransferBusiness
    {
        public async Task<ServiceResponseViewModel<List<TransferDTO>>> GetAllAsync(TransferFilter transferFilter)
        {
            throw new NotImplementedException();
        }

        public async Task<int> InsertAsync(TransferDTO transferDTO)
        {
            throw new NotImplementedException();
        }
    }
}
