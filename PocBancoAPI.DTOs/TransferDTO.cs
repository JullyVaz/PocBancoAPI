using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocBancoAPI.DTOs
{
    public class TransferDTO
    {
        public int IdTransfer{ get; set; }
        public DateTime Data { get; set; }

        //public EnumTipoTransacao TipoTransacao { get; set; }
        public int IdContaOrigem { get; set; }
        public int IdContaDestino { get; set; }
        public decimal Valor { get; set; }
    }
}
