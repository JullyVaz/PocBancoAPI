using PocBancoAPI.Enums;
using System.ComponentModel.DataAnnotations;

namespace PocBancoAPI.Entities
{
    public class Transfer
    {
        [Key]
        public int IdTransfer { get; set; }
        public DateTime Date { get; set; }
        public TransferTypeEnum TransferType { get; set; }
        public int IdAcountSource { get; set; }
        public int IdAccountTarget { get; set; }
        public decimal Value { get; set; }
    }
}
