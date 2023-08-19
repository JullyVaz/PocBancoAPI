using PocBancoAPI.Enums;

namespace PocBancoAPI.DTOs
{
    public class TransferDTO
    {
        public int IdTransfer { get; set; }
        public System.DateTime Date { get; set; }
        public TransferTypeEnum TransferType { get; set; }
        public required string IdAccountSource { get; set; }
        public required string IdAccountTarget { get; set; }
        public decimal Value { get; set; }

    }
}
