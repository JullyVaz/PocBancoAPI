using PocBancoAPI.Enums;

namespace PocBancoAPI.Entities;

public class Account
{
    public int IdAccount { get; set; }
    public int IdUser { get; set; }
    public User User { get; set; }
    public decimal Balance { get; set; }
    public AccountTypeEnum AccountType { get; set; }
    public virtual List<FinancialOperation> FinancialOperations { get; set; }

}
