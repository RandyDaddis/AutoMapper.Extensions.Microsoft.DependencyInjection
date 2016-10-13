using Dna.NetCore.Core.BLL.Resources;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dna.NetCore.Core.BLL.EntityMetadata.Common
{
    public abstract partial class CommentBase_Dao_Metadata : BaseMetadata
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Id", ResourceType = typeof(Labels))]
        public virtual int Id { get; set; }

        [Required(ErrorMessageResourceName = "SubjectIsRequired", ErrorMessageResourceType = typeof(ValidationMessages))]
        [StringLength(256, ErrorMessageResourceName = "StringLengthAttribute_InvalidMax", ErrorMessageResourceType = typeof(ValidationMessages))]
        [Display(Name = "Subject", ResourceType = typeof(Labels))]
        public virtual string Subject { get; set; }

        [Required(ErrorMessageResourceName = "NotesIsRequired", ErrorMessageResourceType = typeof(ValidationMessages))]
        [DataType(DataType.MultilineText)]
        [StringLength(4096, ErrorMessageResourceType = typeof(ValidationMessages), ErrorMessageResourceName = "StringLengthAttribute_InvalidMax")]
        [Display(Name = "Notes", ResourceType = typeof(Labels))]
        public virtual string Notes { get; set; }

        [Display(Name = "IsActive", ResourceType = typeof(Labels))]
        public virtual bool IsActive { get; set; }

        [Display(Name = "IsApproved", ResourceType = typeof(Labels))]
        public virtual bool IsApproved { get; set; }

        [Required(ErrorMessageResourceName = "UserNameIsRequired", ErrorMessageResourceType = typeof(ValidationMessages))]
        [Display(Name = "UserName", ResourceType = typeof(Labels))]
        public virtual string UserName { get; set; }
    }

}
