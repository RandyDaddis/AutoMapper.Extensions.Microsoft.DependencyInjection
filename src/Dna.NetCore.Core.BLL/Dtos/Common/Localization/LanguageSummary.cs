using Dna.NetCore.Core.BLL.EntityMetadata.Localization;
using System.ComponentModel.DataAnnotations;

namespace Dna.NetCore.Core.BLL.DataTransferObjects.Localization
{
#if NET462
    [MetadataType(typeof(Language_Summary_Metadata))]
#endif
    public partial class LanguageSummary : BaseDataTransferObjectSummary
    {
        public virtual int Id { get; set; }
        public virtual string Abbreviation { get; set; }
        public virtual string Name { get; set; }
        public virtual string Subtag { get; set; }
        public virtual bool IsActive { get; set; }
    }
}
