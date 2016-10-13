using Dna.NetCore.Core.BLL.Resources;
using System.ComponentModel.DataAnnotations;

namespace Dna.NetCore.Core.BLL.EntityMetadata.Common
{
    public partial class PersonType_Summary_Metadata : BaseMetadataSummary
    {
        [Required(ErrorMessageResourceName = "SystemNameIsRequired", ErrorMessageResourceType = typeof(ValidationMessages))]
        //[RegularExpression(@"^[A-Z''-'\s]{1,2}$")]
        [StringLength(256, ErrorMessageResourceName = "StringLengthAttribute_InvalidMax", ErrorMessageResourceType = typeof(ValidationMessages))]
        [DisplayFormat(NullDisplayText = "[system name]")]
        [Display(Name = "SystemName", ResourceType = typeof(Labels))]
        public virtual string SystemName { get; set; }

        [DisplayFormat(NullDisplayText = "[display name]")]
        [StringLength(256, ErrorMessageResourceName = "StringLengthAttribute_InvalidMax", ErrorMessageResourceType = typeof(ValidationMessages))]
        [Display(Name = "DisplayName", ResourceType = typeof(Labels))]
        public virtual string DisplayName { get; set; }

        [Display(Name = "IsActive", ResourceType = typeof(Labels))]
        public virtual bool IsActive { get; set; }
    }
}
