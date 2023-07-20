using Microsoft.EntityFrameworkCore;
using PocBancoAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocBancoAPI.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) 
        {
            
        }

        public List<Account> Accounts { get; set; } = default!;
        public List<Account> Transfers { get; set; } = default!;
    }
}
