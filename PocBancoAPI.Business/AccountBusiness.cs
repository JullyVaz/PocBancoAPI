using PocBancoAPI.Business.Interfaces;
using PocBancoAPI.DTOs;

namespace PocBancoAPI.Business;
public class AccountBusiness : IAccountBusiness
{
    public AccountBusiness()
    {
            
    }
    public Task<int> InsertAsync(AccountDTO accountDTO)
    {
        throw new NotImplementedException();
    }
}
