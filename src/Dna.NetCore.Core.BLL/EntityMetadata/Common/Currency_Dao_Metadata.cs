using Dna.NetCore.Core.BLL.Resources;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dna.NetCore.Core.BLL.EntityMetadata.Common
{
    public partial class Currency_Dao_Metadata : BaseMetadata
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Id", ResourceType = typeof(Labels))]
        public virtual int Id { get; set; }

        [Required(ErrorMessageResourceName = "DisplayNameIsRequired", ErrorMessageResourceType = typeof(ValidationMessages))]
        [StringLength(256, ErrorMessageResourceName = "StringLengthAttribute_InvalidMax", ErrorMessageResourceType = typeof(ValidationMessages))]
        [Display(Name = "DisplayName", ResourceType = typeof(Labels))]
        public virtual string DisplayName { get; set; }

        [Required(ErrorMessageResourceName = "CodeisRequired", ErrorMessageResourceType = typeof(ValidationMessages))]
        [StringLength(16, ErrorMessageResourceType = typeof(ValidationMessages), ErrorMessageResourceName = "StringLengthAttribute_InvalidMax")]
        //StringLength(3)?
        [Display(Name = "Code", ResourceType = typeof(Labels))]
        public virtual string Code { get; set; }

        [StringLength(256, ErrorMessageResourceName = "StringLengthAttribute_InvalidMax", ErrorMessageResourceType = typeof(ValidationMessages))]
        //StringLength(5)?
        [Display(Name = "Locality", ResourceType = typeof(Labels))]
        public virtual string Locality { get; set; }

        [StringLength(64, ErrorMessageResourceName = "StringLengthAttribute_InvalidMax", ErrorMessageResourceType = typeof(ValidationMessages))]
        [Display(Name = "Format", ResourceType = typeof(Labels))]
        public virtual string Format { get; set; }

        [Required(ErrorMessageResourceName = "RateIsRequired", ErrorMessageResourceType = typeof(ValidationMessages))]
        [Display(Name = "Rate", ResourceType = typeof(Labels))]
        public virtual decimal Rate { get; set; }

        [Display(Name = "IsActive", ResourceType = typeof(Labels))]
        public virtual bool IsActive { get; set; }

        [Display(Name = "IsPublished", ResourceType = typeof(Labels))]
        public virtual bool IsPublished { get; set; }

    }
}
