using Dna.NetCore.Core.BLL.Resources;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dna.NetCore.Core.BLL.EntityMetadata.Common
{
    public partial class StateOrProvince_Dao_Metadata : BaseMetadata
    {
        #region Public Properties

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Id", ResourceType = typeof(Labels))]
        public virtual int Id { get; set; }

        //[RegularExpression(@"^[A-Z''-'\s]{1,2}$")]
        [Required(ErrorMessageResourceName = "AbbreviationIsRequired", ErrorMessageResourceType = typeof(ValidationMessages))]
        [StringLength(2, ErrorMessageResourceName = "StringLengthAttribute_InvalidMax", ErrorMessageResourceType = typeof(ValidationMessages))]
        [DisplayFormat(NullDisplayText = "[Abbreviation]")]
        [Display(Name = "Abbreviation", ResourceType = typeof(Labels))]
        public virtual string Abbreviation { get; set; }

        [Required(ErrorMessageResourceName = "DisplayNameIsRequired", ErrorMessageResourceType = typeof(ValidationMessages))]
        [StringLength(256, ErrorMessageResourceName = "StringLengthAttribute_InvalidMax", ErrorMessageResourceType = typeof(ValidationMessages))]
        [Display(Name = "DisplayName", ResourceType = typeof(Labels))]
        public virtual string DisplayName { get; set; }

        [Display(Name = "IsActive", ResourceType = typeof(Labels))]
        public virtual bool IsActive { get; set; }

        [Display(Name = "IsShippingAllowed", ResourceType = typeof(Labels))]
        public virtual bool IsShippingAllowed { get; set; }

        [Display(Name = "Country", ResourceType = typeof(Labels))]
        public virtual int CountryId { get; set; }

        #endregion
    }
}
