﻿using PocBancoAPI.Shared.Enums;

namespace PocBancoAPI.DTOs;

public class AccountDTO
{
    public int IdAccount { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public string Document { get; set; }
    public decimal Balance { get; set; }
    public AccountTypeEnum AccountType { get; set; }
}
