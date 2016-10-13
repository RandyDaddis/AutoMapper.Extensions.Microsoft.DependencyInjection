using Dna.NetCore.Core.BLL.Entities.Common;
using Dna.NetCore.Core.DAL.EFCore.Temp.Cocowalla;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dna.NetCore.Core.DAL.EFCore.Configuration.Common
{
    public class StateOrProvinceConfiguration : IEntityTypeConfiguration<StateOrProvince>
    {
        public void Map(EntityTypeBuilder<StateOrProvince> builder)
        {
            //// Table and Schema Names
            //ToTable("Core_StateOrProvince", "dbo");

            // EF Core
            builder.HasOne(p => p.Country).WithMany(p => p.StateOrProvinces).HasForeignKey(s => s.CountryId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(d => d.Cities).WithOne().OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(d => d.Counties).WithOne().OnDelete(DeleteBehavior.Cascade);

            // EF 6
            // parent relationships
            //builder.HasOne(a => a.Country)
            //    .WithMany(p => p.StateOrProvinces)
            //   .HasForeignKey(s => s.CountryId)
            //   .WillCascadeOnDelete(true);

            //HasMany(d => d.Cities).WithOptional().WillCascadeOnDelete(true);
            //HasMany(d => d.Counties).WithOptional().WillCascadeOnDelete(false);
            //HasMany(d => d.TimeZones).WithOptional().WillCascadeOnDelete(false);

            ////// cascade delete = true in both county and city will cause cyclical update exceptions
            ////HasMany(d => d.Counties).WithRequired(d => d.StateOrProvince).HasForeignKey(fk => fk.StateOrProvinceId).WillCascadeOnDelete(false);
            ////HasMany(d => d.Cities).WithRequired(d => d.StateOrProvince).HasForeignKey(fk => fk.StateOrProvinceId).WillCascadeOnDelete(true);
        }
    }
}
