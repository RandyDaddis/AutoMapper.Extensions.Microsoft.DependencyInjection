using Dna.NetCore.Core.BLL.EntityMetadata.Common;
using System.ComponentModel.DataAnnotations;

namespace Dna.NetCore.Core.BLL.DataTransferObjects.Common
{
#if NET462
    [MetadataType(typeof(TimeZone_Summary_Metadata))]
#endif
    public partial class TimeZone_Summary : BaseDataTransferObject
    {
        public virtual int Id { get; set; }
        public virtual string TimeZoneInfoId { get; set; }
        public virtual bool IsActive { get; set; }
    }
}
