using Dna.NetCore.Core.BLL.EntityMetadata.Common;
using System.ComponentModel.DataAnnotations;

namespace Dna.NetCore.Core.BLL.DataTransferObjects.Common
{
#if NET462
    [MetadataType(typeof(ImageBase_Metadata))]
#endif
    public abstract partial class ImageBaseDto : BaseDataTransferObject
    {
        #region Public Properties

        //public virtual int Id { get; set; }

        public virtual int Height { get; set; }
        public virtual int Width { get; set; }
        public virtual int FileSize { get; set; }
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

        #endregion
    }
}
