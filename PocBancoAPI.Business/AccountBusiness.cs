using AutoMapper;
using PocBancoAPI.Business.Interfaces;
using PocBancoAPI.Data.Interfaces;
using PocBancoAPI.Data.Repositories;
using PocBancoAPI.DTOs;
using PocBancoAPI.Entities;
using PocBancoAPI.ViewModels.Filters;
using System.Text;

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

    public async Task<List<AccountDTO>> GetAllAsync(AccountFilter accountFilter)
    {
        List<Account> accounts = await _accountRepository.GetAllAsync(accountFilter);
        List<AccountDTO> accountDTO = _mapper.Map<List<AccountDTO>>(accounts);
        return accountDTO;
    }

    public async Task<AccountDTO> GetByIdAsync(int id)
    {
        Account account = await _accountRepository.GetByIdAsync(id);
        AccountDTO accountDTO = _mapper.Map<AccountDTO>(account);
        return accountDTO;
    }

    public async Task<int> InsertAsync(AccountDTO accountDTO)
    {
        Validate(accountDTO);
        Account account = _mapper.Map<Account>(accountDTO);
        int accountId = await _accountRepository.InsertAsync(account);
        return accountId;
    }

    private void Validate(AccountDTO accountDTO)
    {
        List<string> validationErrors = new List<string>();

        if (string.IsNullOrWhiteSpace(accountDTO.FirstName))
        {
            validationErrors.Add("O campo 'FirstName' é obrigatório.");
        }

        if (string.IsNullOrWhiteSpace(accountDTO.MiddleName))
        {
            validationErrors.Add("O campo 'MiddleName' é obrigatório.");
        }

        if (string.IsNullOrWhiteSpace(accountDTO.LastName))
        {
            validationErrors.Add("O campo 'LastName' é obrigatório.");
        }

        if (validationErrors.Count > 0)
        {
            StringBuilder errorMessage = new StringBuilder("Erros de validação encontrados:");

            foreach (string error in validationErrors)
            {
                errorMessage.AppendLine();
                errorMessage.AppendLine(error);
            }

            throw new ArgumentException(errorMessage.ToString());
        }

    }

    public async Task<AccountDTO> UpdateAsync(AccountDTO accountDTO)
    {
        if (string.IsNullOrWhiteSpace(accountDTO.IdAccount.ToString()))
        {
            throw new ArgumentException("O campo 'IdAccount' é obrigatório para a atualização.");
        }

        Validate(accountDTO);
        Account account = _mapper.Map<Account>(accountDTO);
        int result = await _accountRepository.UpdateAsync(account);

        Account updatedAccount = await _accountRepository.GetByIdAsync(accountDTO.IdAccount);
        return _mapper.Map<AccountDTO>(updatedAccount);
    }
}
