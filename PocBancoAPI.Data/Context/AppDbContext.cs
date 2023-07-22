using Microsoft.EntityFrameworkCore;
using PocBancoAPI.Entities;

namespace PocBancoAPI.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) 
        {
            
        }

        public DbSet<Account> Accounts { get; set; } = default!;
        public DbSet<Transfer> Transfers { get; set; } = default!;
    }
}
