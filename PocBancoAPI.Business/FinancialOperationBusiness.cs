using AutoMapper;
using PocBancoAPI.Business.Interfaces;
using PocBancoAPI.Data.Interfaces;
using PocBancoAPI.DTOs;
using PocBancoAPI.Entities;
using PocBancoAPI.ViewModels.Filters;
using System.Text;


namespace PocBancoAPI.Business
{
    public class FinancialOperationBusiness : IFinancialOperationBusiness
    {
        private readonly IFinancialOperationRepository _financialOperationRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public FinancialOperationBusiness(IFinancialOperationRepository financialOperationRepository, IAccountRepository accountRepository, IMapper mapper)
        {
            _financialOperationRepository = financialOperationRepository;
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        public async Task<List<FinancialOperationDTO>> GetAllAsync(FinancialOperationFilter financialOperationFilter)
        {
            List<FinancialOperation> financialoperations = await _financialOperationRepository.GetAllAsync(financialOperationFilter);
            List<FinancialOperationDTO> financialoperationDTO = _mapper.Map<List<FinancialOperationDTO>>(financialoperations);
            return financialoperationDTO;

        }

        public async Task<FinancialOperationDTO> GetByIdAsync(int id)
        {
            FinancialOperation financialOperation = await _financialOperationRepository.GetByIdAsync(id);
            FinancialOperationDTO financialOperationDTO = _mapper.Map<FinancialOperationDTO>(financialOperation);
            return financialOperationDTO;
        }

        public async Task<int> InsertAsync(FinancialOperationDTO financialOperationDTO)
        {

            Check(financialOperationDTO);
            FinancialOperation financialoperation = _mapper.Map<FinancialOperation>(financialOperationDTO);
            int financialoperationId = await _financialOperationRepository.InsertAsync(financialoperation);
            return financialoperationId;
        }

        private async Task CheckAccountExistsAsync(int IdAccount, List<string> validationErrors)
        {
            FinancialOperation financialOperation = await _financialOperationRepository.GetByIdAsync(IdAccount);

            if (financialOperation == null)
            {
                validationErrors.Add($"A conta com o ID {IdAccount} não existe.");
            }
        }

        private async Task CheckAccountBalanceAsync(int IdAccount, decimal withdrawvalue, List<string> validationErrors)
        {
            Account account = await _accountRepository.GetByIdAsync(IdAccount);

            if (account.Balance < withdrawvalue)
            {
                validationErrors.Add($"Saldo insuficiente para realizar o saque. Saldo atual: {account.Balance}, Valor do saque: {withdrawvalue}");
            }
        }

        private void ValidateDeposit(FinancialOperationDTO financialOperationDTO, List<string> validationErrors)
        {
            if (financialOperationDTO.Value == 0)
            {
                validationErrors.Add("O valor do depósito não pode ser zero.");
            }
        }

        private void ValidateWithdrawal(FinancialOperationDTO financialOperationDTO, List<string> validationErrors)
        {
            if (financialOperationDTO.Value == 0)
            {
                validationErrors.Add("O valor do saque não pode ser zero.");
            }
        }

        private void ValidateTransfer(FinancialOperationDTO financialOperationDTO, List<string> validationErrors)
        {
            if (string.IsNullOrWhiteSpace(financialOperationDTO.IdAccountTarget.ToString()))
            {
                validationErrors.Add("O campo 'IdAccountTarget' é obrigatório.");
            }
            else
            {
                CheckAccountExistsAsync(financialOperationDTO.IdAccountTarget, validationErrors).Wait();
            }

            if (financialOperationDTO.IdAccount == financialOperationDTO.IdAccountTarget)
            {
                validationErrors.Add("A conta de origem e a conta de destino não podem ser iguais.");
            }

            if (financialOperationDTO.Value == 0)
            {
                validationErrors.Add("O valor da transferência não pode ser zero.");
            }
        }

        private void Check(FinancialOperationDTO financialOperationDTO)
        {
            List<string> validationErrors = new List<string>();

            if (string.IsNullOrWhiteSpace(financialOperationDTO.IdAccount.ToString()))
            {
                validationErrors.Add("O campo 'IdAccount' é obrigatório.");
            }
            else
            {
                // Verifica se a conta de origem existe.
                CheckAccountExistsAsync(financialOperationDTO.IdAccount, validationErrors).Wait();

                if (financialOperationDTO.OperationType == Enums.OperationTypeEnum.Deposit)
                {
                    ValidateDeposit(financialOperationDTO, validationErrors);
                }
                else if (financialOperationDTO.OperationType == Enums.OperationTypeEnum.Withdraw)
                {
                    // Verifica se o saldo é suficiente para o saque.
                    ValidateWithdrawal(financialOperationDTO, validationErrors);
                }
            }

            if (financialOperationDTO.OperationType == Enums.OperationTypeEnum.Transfer)
            {
                ValidateTransfer(financialOperationDTO, validationErrors);
            }

            if (validationErrors.Count > 0)
            {
                StringBuilder errorMessage = new StringBuilder("Erros de validação encontrados:");

                foreach (string error in validationErrors)
                {
                    errorMessage.AppendLine();
                    errorMessage.Append(error);
                }

                throw new ArgumentException(errorMessage.ToString());
            }
        }


        public async Task<FinancialOperationDTO> UpdateAsync(FinancialOperationDTO financialOperationDTO)
        {
            if (string.IsNullOrWhiteSpace(financialOperationDTO.IdFinancialOperation.ToString()))
            {
                throw new ArgumentException("O campo 'IdFinancialOperation' é obrigatório para a atualização.");
            }

            FinancialOperation financialOperation = _mapper.Map<FinancialOperation>(financialOperationDTO);
            int result = await _financialOperationRepository.UpdateAsync(financialOperation);

            FinancialOperation updatedFinancialOperation = await _financialOperationRepository.GetByIdAsync(financialOperationDTO.IdFinancialOperation);
            return _mapper.Map<FinancialOperationDTO>(updatedFinancialOperation);
        }
    }
}
