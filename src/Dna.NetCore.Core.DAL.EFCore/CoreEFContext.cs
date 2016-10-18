using Dna.NetCore.Core.BLL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;
using Dna.NetCore.Core.DAL.EFCore.Configuration.Temporary;
using Dna.NetCore.Core.BLL.Entities.Common;
using Dna.NetCore.Core.BLL.Entities.Localization;

namespace Dna.NetCore.Core.DAL.EFCore
{
    public class CoreEFContext : DbContext
    {
        #region ctor

        public CoreEFContext()
        {
        }

        #endregion

        #region DbSets

        // Common
        public DbSet<AddressType> AddressTypes { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<County> Counties { get; set; }
        public DbSet<CountyCity> CountiesCities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<ExchangeRate> ExchangeRates { get; set; }
        public DbSet<MimeTypeGroup> MimeTypeGroups { get; set; }
        public DbSet<MimeType> MimeTypes { get; set; }
        public DbSet<PhoneNumberType> PhoneNumberTypes { get; set; }
        public DbSet<StateOrProvince> StateOrProvinces { get; set; }
        public DbSet<SystemSetting> SystemSettings { get; set; }
        public DbSet<Dna.NetCore.Core.BLL.Entities.Common.TimeZone> TimeZones { get; set; }
        // Localization
        public DbSet<Language> Languages { get; set; }
        public DbSet<Locale> Locales { get; set; }

        #endregion

        #region Methods

        public virtual void Commit()
        {
            SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Interface that all of our Entity maps implement
            var mappingInterface = typeof(IEntityTypeConfiguration<>);
            // Types that do entity mapping
            var mappingTypes = typeof(CoreEFContext).GetTypeInfo().Assembly.GetTypes()
                                                          .Where(x => x.GetInterfaces().Any(y => y.GetTypeInfo().IsGenericType && y.GetGenericTypeDefinition() == mappingInterface));
            // Get the generic Entity method of the ModelBuilder type
            var entityMethod = typeof(ModelBuilder).GetMethods().Single(x => x.Name == "Entity" &&
                                                                        x.IsGenericMethod && x.ReturnType.Name == "EntityTypeBuilder`1");
            foreach (var mappingType in mappingTypes)
            {
                // Get the type of entity to be mapped
                var genericTypeArg = mappingType.GetInterfaces().Single().GenericTypeArguments.Single();
                // Get the method builder.Entity<TEntity>
                var genericEntityMethod = entityMethod.MakeGenericMethod(genericTypeArg);
                // Invoke builder.Entity<TEntity> to get a builder for the entity to be mapped
                var entityBuilder = genericEntityMethod.Invoke(builder, null);
                // Create the mapping type and do the mapping
                var mapper = Activator.CreateInstance(mappingType);
                mapper.GetType().GetMethod("Map").Invoke(mapper, new[] { entityBuilder });
            }

        }
        #endregion
    }
}
