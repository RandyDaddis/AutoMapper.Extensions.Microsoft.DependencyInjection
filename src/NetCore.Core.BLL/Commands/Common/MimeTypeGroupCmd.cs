using Dna.NetCore.Core.BLL.EntityMetadata.Common;
using Dna.NetCore.Core.Commands;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dna.NetCore.Core.BLL.Commands.Common
{
#if NET462
    [MetadataType(typeof(MimeTypeGroup_Metadata))]
#endif
    public partial class MimeTypeGroupCmd : BaseCommand, ICommand
    {
        #region Public Properties

        public virtual int Id { get; set; }
        public virtual string SystemName { get; set; }
        public virtual string DisplayName { get; set; }
        public virtual bool IsActive { get; set; }

        #endregion

        #region Navigation Fields

        private ICollection<MimeTypeCmd> _mimeTypes;
        public virtual ICollection<MimeTypeCmd> MimeTypes
        {
            get { return _mimeTypes ?? (_mimeTypes = new List<MimeTypeCmd>()); }
            set { _mimeTypes = value; }
        }

        #endregion
    }
}
