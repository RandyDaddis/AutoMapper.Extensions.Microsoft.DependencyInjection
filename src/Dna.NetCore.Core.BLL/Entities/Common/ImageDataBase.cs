using Dna.NetCore.Core.BLL.EntityMetadata.Common;
using System.ComponentModel.DataAnnotations;

namespace Dna.NetCore.Core.BLL.Entities.Common
{
    //[Table("Core_Image", Schema = "dbo")]
#if NET462
    [MetadataType(typeof(ImageDataBase_Dao_Metadata))]
#endif
    public abstract partial class ImageDataBase : BaseEntity
    {
        #region Public Properties

        // WARNING: base class cannot contain id due to EF contraint:
        //         - EF one-to-one relationships require the primary key of the dependent also be the foreign key
        //         - [Key)
        //         - [ForeignKey("xxxPicture")
        //[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public virtual int Id { get; set; }

        public virtual byte[] Data { get; set; }
        //public virtual string ContentType { get; set; }

        #endregion
    }
}
