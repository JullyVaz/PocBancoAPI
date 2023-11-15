namespace PocBancoAPI.ViewModels
{
    public class FinancialOperationTransferViewModel
    {
        public int IdAccount { get; set; }
        public int? IdAccountSource { get; set; }
        public decimal Value { get; set; }
    }
}
