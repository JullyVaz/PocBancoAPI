using PocBancoAPI.Enums;
using System.ComponentModel.DataAnnotations;

namespace PocBancoAPI.Entities
{
    public class FinancialOperation
    {
        [Key]
        public int IdTransfer { get; set; }
        public DateTime Date { get; set; }
        public OperationTypeEnum TransferType { get; set; }
        public int IdAcountSource { get; set; }
        public int IdAccountTarget { get; set; }
        public decimal Value { get; set; }
    }
}
