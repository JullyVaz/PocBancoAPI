using PocBancoAPI.Business.Interfaces;
using PocBancoAPI.Data.Interfaces;
using PocBancoAPI.Data.Repositories;
using PocBancoAPI.DTOs;

namespace PocBancoAPI.Business;
public class AccountBusiness : IAccountBusiness
{
    private readonly IAccountRepository _accountRepository;
   
    public AccountBusiness(IAccountRepository accountRepository) 
    {
        _accountRepository = accountRepository;
        
    }
    public Task<int> InsertAsync(AccountDTO accountDTO)
    {
        throw new NotImplementedException();
    }
}
