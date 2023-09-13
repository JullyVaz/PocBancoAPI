using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PocBancoAPI.Entities;

namespace PocBancoAPI.Data.EntityConfiguration
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(x => x.IdAccount);
            builder.HasOne(_account => _account.User)
                .WithMany(_user => _user.Accounts)
                .HasForeignKey(_account => _account.IdUser)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
