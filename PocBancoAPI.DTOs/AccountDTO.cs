using PocBancoAPI.Enums;
using System.ComponentModel.DataAnnotations;

namespace PocBancoAPI.DTOs;

public class AccountDTO
{
    public int IdAccount { get; set; }
    public required string FirstName { get; set; }
    public required string MiddleName { get; set; }
    public required string LastName { get; set; }
    public string? Document { get; set; }
    public decimal Balance { get; set; }
    public AccountTypeEnum AccountType { get; set; }
}
