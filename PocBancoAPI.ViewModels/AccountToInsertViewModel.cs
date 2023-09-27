﻿using PocBancoAPI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocBancoAPI.ViewModels
{
    public class AccountToInsertViewModel
    {
        public int AccountId { get; set; }
        public int UserId { get; set; }
        public AccountTypeEnum AccountType { get; set; }

    }
}
