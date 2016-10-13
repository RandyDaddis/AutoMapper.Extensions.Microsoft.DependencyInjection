using Dna.NetCore.Core.BLL.EntityMetadata.Localization;
using System.ComponentModel.DataAnnotations;

namespace Dna.NetCore.Core.BLL.DataTransferObjects.Localization
{
#if NET462
    [MetadataType(typeof(Locale_Summary_Metadata))]
#endif
    public partial class Locale_Summary : BaseDataTransferObjectSummary
    {
        public virtual int Id { get; set; }
        public virtual string DisplayName { get; set; }
        public virtual string LCIDString { get; set; }
        public virtual bool IsActive { get; set; }
    }
}
