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

        public Task<List<FinancialOperationDTO>> GetAllAsync(FinancialOperationFilter transferFilter)
        {
            throw new NotImplementedException();
        }

        public async Task<FinancialOperationDTO> GetByIdAsync(int id)
        {
           FinancialOperation financialOperation = await _financialOperationRepository.GetByIdAsync(id);
            FinancialOperationDTO financialOperationDTO = _mapper.Map<FinancialOperationDTO>(financialOperation);
            return financialOperationDTO;
        }

        public async Task<int> InsertAsync(FinancialOperationDTO transferDTO)

        //if (string.IsNullOrWhiteSpace(transferDTO.TransferTypeEnum))
        //{
        //    validationErrors.Add("O campo 'TransferTypeEnum' é obrigatório.");
        //}
        {
            List<string> validationErrors = new List<string>();

            if (string.IsNullOrWhiteSpace(transferDTO.IdAccountSource.ToString()))
            {
                validationErrors.Add("O campo ' IdAccountSource' é obrigatório.");
            }

            if (string.IsNullOrWhiteSpace(transferDTO.IdAccountTarget.ToString()))
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

           FinancialOperation transfer = _mapper.Map<FinancialOperation>(transferDTO);
            int transferId = await _financialOperationRepository.InsertAsync(transfer);
            return transferId;
        }

        public async Task<FinancialOperationDTO> UpdateAsync(FinancialOperationDTO transferDTO)
        {
            if (string.IsNullOrWhiteSpace(transferDTO.IdTransfer.ToString()))
            {
                throw new ArgumentException("O campo 'IdTransfer' é obrigatório para a atualização.");
            }

            FinancialOperation transfer = _mapper.Map<FinancialOperation>(transferDTO);
            int result = await _financialOperationRepository.UpdateAsync(transfer);

            FinancialOperation updatedTransfer = await _financialOperationRepository.GetByIdAsync(transferDTO.IdTransfer);
            return _mapper.Map<FinancialOperationDTO>(updatedTransfer);
        }

        Task<ServiceResponseViewModel<List<FinancialOperationDTO>>> IFinancialOperationBusiness.GetAllAsync(FinancialOperationFilter transferFilter)
        {
            throw new NotImplementedException();
        }
    }
}
