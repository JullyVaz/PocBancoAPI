using PocBancoAPI.Enums;

namespace PocBancoAPI.ViewModels
{
    public class TransferViewModel
    {
        public int IdTransfer { get; set; }
        public DateTime Date { get; set; }
        public TransferTypeEnum TransferType { get; set; }
        public required string IdAccountSource { get; set; }
        public required string IdAccountTarget { get; set; }
        public decimal Value { get; set; }
    }
}
