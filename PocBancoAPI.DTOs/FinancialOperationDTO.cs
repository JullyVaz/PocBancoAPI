using PocBancoAPI.Enums;

namespace PocBancoAPI.DTOs
{
    public class FinancialOperationDTO
    {
         public int IdTransfer { get; set; }
        public System.DateTime Date { get; set; }
        public OperationTypeEnum TransferType { get; set; }
        public int IdAccountSource { get; set; }
        public int IdAccountTarget { get; set; }
        public decimal Value { get; set; }
      
    }
}
