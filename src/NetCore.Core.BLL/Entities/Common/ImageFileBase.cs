using Dna.NetCore.Core.BLL.EntityMetadata.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace Dna.NetCore.Core.BLL.Entities.Common
{
    //[Table("Core_ImageFile", Schema = "dbo")]
#if NET462
    [MetadataType(typeof(ImageFileBase_Dao_Metadata))]
#endif
    public abstract partial class ImageFileBase : BaseEntity
    {
        #region Public Properties

        //[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public virtual int Id { get; set; }

        public string Name { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public long Size { get; set; }
        public virtual string MimeType { get; set; }
        public virtual string Title { get; set; }
        public virtual string AltTitle { get; set; }
        public virtual string ShortDescription { get; set; }
        public virtual string MediumDescription { get; set; }
        public virtual string LongDescription { get; set; }
        public virtual int DisplayOrder { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual bool IsPublished { get; set; }

        #endregion
    }
}
