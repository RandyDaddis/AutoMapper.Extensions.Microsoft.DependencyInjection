using Dna.NetCore.Core.BLL.EntityMetadata.Common;
using System.ComponentModel.DataAnnotations;

namespace Dna.NetCore.Core.BLL.DataTransferObjects.Common
{
#if NET462
    [MetadataType(typeof(City_Summary_Metadata))]
#endif
    public partial class CitySummary : BaseDataTransferObjectSummary
    {
        public virtual int Id { get; set; }

        public virtual string DisplayName { get; set; }
        public virtual bool IsActive { get; set; }
    }
}
