using PocBancoAPI.DTOs;
using PocBancoAPI.ViewModels.Filters;

namespace PocBancoAPI.Business.Interfaces
{
    public interface IAccountBusiness
    {
        Task<int> InsertAsync(AccountDTO accountDTO);
        Task<AccountDTO> UpdateAsync(AccountDTO accountDTO);
        Task<AccountDTO> GetByIdAsync(int id);
        Task<List<AccountDTO>> GetAllAsync(AccountFilter accountFilter);
    }
}
