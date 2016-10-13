using Dna.NetCore.Core.BLL.EntityMetadata.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dna.NetCore.Core.BLL.Entities.Common
{
    [Table("Core_MimeType", Schema = "dbo")]
#if NET462
    [MetadataType(typeof(MimeType_Dao_Metadata))]
#endif
    public partial class MimeType : BaseEntity
    {
        #region Public properties

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }

        public virtual string ContentType { get; set; }
        public virtual string FileExtension { get; set; }
        //public virtual string DisplayName { get; set; }
        public virtual bool IsActive { get; set; }

        public virtual int MimeTypeGroupId { get; set; }

        #endregion

        #region Navigaton Properties

        public virtual MimeTypeGroup MimeTypeGroup { get; set; }

        #endregion
    }
}
