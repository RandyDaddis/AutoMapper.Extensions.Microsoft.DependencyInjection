using Dna.NetCore.Core.BLL.EntityMetadata.Common;
using System.ComponentModel.DataAnnotations;

namespace Dna.NetCore.Core.BLL.DataTransferObjects.Common
{
#if NET462
    [MetadataType(typeof(MimeType_Metadata))]
#endif
    public partial class MimeTypeDto : BaseDataTransferObject
    {
        #region Public Properties

        public virtual int Id { get; set; }

        public virtual string ContentType { get; set; }
        public virtual string FileExtension { get; set; }
        //public virtual string DisplayName { get; set; }
        public virtual bool IsActive { get; set; }

        public virtual int MimeTypeGroupId { get; set; }

        #endregion

        #region Navigation Members

        public virtual MimeTypeGroupDto MimeTypeGroup { get; set; }

        #endregion
    }
}
