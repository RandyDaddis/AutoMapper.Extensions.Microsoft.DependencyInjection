using Dna.NetCore.Core.BLL.EntityMetadata.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dna.NetCore.Core.BLL.DataTransferObjects.Common
{
#if NET462
    [MetadataType(typeof(MimeTypeGroup_Metadata))]
#endif
    public partial class MimeTypeGroupDto : BaseDataTransferObject
    {
        #region Public Properties

        public virtual int Id { get; set; }
        public virtual string SystemName { get; set; }
        public virtual string DisplayName { get; set; }
        public virtual bool IsActive { get; set; }

        #endregion

        #region Navigation Fields

        private ICollection<MimeTypeDto> _mimeTypes;
        public virtual ICollection<MimeTypeDto> MimeTypes
        {
            get { return _mimeTypes ?? (_mimeTypes = new List<MimeTypeDto>()); }
            set { _mimeTypes = value; }
        }

        #endregion
    }
}
