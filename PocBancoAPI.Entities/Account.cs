using PocBancoAPI.Enums;

namespace PocBancoAPI.Entities;

public class Account
{
    public int IdAccount { get; set; }
    public int IdUser { get; set; }
    public User User { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public string Document { get; set; }
    public decimal Balance { get; set; }
    public AccountTypeEnum AccountType { get; set; }
    public virtual List<FinancialOperation> FinancialOperations { get; set; }
 
}
