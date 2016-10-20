using Dna.NetCore.Core.BLL.EntityMetadata.Plugins;
using System.ComponentModel.DataAnnotations;

namespace Dna.NetCore.Core.BLL.DataTransferObjects.Plugins
{
#if NET462
    [MetadataType(typeof(Plugin_Metadata))]
#endif
    public partial class PluginDto : BaseDataTransferObject
	{
        #region Public Properties

        public virtual int Id { get; set; }
        public virtual string SystemName { get; set; }
        public virtual string DisplayName { get; set; }
        public virtual string Notes { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual int AssemblyLoadOrder { get; set; }

        #endregion

    }
}
