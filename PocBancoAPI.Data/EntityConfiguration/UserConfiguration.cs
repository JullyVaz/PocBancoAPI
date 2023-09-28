using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PocBancoAPI.Entities;

namespace PocBancoAPI.Data.EntityConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(User => User.IdUser);
            builder.Property(User => User.FirstName).IsRequired(false);
            builder.Property(User => User.MiddleName).IsRequired(false);
            builder.Property(User => User.LastName).IsRequired(false);
            builder.Property(User => User.Document).IsRequired(false);

        }
    }
}
