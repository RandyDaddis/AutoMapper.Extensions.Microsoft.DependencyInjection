using Dna.NetCore.Core.BLL.Resources;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dna.NetCore.Core.BLL.EntityMetadata.Common
{
    public partial class MimeType_Dao_Metadata : BaseMetadata
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Id", ResourceType = typeof(Labels))]
        public virtual int Id { get; set; }

        [Required(ErrorMessageResourceName = "ContentTypeIsRequired", ErrorMessageResourceType = typeof(ValidationMessages))]
        [StringLength(256, ErrorMessageResourceType = typeof(ValidationMessages), ErrorMessageResourceName = "StringLengthAttribute_InvalidMax")]
        [Display(Name = "ContentType", ResourceType = typeof(Labels))]
        public virtual string ContentType { get; set; }

        [Required(ErrorMessageResourceName = "FileExtensionIsRequired", ErrorMessageResourceType = typeof(ValidationMessages))]
        // DEVNOTE: I chose arbitray length - cref: http://www.freeformatter.com/mime-types-list.html#mime-types-list
        [StringLength(64, ErrorMessageResourceName = "StringLengthAttribute_InvalidMax", ErrorMessageResourceType = typeof(ValidationMessages))]
        [Display(Name = "FileExtension", ResourceType = typeof(Labels))]
        public virtual string FileExtension { get; set; }

        //[Required(ErrorMessageResourceName = "DisplayNameIsRequired", ErrorMessageResourceType = typeof(ValidationMessages))]
        //[DisplayFormat(NullDisplayText = "[Name]")]
        //[StringLength(256, ErrorMessageResourceName = "StringLengthAttribute_InvalidMax", ErrorMessageResourceType = typeof(ValidationMessages))]
        //[Display(Name = "DisplayName", ResourceType = typeof(Labels))]
        //public virtual string DisplayName { get; set; }

        [Display(Name = "IsActive", ResourceType = typeof(Labels))]
        public virtual bool IsActive { get; set; }

        [Display(Name = "MimeTypeGroup", ResourceType = typeof(Labels))]
        public virtual int MimeTypeGroupId { get; set; }
    }
}
