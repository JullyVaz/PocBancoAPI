using PocBancoAPI.Enums;
using System.ComponentModel.DataAnnotations;

namespace PocBancoAPI.Entities
{
    public class FinancialOperation
    {
        public int IdFinancialOperation { get; set; }
        public int IdAccount { get; set; }
        public Account Account { get; set; }
        public DateTime Date { get; set; }
        public OperationTypeEnum OperationType { get; set; }
        public int? IdAccountTarget { get; set; }
        public decimal Value { get; set; }
    }
}
