namespace PocBancoAPI.ViewModels
{
    public class TransferViewModel
    {
        public int IdTransfer { get; set; }
        public DateTime Data { get; set; }

        //public EnumTipoTransacao TipoTransacao { get; set; }
        public int IdContaOrigem { get; set; }
        public int IdContaDestino { get; set; }
        public decimal Valor { get; set; }
    }
}
