using Microsoft.EntityFrameworkCore;
using PocBancoAPI.Entities;

namespace PocBancoAPI.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }

        public DbSet<User> User { get; set; }
        public DbSet<Account> Accounts { get; set; } = default!;
        public DbSet<FinancialOperation> FinancialOperations { get; set; } = default!;
    }
}
