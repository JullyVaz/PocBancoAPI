using AutoMapper;
using PocBancoAPI.Business.Interfaces;
using PocBancoAPI.Data.Interfaces;
using PocBancoAPI.DTOs;
using PocBancoAPI.Entities;
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

        public async Task<List<TransferDTO>> GetAllAsync(TransferFilter transferFilter)
        {
            List<Transfer> transfer = await _transferRepository.GetAllAsync(transferFilter);
            List<TransferDTO> transferDTO = _mapper.Map<List<TransferDTO>>(transfer);
            return transferDTO;

        }

        public async Task<TransferDTO> GetByIdAsync(int id)
        {
            Transfer transfer = await _transferRepository.GetByIdAsync(id);
            TransferDTO transferDTO = _mapper.Map<TransferDTO>(transfer);
            return transferDTO;

        }

        public async Task<int> InsertAsync(TransferDTO transferDTO)
        {
            Check(transferDTO);
            Transfer transfer = _mapper.Map<Transfer>(transferDTO);
            int transferId = await _transferRepository.InsertAsync(transfer);
            return transferId;
        }

        private void Check(TransferDTO transferDTO)
        {
            List<string> validationErrors = new List<string>();

            if (string.IsNullOrWhiteSpace(transferDTO.IdAccountSource.ToString()))
            {
                validationErrors.Add("O campo 'IdAccountSource' é obrigatório.");
            }

            if (string.IsNullOrWhiteSpace(transferDTO.IdAccountTarget.ToString()))
            {
                validationErrors.Add("O campo ' IdAccountTarget' é obrigatório.");
            }

            if (string.IsNullOrWhiteSpace(transferDTO.Value.ToString()))
            {
                validationErrors.Add("O campo 'Value' é obrigatório.");
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

        public async Task<TransferDTO> UpdateAsync(TransferDTO transferDTO)
        {
            if (string.IsNullOrWhiteSpace(transferDTO.IdTransfer.ToString()))
            {
                throw new ArgumentException("O campo 'IdString' é obrigatório para a atualização.");
            }

            Check(transferDTO);
            Transfer transfer = _mapper.Map<Transfer>(transferDTO);
            int result = await _transferRepository.UpdateAsync(transfer);

            Transfer updatedTransfer = await _transferRepository.GetByIdAsync(transferDTO.IdTransfer);
            return _mapper.Map<TransferDTO>(updatedTransfer);
        }
    }
}

