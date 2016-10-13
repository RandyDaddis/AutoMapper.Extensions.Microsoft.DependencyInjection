using Dna.NetCore.Core.BLL.Resources;
using System.ComponentModel.DataAnnotations;

namespace Dna.NetCore.Core.BLL.EntityMetadata.Common
{
    public partial class TimeZone_Summary_Metadata : BaseMetadataSummary
    {
        [Display(Name = "TimeZoneInfoId", ResourceType = typeof(Labels))]
        public virtual string TimeZoneInfoId { get; set; }
    }
}
