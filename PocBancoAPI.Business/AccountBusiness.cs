using AutoMapper;
using PocBancoAPI.Business.Interfaces;
using PocBancoAPI.Data.Interfaces;
using PocBancoAPI.DTOs;
using PocBancoAPI.Entities;

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

    public async Task<int> InsertAsync(AccountDTO accountDTO)
    {
        Account account = _mapper.Map<Account>(accountDTO);
        int accountId = await _accountRepository.InsertAsync(account);
        return accountId;

    }
}
