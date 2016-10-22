using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Dna.NetCore.Core.DAL.EFCore;

namespace Dna.NetCore.Core.DAL.EFCore.Migrations
{
    [DbContext(typeof(CoreEFContext))]
    partial class CoreEFContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Dna.NetCore.Core.BLL.Entities.Common.AddressType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddedBy");

                    b.Property<DateTime>("AddedDate");

                    b.Property<string>("ChangedBy");

                    b.Property<DateTime?>("ChangedDate");

                    b.Property<string>("DisplayName");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("SystemName");

                    b.HasKey("Id");

                    b.ToTable("Core_AddressType","dbo");
                });

            modelBuilder.Entity("Dna.NetCore.Core.BLL.Entities.Common.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddedBy");

                    b.Property<DateTime>("AddedDate");

                    b.Property<string>("ChangedBy");

                    b.Property<DateTime?>("ChangedDate");

                    b.Property<string>("DisplayName");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<int>("StateOrProvinceId");

                    b.HasKey("Id");

                    b.HasIndex("StateOrProvinceId");

                    b.ToTable("Core_City","dbo");
                });

            modelBuilder.Entity("Dna.NetCore.Core.BLL.Entities.Common.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Abbreviation");

                    b.Property<string>("AddedBy");

                    b.Property<DateTime>("AddedDate");

                    b.Property<string>("ChangedBy");

                    b.Property<DateTime?>("ChangedDate");

                    b.Property<int?>("CurrencyId");

                    b.Property<string>("DisplayName");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<bool>("IsShippingAllowed");

                    b.Property<bool>("IsVatEnabled");

                    b.Property<int?>("LocaleId");

                    b.Property<string>("PhoneNumberCountryCode");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.ToTable("Core_Country","dbo");
                });

            modelBuilder.Entity("Dna.NetCore.Core.BLL.Entities.Common.County", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddedBy");

                    b.Property<DateTime>("AddedDate");

                    b.Property<string>("ChangedBy");

                    b.Property<DateTime?>("ChangedDate");

                    b.Property<string>("DisplayName");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<int>("StateOrProvinceId");

                    b.HasKey("Id");

                    b.HasIndex("StateOrProvinceId");

                    b.ToTable("Core_County","dbo");
                });

            modelBuilder.Entity("Dna.NetCore.Core.BLL.Entities.Common.CountyCity", b =>
                {
                    b.Property<int>("CountyId");

                    b.Property<int>("CityId");

                    b.Property<string>("AddedBy");

                    b.Property<DateTime>("AddedDate");

                    b.Property<string>("ChangedBy");

                    b.Property<DateTime?>("ChangedDate");

                    b.Property<bool>("IsDeleted");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("CountyId", "CityId");

                    b.HasIndex("CityId");

                    b.HasIndex("CountyId");

                    b.ToTable("Core_CountyCity","dbo");
                });

            modelBuilder.Entity("Dna.NetCore.Core.BLL.Entities.Common.Currency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddedBy");

                    b.Property<DateTime>("AddedDate");

                    b.Property<string>("ChangedBy");

                    b.Property<DateTime?>("ChangedDate");

                    b.Property<string>("Code");

                    b.Property<string>("DisplayName");

                    b.Property<string>("Format");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<bool>("IsPublished");

                    b.Property<string>("Locality");

                    b.Property<decimal>("Rate")
                        .HasAnnotation("Precision", "(18, 8)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.ToTable("Core_Currency","dbo");
                });

            modelBuilder.Entity("Dna.NetCore.Core.BLL.Entities.Common.ExchangeRate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddedBy");

                    b.Property<DateTime>("AddedDate");

                    b.Property<string>("ChangedBy");

                    b.Property<DateTime?>("ChangedDate");

                    b.Property<int>("CurrencyId");

                    b.Property<string>("DisplayName");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<decimal>("Rate")
                        .HasAnnotation("Precision", "(18, 8)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.HasIndex("CurrencyId");

                    b.ToTable("Core_ExchangeRate","dbo");
                });

            modelBuilder.Entity("Dna.NetCore.Core.BLL.Entities.Common.MimeType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddedBy");

                    b.Property<DateTime>("AddedDate");

                    b.Property<string>("ChangedBy");

                    b.Property<DateTime?>("ChangedDate");

                    b.Property<string>("ContentType");

                    b.Property<string>("FileExtension");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<int>("MimeTypeGroupId");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.HasIndex("MimeTypeGroupId");

                    b.ToTable("Core_MimeType","dbo");
                });

            modelBuilder.Entity("Dna.NetCore.Core.BLL.Entities.Common.MimeTypeGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddedBy");

                    b.Property<DateTime>("AddedDate");

                    b.Property<string>("ChangedBy");

                    b.Property<DateTime?>("ChangedDate");

                    b.Property<string>("DisplayName");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("SystemName");

                    b.HasKey("Id");

                    b.ToTable("Core_MimeTypeGroup","dbo");
                });

            modelBuilder.Entity("Dna.NetCore.Core.BLL.Entities.Common.PhoneNumberType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddedBy");

                    b.Property<DateTime>("AddedDate");

                    b.Property<string>("ChangedBy");

                    b.Property<DateTime?>("ChangedDate");

                    b.Property<string>("DisplayName");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("SystemName");

                    b.HasKey("Id");

                    b.ToTable("Core_PhoneNumberType","dbo");
                });

            modelBuilder.Entity("Dna.NetCore.Core.BLL.Entities.Common.StateOrProvince", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Abbreviation");

                    b.Property<string>("AddedBy");

                    b.Property<DateTime>("AddedDate");

                    b.Property<string>("ChangedBy");

                    b.Property<DateTime?>("ChangedDate");

                    b.Property<int>("CountryId");

                    b.Property<string>("DisplayName");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<bool>("IsShippingAllowed");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<decimal>("SalesTaxRate");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Core_StateOrProvince","dbo");
                });

            modelBuilder.Entity("Dna.NetCore.Core.BLL.Entities.Common.SystemSetting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddedBy");

                    b.Property<DateTime>("AddedDate");

                    b.Property<bool>("BooleanValue");

                    b.Property<string>("ChangedBy");

                    b.Property<DateTime?>("ChangedDate");

                    b.Property<decimal>("DecimalValue");

                    b.Property<string>("Description");

                    b.Property<string>("DisplayName");

                    b.Property<int>("IntegerValue");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<int>("PluginId");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("StringValue");

                    b.Property<string>("SystemName");

                    b.HasKey("Id");

                    b.ToTable("Core_SystemSetting","dbo");
                });

            modelBuilder.Entity("Dna.NetCore.Core.BLL.Entities.Common.TimeZone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddedBy");

                    b.Property<DateTime>("AddedDate");

                    b.Property<string>("ChangedBy");

                    b.Property<DateTime?>("ChangedDate");

                    b.Property<string>("DaylightName");

                    b.Property<string>("DisplayName");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("StandardName");

                    b.Property<int?>("StateOrProvinceId");

                    b.Property<bool>("SupportsDaylightSavingTime");

                    b.Property<string>("TimeZoneInfoId");

                    b.HasKey("Id");

                    b.HasIndex("StateOrProvinceId");

                    b.ToTable("Core_TimeZone","dbo");
                });

            modelBuilder.Entity("Dna.NetCore.Core.BLL.Entities.Localization.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Abbreviation");

                    b.Property<string>("Added");

                    b.Property<string>("AddedBy");

                    b.Property<DateTime>("AddedDate");

                    b.Property<string>("ChangedBy");

                    b.Property<DateTime?>("ChangedDate");

                    b.Property<string>("Comments");

                    b.Property<string>("Depreciated");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Macrolanguage");

                    b.Property<string>("Name");

                    b.Property<string>("Notes");

                    b.Property<string>("PreferredValue");

                    b.Property<string>("Prefix");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("Scope");

                    b.Property<string>("Subtag");

                    b.Property<string>("SuppressScript");

                    b.HasKey("Id");

                    b.ToTable("Core_Language","dbo");
                });

            modelBuilder.Entity("Dna.NetCore.Core.BLL.Entities.Localization.Locale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddedBy");

                    b.Property<DateTime>("AddedDate");

                    b.Property<string>("ChangedBy");

                    b.Property<DateTime?>("ChangedDate");

                    b.Property<int>("CodePage");

                    b.Property<string>("DisplayName");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<int>("LCIDDecimal");

                    b.Property<int>("LCIDHexadecimal");

                    b.Property<string>("LCIDString");

                    b.Property<string>("LanguageCode");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.ToTable("Core_Locale","dbo");
                });

            modelBuilder.Entity("Dna.NetCore.Core.BLL.Entities.Plugins.Plugin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddedBy");

                    b.Property<DateTime>("AddedDate");

                    b.Property<int>("AssemblyLoadOrder");

                    b.Property<string>("ChangedBy");

                    b.Property<DateTime?>("ChangedDate");

                    b.Property<string>("DisplayName");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Notes");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("SystemName");

                    b.HasKey("Id");

                    b.ToTable("Core_Plugin","dbo");
                });

            modelBuilder.Entity("Dna.NetCore.Core.BLL.Entities.Common.City", b =>
                {
                    b.HasOne("Dna.NetCore.Core.BLL.Entities.Common.StateOrProvince")
                        .WithMany("Cities")
                        .HasForeignKey("StateOrProvinceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Dna.NetCore.Core.BLL.Entities.Common.County", b =>
                {
                    b.HasOne("Dna.NetCore.Core.BLL.Entities.Common.StateOrProvince")
                        .WithMany("Counties")
                        .HasForeignKey("StateOrProvinceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Dna.NetCore.Core.BLL.Entities.Common.CountyCity", b =>
                {
                    b.HasOne("Dna.NetCore.Core.BLL.Entities.Common.City", "City")
                        .WithMany("CountiesCities")
                        .HasForeignKey("CityId");

                    b.HasOne("Dna.NetCore.Core.BLL.Entities.Common.County", "County")
                        .WithMany("CountiesCities")
                        .HasForeignKey("CountyId");
                });

            modelBuilder.Entity("Dna.NetCore.Core.BLL.Entities.Common.ExchangeRate", b =>
                {
                    b.HasOne("Dna.NetCore.Core.BLL.Entities.Common.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Dna.NetCore.Core.BLL.Entities.Common.MimeType", b =>
                {
                    b.HasOne("Dna.NetCore.Core.BLL.Entities.Common.MimeTypeGroup", "MimeTypeGroup")
                        .WithMany("MimeTypes")
                        .HasForeignKey("MimeTypeGroupId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Dna.NetCore.Core.BLL.Entities.Common.StateOrProvince", b =>
                {
                    b.HasOne("Dna.NetCore.Core.BLL.Entities.Common.Country", "Country")
                        .WithMany("StateOrProvinces")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Dna.NetCore.Core.BLL.Entities.Common.TimeZone", b =>
                {
                    b.HasOne("Dna.NetCore.Core.BLL.Entities.Common.StateOrProvince")
                        .WithMany("TimeZones")
                        .HasForeignKey("StateOrProvinceId");
                });
        }
    }
}
