using PocBancoAPI.Entities;
using PocBancoAPI.Enums;
using System;

namespace PocBancoAPI.DTOs
{
    public class FinancialOperationDTO
    {
        public int IdFinancialOperation { get; set; }
        public int IdAccount { get; set; }
        public Account Account { get; set; }
        public DateTime Date { get; set; }
        public OperationTypeEnum OperationType { get; set; }
        public int? IdAccountSource { get; set; }
        public int? IdAccountTarget { get; set; }
        public decimal Value { get; set; }

    }
}
