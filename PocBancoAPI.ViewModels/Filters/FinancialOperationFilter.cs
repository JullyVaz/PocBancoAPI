using PocBancoAPI.Enums;

namespace PocBancoAPI.ViewModels.Filters
{
    public class FinancialOperationFilter
    {
        public int IdFinancialOperation{ get; set; }
        public OperationTypeEnum OperationType { get; set; }
        public int IdAccountSource { get; set; }
        public int IdAccountTarget { get; set; }
        public DateTime? StartTransferDate { get; set; }
        public DateTime? EndTransferDate { get; set; }

    }
}
