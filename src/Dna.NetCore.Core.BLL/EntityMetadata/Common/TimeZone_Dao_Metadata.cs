using Dna.NetCore.Core.BLL.Resources;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dna.NetCore.Core.BLL.EntityMetadata.Common
{
    public partial class TimeZone_Dao_Metadata : BaseMetadata
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Id", ResourceType = typeof(Labels))]
        public virtual int Id { get; set; }
        //     The time zone identifier.
        [Required(ErrorMessage = "TimeZoneInfoIdIsRequired", ErrorMessageResourceType = typeof(Labels))]
        [Display(Name = "TimeZoneInfoId", ResourceType = typeof(Labels))]
        public virtual string TimeZoneInfoId { get; set; }
        //     The display name for the time zone's daylight saving time.
        [Display(Name = "TimeZoneInfoDaylightName", ResourceType = typeof(Labels))]
        public virtual string DaylightName { get; set; }
        //     The time zone's general display name.
        [Required(ErrorMessage = "DisplayNameIsRequired", ErrorMessageResourceType = typeof(Labels))]
        [Display(Name = "DisplayName", ResourceType = typeof(Labels))]
        public virtual string DisplayName { get; set; }
        //     The display name of the time zone's standard time.
        [Display(Name = "TimeZoneInfoStandardName", ResourceType = typeof(Labels))]
        public virtual string StandardName { get; set; }
        //     true if the time zone supports daylight saving time; otherwise, false.
        [Display(Name = "TimeZoneInfoSupportsDaylightSavingTime", ResourceType = typeof(Labels))]
        public virtual bool SupportsDaylightSavingTime { get; set; }
        [Display(Name = "IsActive", ResourceType = typeof(Labels))]
        public virtual bool IsActive { get; set; }

    }
}
