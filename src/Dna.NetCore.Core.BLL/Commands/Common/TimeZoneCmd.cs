using Dna.NetCore.Core.BLL.EntityMetadata.Common;
using Dna.NetCore.Core.Commands;
using System.ComponentModel.DataAnnotations;

namespace Dna.NetCore.Core.BLL.Commands.Common
{
#if NET462
    [MetadataType(typeof(TimeZone_Metadata))]
#endif
    public partial class TimeZoneCmd : BaseCommand, ICommand
    {
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
