using PocBancoAPI.Data.Interfaces;
using PocBancoAPI.Entities;
using PocBancoAPI.ViewModels.Filters;

namespace PocBancoAPI.Data.Repositories;

public class TransferRepository : ITransferRepository
{
    public Task<List<Account>> GetAllAsync(TransferFilter transferFilter)
    {
        throw new NotImplementedException();
    }

    public Task<int> InsertAsync(Transfer transfer)
    {
        throw new NotImplementedException();
    }

    public Task<int> UpdateAsync(Transfer transfer)
    {
        throw new NotImplementedException();
    }

    Task<List<Transfer>> ITransferRepository.GetAllAsync(TransferFilter transferFilter)
    {
        throw new NotImplementedException();
    }
}
