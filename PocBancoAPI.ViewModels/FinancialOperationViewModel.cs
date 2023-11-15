using PocBancoAPI.Enums;

namespace PocBancoAPI.ViewModels
{
    public class FinancialOperationViewModel
    {
        public int IdFinancialOperation { get; set; }
        public DateTime Date { get; set; }
        public OperationTypeEnum OperationType { get; set; }
        public int IdAccount { get; set; }
        public int? IdAccountSource { get; set; }
        public decimal Value { get; set; }
    }
}
