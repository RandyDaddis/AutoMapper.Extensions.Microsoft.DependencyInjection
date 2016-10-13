using Dna.NetCore.Core.BLL.Resources;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dna.NetCore.Core.BLL.EntityMetadata.Common
{
    public abstract partial class PersonBase_Dao_Metadata : BaseMetadata
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Id", ResourceType = typeof(Labels))]
        public virtual int Id { get; set; }

        [Required(ErrorMessageResourceName = "UserNameIsRequired", ErrorMessageResourceType = typeof(ValidationMessages))]
        // DEVNOTE: UserName string length enfored by the UserAccount provider
        //[RegularExpression(@"^[A-Z''-'\s]{1,2}$")]
        [StringLength(256, ErrorMessageResourceType = typeof(ValidationMessages), ErrorMessageResourceName = "StringLengthAttribute_InvalidMax")]
        [DisplayFormat(NullDisplayText = "[user name]")]
        [Display(Name = "UserName", ResourceType = typeof(Labels))]
        public virtual string UserName { get; set; }

        //[RegularExpression(@"^[A-Z''-'\s]{1,2}$")]
        [StringLength(256, ErrorMessageResourceName = "StringLengthAttribute_InvalidMax", ErrorMessageResourceType = typeof(ValidationMessages))]
        [Display(Name = "FirstName", ResourceType = typeof(Labels))]
        public virtual string FirstName { get; set; }

        [StringLength(256, ErrorMessageResourceName = "StringLengthAttribute_InvalidMax", ErrorMessageResourceType = typeof(ValidationMessages))]
        [Display(Name = "MiddleName", ResourceType = typeof(Labels))]
        public virtual string MiddleName { get; set; }

        [StringLength(256, ErrorMessageResourceName = "StringLengthAttribute_InvalidMax", ErrorMessageResourceType = typeof(ValidationMessages))]
        [Display(Name = "LastName", ResourceType = typeof(Labels))]
        public virtual string LastName { get; set; }

        // Thinktecture.IdentityModel.Samples.ResourceAuthorizationSample.Chinook.Utility.CheckArgument.cs:
        //        [RegularExpression(@"^([0-9a-zA-Z]+[-._+&])*[0-9a-zA-Z]+@([-0-9a-zA-Z]+[.])+[a-zA-Z]{2,6}$",
        //              ErrorMessageResourceName = "EmailIsInvalid", ErrorMessageResourceType = typeof(ValidationMessages))] // Thinktecture.IdentityModel.Samples.ResourceAuthorizationSample.Chinook.Utility.CheckArgument.cs
        ////[RegularExpression(@"A-Za-z0-9._%+-]+@A-Za-z0-9.-]+\.[A-Za-z]{2,4}")] // Pro Asp.NET MVC p.121
        ////[RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Must be a valid e-mail address")]
        //[EmailAddress]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Must be a valid e-mail address")]
        [StringLength(254, ErrorMessageResourceType = typeof(ValidationMessages), ErrorMessageResourceName = "StringLengthAttribute_InvalidMax")]
        [Display(Name = "EmailPrimary", ResourceType = typeof(Labels))]
        public virtual string EmailPrimary { get; set; }

        //[Url]
        // TODO: what is the difference between [Url] and [DataType(DataType.Url)]
        //[DataType(DataType.Url)]
        //// TODO: what is the difference between [MaxLength] and [StringLength]
        ////[MaxLength(64)]
        [StringLength(256, ErrorMessageResourceName = "StringLengthAttribute_InvalidMax", ErrorMessageResourceType = typeof(ValidationMessages))]
        [Display(Name = "UrlPrimary", ResourceType = typeof(Labels))]
        public virtual string UrlPrimary { get; set; }

        [Display(Name = "LastIpAddress", ResourceType = typeof(Labels))]
        public virtual string LastIpAddress { get; set; }

        [DataType(DataType.DateTime)]
        //[DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        [DisplayFormat(DataFormatString = "{0:g}", NullDisplayText = "-")]
        //[DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [Display(Name = "LastLoginDate", ResourceType = typeof(Labels))]
        public virtual DateTime? LastLoginDate { get; set; }

        [Display(Name = "IsActive", ResourceType = typeof(Labels))]
        public virtual bool IsActive { get; set; }

        [Display(Name = "IsApproved", ResourceType = typeof(Labels))]
        public virtual bool IsApproved { get; set; }

        //[Display(Name = "Address", ResourceType = typeof(Labels))]
        //public virtual Address_ComplexType Address { get; set; }

        [Display(Name = "CurrencyId", ResourceType = typeof(Labels))]
        public virtual int CurrencyId { get; set; }
        //public virtual string Code { get; set; }

        [Display(Name = "LocaleId", ResourceType = typeof(Labels))]
        public virtual int LocaleId { get; set; }
        ////public virtual string LanguageAbbreviation { get; set; }

        [Display(Name = "TimeZoneId", ResourceType = typeof(Labels))]
        public virtual int TimeZoneId { get; set; }

        ////[Display(Name = "PersonTypeId", ResourceType = typeof(Labels))]
        ////public virtual int PersonTypeId { get; set; }

    }
}
