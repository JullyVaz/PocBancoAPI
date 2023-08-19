namespace PocBancoAPI.ViewModels.Filters
{
    public class TransferFilter
    {
        public int? IdTransfer { get; set; }
        //public int? AccountId { get; set; }
        public DateTime? StartTransferDate { get; set; }
        public DateTime? EndTransferDate { get; set; }

    }
}
