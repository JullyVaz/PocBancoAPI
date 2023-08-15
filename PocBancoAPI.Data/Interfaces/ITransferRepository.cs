using PocBancoAPI.Entities;
using PocBancoAPI.ViewModels.Filters;

namespace PocBancoAPI.Data.Interfaces
{
    public interface ITransferRepository
    {
        Task<int> InsertAsync(Transfer transfer);
        Task<int> UpdateAsync(Transfer transfer);
        Task<List<Transfer>> GetAllAsync(TransferFilter transferFilter);
        Task<Transfer> GetByIdAsync(int Id);

    }
}
