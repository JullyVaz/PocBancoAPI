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
    public class TransferBusiness : ITransferBusiness
    {
        private readonly ITransferRepository _transferRepository;
        private readonly IMapper _mapper;

        public TransferBusiness(ITransferRepository transferRepository, IMapper mapper)
        {
            _transferRepository = transferRepository;
            _mapper = mapper;
        }

        public Task<List<TransferDTO>> GetAllAsync(TransferFilter transferFilter)
        {
            throw new NotImplementedException();
        }

        public Task<TransferDTO> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> InsertAsync(TransferDTO transferDTO)

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

           Transfer transfer = _mapper.Map<Transfer>(transferDTO);
            int transferId = await _transferRepository.InsertAsync(transfer);
            return transferId;
        }

        public async Task<TransferDTO> UpdateAsync(TransferDTO transferDTO)
        {
            if (string.IsNullOrWhiteSpace(transferDTO.IdTransfer.ToString()))
            {
                throw new ArgumentException("O campo 'IdTransfer' é obrigatório para a atualização.");
            }

            Transfer transfer = _mapper.Map<Transfer>(transferDTO);
            int result = await _transferRepository.UpdateAsync(transfer);

            Transfer updatedTransfer = await _transferRepository.GetByIdAsync(transferDTO.IdTransfer);
            return _mapper.Map<TransferDTO>(updatedTransfer);
        }

        Task<ServiceResponseViewModel<List<TransferDTO>>> ITransferBusiness.GetAllAsync(TransferFilter transferFilter)
        {
            throw new NotImplementedException();
        }
    }
}
