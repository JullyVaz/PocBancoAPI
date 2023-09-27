using PocBancoAPI.Entities;
using PocBancoAPI.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PocBancoAPI.DTOs;

public class AccountDTO
{
    public int IdAccount { get; set; }
    public int IdUser { get; set; }
    public virtual User User { get; set; }
    public decimal Balance { get; set; }
    public AccountTypeEnum AccountType { get; set; }
    public virtual List<FinancialOperation> FinancialOperations { get; set; }
}
