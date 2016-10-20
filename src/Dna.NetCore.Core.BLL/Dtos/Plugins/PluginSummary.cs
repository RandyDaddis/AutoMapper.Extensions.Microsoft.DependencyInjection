using Dna.NetCore.Core.BLL.EntityMetadata.Plugins;
using System.ComponentModel.DataAnnotations;

namespace Dna.NetCore.Core.BLL.DataTransferObjects.Plugins
{
#if NET462
    [MetadataType(typeof(PluginSummaryMetadata))]
#endif
    public partial class PluginSummary : BaseDataTransferObjectSummary
    {
        public virtual int Id { get; set; }
        public virtual string SystemName { get; set; }
        public virtual string DisplayName { get; set; }
        public virtual bool IsActive { get; set; }
    }
}
