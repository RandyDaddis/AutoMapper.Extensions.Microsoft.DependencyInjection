using Dna.NetCore.Core.BLL.Resources;
using System.ComponentModel.DataAnnotations;

namespace Dna.NetCore.Core.BLL.EntityMetadata.Common
{
    public partial class Comment_Summary_Metadata : BaseMetadataSummary
    {
        [StringLength(256, ErrorMessageResourceName = "StringLengthAttribute_InvalidMax", ErrorMessageResourceType = typeof(ValidationMessages))]
        [Display(Name = "Subject", ResourceType = typeof(Labels))]
        public virtual string Subject { get; set; }

        [Display(Name = "IsActive", ResourceType = typeof(Labels))]
        public virtual bool IsActive { get; set; }

        [Display(Name = "IsApproved", ResourceType = typeof(Labels))]
        public virtual bool IsApproved { get; set; }
    }

}
