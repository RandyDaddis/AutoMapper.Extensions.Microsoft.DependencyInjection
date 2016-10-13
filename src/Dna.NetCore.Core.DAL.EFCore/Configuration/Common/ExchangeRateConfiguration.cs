using Dna.NetCore.Core.BLL.Entities.Common;
using Dna.NetCore.Core.DAL.EFCore.Temp.Cocowalla;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dna.NetCore.Core.DAL.EFCore.Configuration.Common
{
    public class ExchangeRateConfiguration : IEntityTypeConfiguration<ExchangeRate>
    {

        public void Map(EntityTypeBuilder<ExchangeRate> builder)
        {
            //b.ToTable("Core_ExchangeRate", "dbo");

            // EF Core
            builder.HasOne(a => a.Currency).WithMany().HasForeignKey(f => f.CurrencyId).OnDelete(DeleteBehavior.Cascade);
            builder.Property(p => p.Rate).HasAnnotation("Precision", "(18, 8)").IsRequired();

            // EF 6
            //HasRequired(a => a.Currency).WithMany().HasForeignKey(f => f.CurrencyId).WillCascadeOnDelete(true);
            //b.Property(d => d.Rate).HasPrecision(18, 8).IsRequired();
        }
    }
}
