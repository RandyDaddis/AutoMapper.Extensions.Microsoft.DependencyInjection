using Dna.NetCore.Core.BLL.Resources;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dna.NetCore.Core.BLL.EntityMetadata.Common
{
    public abstract partial class AddressBase_Dao_Metadata : BaseMetadata
	{
		#region Public Properties

        //[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Display(Name = "Id", ResourceType = typeof(Labels))]
        //public virtual int Id { get; set; }

        [StringLength(256, ErrorMessageResourceName = "StringLengthAttribute_InvalidMax", ErrorMessageResourceType = typeof(ValidationMessages))]
        [Display(Name = "Address", ResourceType = typeof(Labels))]
        public virtual string AddressLine1 { get; set; }

        [StringLength(256, ErrorMessageResourceName = "StringLengthAttribute_InvalidMax", ErrorMessageResourceType = typeof(ValidationMessages))]
        public virtual string AddressLine2 { get; set; }
		
        [StringLength(256, ErrorMessageResourceName = "StringLengthAttribute_InvalidMax", ErrorMessageResourceType = typeof(ValidationMessages))]
        public virtual string AddressLine3 { get; set; }
		
        [RegularExpression(@"\d{5}(-\d{4})?", ErrorMessageResourceType = typeof(ValidationMessages), ErrorMessageResourceName = "PostalCodeInvalid")]
        [StringLength(256, ErrorMessageResourceName = "StringLengthAttribute_InvalidMax", ErrorMessageResourceType = typeof(ValidationMessages))]
        [Display(Name = "PostalCode", ResourceType = typeof(Labels))]
        public virtual string PostalCode { get; set; }

        [Display(Name = "IsActive", ResourceType = typeof(Labels))]
        public virtual bool IsActive { get; set; }

        //[Display(Name = "IsPrimary", ResourceType = typeof(Labels))]
        //public virtual bool IsPrimary { get; set; }

        public virtual int AddressTypeId { get; set; }
        public virtual int CityId { get; set; }
        public virtual int? CountyId { get; set; }
        public virtual int StateOrProvinceId { get; set; }

        //[Required(ErrorMessageResourceType = typeof(ValidationMessages), ErrorMessageResourceName = "Required")]
        //public virtual int CountryId { get; set; }

        #endregion

    }
}
