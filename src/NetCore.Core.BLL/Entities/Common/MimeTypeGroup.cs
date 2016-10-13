using Dna.NetCore.Core.BLL.EntityMetadata.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dna.NetCore.Core.BLL.Entities.Common
{
    [Table("Core_MimeTypeGroup", Schema = "dbo")]
#if NET462
    [MetadataType(typeof(MimeTypeGroup_Dao_Metadata))]
#endif
    public partial class MimeTypeGroup : BaseEntity
    {
        #region Public Properties

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }

        public virtual string SystemName { get; set; }
        public virtual string DisplayName { get; set; }
        public virtual bool IsActive { get; set; }

        #endregion

        #region Navigation Fields

        private ICollection<MimeType> _mimeTypes;
        public virtual ICollection<MimeType> MimeTypes
        {
            get { return _mimeTypes ?? (_mimeTypes = new List<MimeType>()); }
            set { _mimeTypes = value; }
        }

        #endregion
    }
}
