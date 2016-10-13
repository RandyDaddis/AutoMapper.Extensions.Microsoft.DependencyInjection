using Dna.NetCore.Core.BLL.Resources;
using System.ComponentModel.DataAnnotations;

namespace Dna.NetCore.Core.BLL.EntityMetadata.Localization
{
    public partial class Language_Summary_Metadata : BaseMetadataSummary
    {
        [Display(Name = "Abbreviation", ResourceType = typeof(Labels))]
        public virtual string Abbreviation { get; set; }

        [Display(Name = "Name", ResourceType = typeof(Labels))]
        public virtual string Name { get; set; }

        [Display(Name = "subtag", ResourceType = typeof(Labels))]
        public virtual string subtag { get; set; }

        [Display(Name = "IsActive", ResourceType = typeof(Labels))]
        public virtual bool IsActive { get; set; }

    }
}
