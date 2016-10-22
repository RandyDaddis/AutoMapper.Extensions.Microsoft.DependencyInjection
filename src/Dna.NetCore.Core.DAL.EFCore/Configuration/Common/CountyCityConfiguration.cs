using Dna.NetCore.Core.BLL.Entities.Common;
using Dna.NetCore.Core.DAL.EFCore.Configuration.Temporary.Cocowalla;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dna.NetCore.Core.DAL.EFCore.Configuration.Common
{
    public class CountyCityConfiguration : IEntityTypeConfiguration<CountyCity>
    {
        public void Map(EntityTypeBuilder<CountyCity> builder)
        {
            //// Table and Schema Names
            //ToTable("Core_CountyCity", "dbo");

            // EF Core
            builder.HasKey(p => new { p.CountyId, p.CityId });
            builder.HasOne(pt => pt.County)
                   .WithMany(p => p.CountiesCities)
                   .HasForeignKey(pt => pt.CountyId);
            builder.HasOne(pt => pt.City)
                   .WithMany(t => t.CountiesCities)
                   .HasForeignKey(pt => pt.CityId);


            // EF 6
            //HasKey(p => new { p.CountyId, p.CityId });   // composite primary key
            //HasRequired(a => a.County)
            //    .WithMany(c => c.CountiesCities)
            //   .HasForeignKey(fk => fk.CountyId)
            //   .WillCascadeOnDelete(false);
            //HasRequired(a => a.City)
            //    .WithMany(c => c.CountiesCities)
            //   .HasForeignKey(fk => fk.CityId)
            //   .WillCascadeOnDelete(false);

            // TODO: handle orphans when last asociation is deleted
        }
    }
}