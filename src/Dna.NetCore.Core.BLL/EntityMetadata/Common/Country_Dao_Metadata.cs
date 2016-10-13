using Dna.NetCore.Core.BLL.Resources;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dna.NetCore.Core.BLL.EntityMetadata.Common
{
    public partial class Country_Dao_Metadata : BaseMetadata
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Id", ResourceType = typeof(Labels))]
        public virtual int Id { get; set; }

        //[RegularExpression(@"^[A-Z''-'\s]{1,2}$")]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(ValidationMessages))]
        [StringLength(2, ErrorMessageResourceName = "StringLengthAttribute_InvalidMax", ErrorMessageResourceType = typeof(ValidationMessages))]
        [DisplayFormat(NullDisplayText = "[system name]")]
        [Display(Name = "Abbreviation", ResourceType = typeof(Labels))]
        public virtual string Abbreviation { get; set; }
		
        //[RegularExpression(@"^[A-Z''-'\s]{1,40}$")]
        [Required(ErrorMessageResourceName = "DisplayNameRequired", ErrorMessageResourceType = typeof(ValidationMessages))]
        [StringLength(256, ErrorMessageResourceName = "StringLengthAttribute_InvalidMax", ErrorMessageResourceType = typeof(ValidationMessages))]
        [Display(Name = "DisplayName", ResourceType = typeof(Labels))]
        public virtual string DisplayName { get; set; }

        [Display(Name = "PhoneNumberCountryCode", ResourceType = typeof(Labels))]
        public virtual string PhoneNumberCountryCode { get; set; }

        [Display(Name = "IsActive", ResourceType = typeof(Labels))]
        public virtual bool IsActive { get; set; }

        [Display(Name = "IsShippingAllowed", ResourceType = typeof(Labels))]
        public virtual bool IsShippingAllowed { get; set; }

        [Display(Name = "IsVatEnabled", ResourceType = typeof(Labels))]
        public virtual bool IsVatEnabled { get; set; }

        [Display(Name = "Currency", ResourceType = typeof(Labels))]
        public virtual int? CurrencyId { get; set; }

        [Display(Name = "Locale", ResourceType = typeof(Labels))]
        public virtual int? LocaleId { get; set; }

    }
}
