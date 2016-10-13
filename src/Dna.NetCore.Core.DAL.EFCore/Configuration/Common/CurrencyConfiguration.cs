using Dna.NetCore.Core.BLL.Entities.Common;
using Dna.NetCore.Core.DAL.EFCore.Temp.Cocowalla;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dna.NetCore.Core.DAL.EFCore.Configuration.Common
{
    public class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
    {

        public void Map(EntityTypeBuilder<Currency> builder)
        {
            //b.ToTable("Core_Currency", "dbo");

            // EF Core
            builder.Property(p => p.Rate).HasAnnotation("Precision", "(18, 8)").IsRequired();

            // EF 6
            //b.Property(d => d.Rate).HasPrecision(18, 8).IsRequired();
        }
    }
}
