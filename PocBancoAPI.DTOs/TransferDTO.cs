using PocBancoAPI.Enums;

namespace PocBancoAPI.DTOs
{
    public class TransferDTO
    {
        public int IdTransfer { get; set; }
        public DateTime Date { get; set; }
        public TransferTypeEnum TransferType { get; set; }
        public int IdAcountSource { get; set; }
        public int IdAccountTarget { get; set; }
        public decimal Value { get; set; }
    }
}
