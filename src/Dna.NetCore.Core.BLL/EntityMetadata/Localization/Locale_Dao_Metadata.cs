using Dna.NetCore.Core.BLL.Resources;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dna.NetCore.Core.BLL.EntityMetadata.Localization
{
    public partial class Locale_Dao_Metadata : BaseMetadata
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Id", ResourceType = typeof(Labels))]
        public virtual string Id { get; set; }

        [Required(ErrorMessageResourceName = "NameIsRequired", ErrorMessageResourceType = typeof(ValidationMessages))]
        [StringLength(256, ErrorMessageResourceName = "StringLengthAttribute_InvalidMax", ErrorMessageResourceType = typeof(ValidationMessages))]
        [Display(Name = "Name", ResourceType = typeof(Labels))]
        public virtual string DisplayName { get; set; }

        [StringLength(2, ErrorMessageResourceName = "StringLengthAttribute_InvalidMax", ErrorMessageResourceType = typeof(ValidationMessages))]
        [Display(Name = "LanguageCode", ResourceType = typeof(Labels))]
        public virtual string LanguageCode { get; set; }

        [StringLength(5, ErrorMessageResourceName = "StringLengthAttribute_InvalidMaxMin", ErrorMessageResourceType = typeof(ValidationMessages), MinimumLength = 0)]
        [Display(Name = "LCIDString", ResourceType = typeof(Labels))]
        public virtual string LCIDString { get; set; }

        [Required(ErrorMessageResourceName = "LCIDDecimalIsRequired", ErrorMessageResourceType = typeof(ValidationMessages))]
        [Display(Name = "LCIDDecimal", ResourceType = typeof(Labels))]
        public virtual int LCIDDecimal { get; set; }

        [Display(Name = "LCIDHexadecimal", ResourceType = typeof(Labels))]
        public virtual int LCIDHexadecimal { get; set; }

        [Display(Name = "CodePage", ResourceType = typeof(Labels))]
        public virtual int CodePage { get; set; }

        [Display(Name = "IsActive", ResourceType = typeof(Labels))]
        public virtual bool IsActive { get; set; }
    }
}
