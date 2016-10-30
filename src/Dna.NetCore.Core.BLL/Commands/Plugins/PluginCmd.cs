using Dna.NetCore.Core.BLL.EntityMetadata.Plugins;
using Dna.NetCore.Core.Commands;
using System.ComponentModel.DataAnnotations;

namespace Dna.NetCore.Core.BLL.Commands.Plugins
{
#if NET462
    [MetadataType(typeof(Plugin_Metadata))]
#endif
    public partial class PluginCmd : BaseCommand, ICommand
	{
        public virtual int Id { get; set; }
        public virtual string SystemName { get; set; }
        public virtual string DisplayName { get; set; }
        public virtual string Notes { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual int AssemblyLoadOrder { get; set; }
    }
}
