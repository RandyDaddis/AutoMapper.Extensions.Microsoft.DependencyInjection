using Dna.NetCore.Core.BLL.Resources;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dna.NetCore.Core.BLL.EntityMetadata.Common
{
    public abstract partial class ImageBase_Dao_Metadata : BaseMetadata
    {
        [Display(Name = "Height", ResourceType = typeof(Labels))]
        public virtual int Height { get; set; }

        [Display(Name = "Width", ResourceType = typeof(Labels))]
        public virtual int Width { get; set; }

        //[Required(ErrorMessageResourceName = "FileSizeIsRequired", ErrorMessageResourceType = typeof(ValidationMessages))]
        [Display(Name = "FileSize", ResourceType = typeof(Labels))]
        public virtual int FileSize { get; set; }

        //[Required(ErrorMessageResourceName = "FileNameIsRequired", ErrorMessageResourceType = typeof(ValidationMessages))]
        [StringLength(256, ErrorMessageResourceType = typeof(ValidationMessages), ErrorMessageResourceName = "StringLengthAttribute_InvalidMax")]
        [Display(Name = "FileName", ResourceType = typeof(Labels))]
        public virtual string FileName { get; set; }

        //[Required(ErrorMessageResourceName = "MimeTypeIsRequired", ErrorMessageResourceType = typeof(ValidationMessages))]
        [StringLength(256, ErrorMessageResourceType = typeof(ValidationMessages), ErrorMessageResourceName = "StringLengthAttribute_InvalidMax")]
        [Display(Name = "MimeType", ResourceType = typeof(Labels))]
        public virtual string MimeType { get; set; }

        [Required(ErrorMessageResourceName = "TitleIsRequired", ErrorMessageResourceType = typeof(ValidationMessages))]
        [StringLength(256, ErrorMessageResourceType = typeof(ValidationMessages), ErrorMessageResourceName = "StringLengthAttribute_InvalidMax")]
        [Display(Name = "Title", ResourceType = typeof(Labels))]
        public virtual string Title { get; set; }

        [StringLength(256, ErrorMessageResourceType = typeof(ValidationMessages), ErrorMessageResourceName = "StringLengthAttribute_InvalidMax")]
        [Display(Name = "AltTitle", ResourceType = typeof(Labels))]
        public virtual string AltTitle { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(1024, ErrorMessageResourceName = "StringLengthAttribute_InvalidMax", ErrorMessageResourceType = typeof(ValidationMessages))]
        [Display(Name = "ShortDescription", ResourceType = typeof(Labels))]
        public virtual string ShortDescription { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(4096, ErrorMessageResourceName = "StringLengthAttribute_InvalidMax", ErrorMessageResourceType = typeof(ValidationMessages))]
        [Display(Name = "MediumDescription", ResourceType = typeof(Labels))]
        public virtual string MediumDescription { get; set; } 

        [DataType(DataType.MultilineText)]
        [StringLength(8192, ErrorMessageResourceName = "StringLengthAttribute_InvalidMax", ErrorMessageResourceType = typeof(ValidationMessages))]
        [Display(Name = "LongDescription", ResourceType = typeof(Labels))]
        public virtual string LongDescription { get; set; }  

        [Display(Name = "DisplayOrder", ResourceType = typeof(Labels))]
        public virtual int DisplayOrder { get; set; }

        [Display(Name = "IsActive", ResourceType = typeof(Labels))]
        public virtual bool IsActive { get; set; }

        [Display(Name = "IsPublished", ResourceType = typeof(Labels))]
        public virtual bool IsPublished { get; set; }
    }
}
