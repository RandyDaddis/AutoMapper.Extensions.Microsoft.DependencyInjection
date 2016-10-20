using Dna.NetCore.Core.BLL.EntityMetadata.Plugins;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dna.NetCore.Core.BLL.Entities.Plugins
{
    [Table("Core_Plugin", Schema = "dbo")]
#if NET462
    [MetadataType(typeof(Plugin_Dao_Metadata))]
#endif
    public partial class Plugin : BaseEntity
	{
		#region Public Properties

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }
        public virtual string SystemName { get; set; }
        public virtual string DisplayName { get; set; }
		public virtual string Notes { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual int AssemblyLoadOrder { get; set; }

        #endregion
    }
}
