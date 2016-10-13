using Dna.NetCore.Core.BLL.Resources;
using System.ComponentModel.DataAnnotations;

namespace Dna.NetCore.Core.BLL.EntityMetadata.Common
{
    public partial class Country_Summary_Metadata : BaseMetadataSummary
    {
        [Display(Name = "Country", ResourceType = typeof(Labels))]
        public virtual string Abbreviation { get; set; }

        [Display(Name = "IsActive", ResourceType = typeof(Labels))]
        public virtual bool IsActive { get; set; }

        [Display(Name = "IsShippingAllowed", ResourceType = typeof(Labels))]
        public virtual bool IsShippingAllowed { get; set; }

        [Display(Name = "IsVatEnabled", ResourceType = typeof(Labels))]
        public virtual bool IsVatEnabled { get; set; }
    }
}
