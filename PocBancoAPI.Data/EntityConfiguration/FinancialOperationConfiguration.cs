using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PocBancoAPI.Entities;

namespace PocBancoAPI.Data.EntityConfiguration
{
    internal class FinancialOperationConfiguration : IEntityTypeConfiguration<FinancialOperation>
    {

        public void Configure(EntityTypeBuilder<FinancialOperation> builder)
        {
            builder.HasKey(x => x.IdFinancialOperation);
                     builder.HasOne(_financialoperation => _financialoperation.Account)
                    .WithMany(_account => _account.FinancialOperations)
                    .HasForeignKey(_financialoperation => _financialoperation.IdAccount)
                    .OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.IdAccountSource).IsRequired(false);
            builder.Property(x => x.IdAccount).IsRequired(true);
        }
    }
}


