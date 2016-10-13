using Dna.NetCore.Core.BLL.EntityMetadata.Common;
using System.ComponentModel.DataAnnotations;

namespace Dna.NetCore.Core.BLL.Entities.Common
{
    //[Table("Core_Image", Schema = "dbo")]
#if NET462
    [MetadataType(typeof(ImageBase_Dao_Metadata))]
#endif
    public abstract partial class ImageBase : BaseEntity
    {
        #region Public Properties

        //[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public virtual int Id { get; set; }

        public virtual int Height { get; set; }
        public virtual int Width { get; set; }
        public virtual int FileSize { get; set; }  // TODO: refactor from int to long
        public virtual string FileName { get; set; }
        public virtual string MimeType { get; set; }
        public virtual string Title { get; set; }
        public virtual string AltTitle { get; set; }
        public virtual string ShortDescription { get; set; }
        public virtual string MediumDescription { get; set; }
        public virtual string LongDescription { get; set; }
        public virtual int DisplayOrder { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual bool IsPublished { get; set; }

        //public virtual int ImageId { get; set; }

        #endregion

        #region Navigation Members

        // DEVNOTE: avoid image navigation property due to 
        //          SQL Server performance issues with BLOBs
        //public virtual ImageBase Image { get; set; }

        #endregion
    }
}
