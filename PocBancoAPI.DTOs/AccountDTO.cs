using PocBancoAPI.Entities;
using PocBancoAPI.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PocBancoAPI.DTOs;

public class AccountDTO
{
    public int IdAccount { get; set; }
    public int IdUser { get; set; }
    public UserDTO UserDTO { get; set; }
    public decimal Balance { get; set; }
    public AccountTypeEnum AccountType { get; set; }
    public List<FinancialOperationDTO> FinancialOperationDTOs { get; set; }
}
