using PocBancoAPI.DTOs;

namespace PocBancoAPI.Business.Interfaces
{
    public interface IAccountBusiness
    {
        Task<int> InsertAsync(AccountDTO accountDTO);
    }
}
