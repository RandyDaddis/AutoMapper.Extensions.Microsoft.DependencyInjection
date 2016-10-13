using Dna.NetCore.Core.BLL.Resources;
using System.ComponentModel.DataAnnotations;

namespace Dna.NetCore.Core.BLL.EntityMetadata.Localization
{
    public partial class Locale_Summary_Metadata : BaseMetadataSummary
    {
        [Display(Name = "LanguageCode", ResourceType = typeof(Labels))]
        public virtual string LanguageCode { get; set; }

        [Display(Name = "LCIDString", ResourceType = typeof(Labels))]
        public virtual string LCIDString { get; set; }

        [Display(Name = "LCIDDecimal", ResourceType = typeof(Labels))]
        public virtual int LCIDDecimal { get; set; }

        [Display(Name = "IsActive", ResourceType = typeof(Labels))]
        public virtual bool IsActive { get; set; }
    }
}
