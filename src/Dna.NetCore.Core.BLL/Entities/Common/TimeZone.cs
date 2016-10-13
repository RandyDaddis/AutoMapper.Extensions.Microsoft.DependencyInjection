using Dna.NetCore.Core.BLL.EntityMetadata.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dna.NetCore.Core.BLL.Entities.Common
{
    [Table("Core_TimeZone", Schema = "dbo")]
#if NET462
    [MetadataType(typeof(TimeZone_Dao_Metadata))]
#endif
    public partial class TimeZone : BaseEntity
	{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }
        //     The time zone identifier.
        public virtual string TimeZoneInfoId { get; set; }
        //     The display name for the time zone's daylight saving time.
        public virtual string DaylightName { get; set; }
        //     The time zone's general display name.
        public virtual string DisplayName { get; set; }
        //     The display name of the time zone's standard time.
        public virtual string StandardName { get; set; }
        //     true if the time zone supports daylight saving time; otherwise, false.
        public virtual bool SupportsDaylightSavingTime { get; set; }
        public virtual bool IsActive { get; set; }
    }
}
