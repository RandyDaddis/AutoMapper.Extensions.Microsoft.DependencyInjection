using Dna.NetCore.Core.BLL.Resources;
using System.ComponentModel.DataAnnotations;

namespace Dna.NetCore.Core.BLL.EntityMetadata.Common
{
    public partial class City_Summary_Metadata : BaseMetadataSummary
    {
        //[RegularExpression(@"^[A-Z''-'\s]{1,40}$")]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(ValidationMessages))]
        [StringLength(256, ErrorMessageResourceName = "StringLengthAttribute_InvalidMax", ErrorMessageResourceType = typeof(ValidationMessages))]
        [Display(Name = "DisplayName", ResourceType = typeof(Labels))]
        public virtual string DisplayName { get; set; }

        [Display(Name = "IsActive", ResourceType = typeof(Labels))]
        public virtual bool IsActive { get; set; }
    }
}
