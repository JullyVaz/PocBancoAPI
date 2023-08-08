using AutoMapper;
using PocBancoAPI.Business.Interfaces;
using PocBancoAPI.Data.Interfaces;
using PocBancoAPI.DTOs;
using PocBancoAPI.Entities;
using PocBancoAPI.ViewModels.Filters;

namespace PocBancoAPI.Business;
public class AccountBusiness : IAccountBusiness
{
    private readonly IAccountRepository _accountRepository;
    private readonly IMapper _mapper;

    public AccountBusiness(IAccountRepository accountRepository, IMapper mapper)
    {
        _accountRepository = accountRepository;
        _mapper = mapper;
    }

    public Task<List<AccountDTO>> GetAllAsync(AccountFilter accountFilter)
    {
        throw new NotImplementedException();
    }

    public Task<AccountDTO> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<int> InsertAsync(AccountDTO accountDTO)
    {
        Account account = _mapper.Map<Account>(accountDTO);
        int accountId = await _accountRepository.InsertAsync(account);
        return accountId;

    

    }

    public async Task<AccountDTO> UpdateAsync(AccountDTO accountDTO)
    {
        Account account =  _mapper.Map<Account>(accountDTO);
        int result = await _accountRepository.UpdateAsync(account);

        Account updatedAccount = await _accountRepository.GetByIdAsync(accountDTO.IdAccount);
        return _mapper.Map<AccountDTO>(updatedAccount);
    }
}
