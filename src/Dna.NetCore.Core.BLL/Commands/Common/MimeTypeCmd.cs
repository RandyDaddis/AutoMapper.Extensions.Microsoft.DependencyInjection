using Dna.NetCore.Core.BLL.EntityMetadata.Common;
using Dna.NetCore.Core.Commands;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dna.NetCore.Core.BLL.Commands.Common
{
#if NET462
    [MetadataType(typeof(MimeType_Metadata))]
#endif
    public partial class MimeTypeCmd : BaseCommand, ICommand
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }
        public virtual string ContentType { get; set; }
        public virtual string FileExtension { get; set; }
        //public virtual string DisplayName { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual int MimeTypeGroupId { get; set; }

        public virtual MimeTypeGroupCmd MimeTypeGroup { get; set; }
    }
}
