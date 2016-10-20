using Dna.NetCore.Core.BLL.Resources;
using System.ComponentModel.DataAnnotations;

namespace Dna.NetCore.Core.BLL.EntityMetadata.Plugins
{
    public partial class PluginSummaryMetadata : BaseMetadataSummary
    {
        [StringLength(256, ErrorMessageResourceName = "StringLengthAttribute_InvalidMax", ErrorMessageResourceType = typeof(ValidationMessages))]
        [DisplayFormat(NullDisplayText = "[display name]")]
        [Display(Name = "DisplayName", ResourceType = typeof(Labels))]
        public string DisplayName { get; set; }

        [Display(Name = "IsActive", ResourceType = typeof(Labels))]
        public virtual bool IsActive { get; set; }
    }
}
