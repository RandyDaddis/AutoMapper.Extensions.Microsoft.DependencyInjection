using Dna.NetCore.Core.BLL.Resources;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dna.NetCore.Core.BLL.EntityMetadata.Common
{
    public abstract partial class PhoneNumberBase_Dao_Metadata : BaseMetadata
	{
		#region Public Properties

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Id", ResourceType = typeof(Labels))]
        public virtual int Id { get; set; }

        //[Required(ErrorMessageResourceName = "CountryCodeIsRequired", ErrorMessageResourceType = typeof(ValidationMessages))]
        //[StringLength(64, MinimumLength = 1, ErrorMessageResourceName = "StringLengthAttribute_InvalidMaxMin", ErrorMessageResourceType = typeof(ValidationMessages))]
        //[Display(Name = "CountryCode", ResourceType = typeof(Labels))]
        //public virtual string CountryCode { get; set; }

        //[Required(ErrorMessageResourceName = "AreaCodeIsRequired", ErrorMessageResourceType = typeof(ValidationMessages))]
        //[StringLength(3, MinimumLength =3, ErrorMessageResourceName = "StringLengthAttribute_InvalidMaxMin", ErrorMessageResourceType = typeof(ValidationMessages))]
        //[Display(Name = "AreaCode", ResourceType = typeof(Labels))]
        //public virtual string AreaCode { get; set; }

        [Required(ErrorMessageResourceName = "PhoneNumberIsRequired", ErrorMessageResourceType = typeof(ValidationMessages))]
        //[StringLength(16, MinimumLength = 3, ErrorMessageResourceName = "StringLengthAttribute_InvalidMaxMin", ErrorMessageResourceType = typeof(ValidationMessages))]
        [Display(Name = "PhoneNumber", ResourceType = typeof(Labels))]
        public virtual string Number { get; set; }

        //[StringLength(16, ErrorMessageResourceName = "StringLengthAttribute_InvalidMaxMin", ErrorMessageResourceType = typeof(ValidationMessages))]
        [Display(Name = "Extension", ResourceType = typeof(Labels))]
        public virtual string Extension { get; set; }

        [Display(Name = "IsActive", ResourceType = typeof(Labels))]
        public virtual bool IsActive { get; set; }

        [Display(Name = "IsPrimary", ResourceType = typeof(Labels))]
        public virtual bool IsPrimary { get; set; }

        [Required(ErrorMessageResourceName = "CountryIsRequired", ErrorMessageResourceType = typeof(ValidationMessages))]
        [Display(Name = "CountryId", ResourceType = typeof(Labels))]
        public virtual int CountryId { get; set; }

        [Required(ErrorMessageResourceName = "PhoneNumberTypeIsRequired", ErrorMessageResourceType = typeof(ValidationMessages))]
        [Display(Name = "PhoneNumberTypeId", ResourceType = typeof(Labels))]
        public virtual int PhoneNumberTypeId { get; set; }

        #endregion

    }
}
