using AutoMapper;
using PocBancoAPI.Business.Interfaces;
using PocBancoAPI.Data.Interfaces;
using PocBancoAPI.DTOs;
using PocBancoAPI.Entities;
using PocBancoAPI.ViewModels;
using PocBancoAPI.ViewModels.Filters;
using System.Text;


namespace PocBancoAPI.Business
{
    public class FinancialOperationBusiness : IFinancialOperationBusiness
    {
        private readonly IFinancialOperationRepository _financialOperationRepository;
        private readonly IMapper _mapper;

        public FinancialOperationBusiness(IFinancialOperationRepository financialOperationRepository, IMapper mapper)
        {
            _financialOperationRepository = financialOperationRepository;
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

        private void Check(FinancialOperationDTO financialoperationDTO)
        {
            List<string> validationErrors = new List<string>();

            if (string.IsNullOrWhiteSpace(financialoperationDTO.IdAccount.ToString()))
            {
                validationErrors.Add("O campo ' IdAccount' é obrigatório.");
            }

            if (financialoperationDTO.OperationType == Enums.OperationTypeEnum.Transfer
                && financialoperationDTO.IdAccountTarget == null
                && financialoperationDTO.IdAccountTarget == 0)
            {
                validationErrors.Add("O campo 'IdAccountTarget' é obrigatório.");
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

        public async Task<FinancialOperationDTO> UpdateAsync(FinancialOperationDTO financialoperationDTO)
        {
            if (string.IsNullOrWhiteSpace(financialoperationDTO.IdFinancialOperation.ToString()))
            {
                throw new ArgumentException("O campo 'IdFinancialOperation' é obrigatório para a atualização.");
            }

            FinancialOperation financialoperation = _mapper.Map<FinancialOperation>(financialoperationDTO);
            int result = await _financialOperationRepository.UpdateAsync(financialoperation);

            FinancialOperation updatedFinancialOperation = await _financialOperationRepository.GetByIdAsync(financialoperationDTO.IdFinancialOperation);
            return _mapper.Map<FinancialOperationDTO>(updatedFinancialOperation);
        }

    }
}
