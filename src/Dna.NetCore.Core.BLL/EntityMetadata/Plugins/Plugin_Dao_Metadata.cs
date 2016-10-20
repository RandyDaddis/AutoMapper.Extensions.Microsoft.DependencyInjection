using Dna.NetCore.Core.BLL.Resources;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dna.NetCore.Core.BLL.EntityMetadata.Plugins
{
    public partial class Plugin_Dao_Metadata : BaseMetadata
	{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Id", ResourceType = typeof(Labels))]
        public virtual string Id { get; set; }

        //[RegularExpression(@"^[A-Z''-'\s]{1,2}$")]
        [Required(ErrorMessageResourceName = "SystemNameIsRequired", ErrorMessageResourceType = typeof(ValidationMessages))]
        [StringLength(256, ErrorMessageResourceName = "StringLengthAttribute_InvalidMax", ErrorMessageResourceType = typeof(ValidationMessages))]
        [DisplayFormat(NullDisplayText = "[system name]")]
        [Display(Name = "SystemName", ResourceType = typeof(Labels))]
        public virtual string SystemName { get; set; }

        [Required(ErrorMessageResourceName = "DisplayNameIsRequired", ErrorMessageResourceType = typeof(ValidationMessages))]
        [StringLength(256, ErrorMessageResourceName = "StringLengthAttribute_InvalidMax", ErrorMessageResourceType = typeof(ValidationMessages))]
        [DisplayFormat(NullDisplayText = "[DisplayName]")]
        [Display(Name = "DisplayName", ResourceType = typeof(Labels))]
        public virtual string DisplayName { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(1024, ErrorMessageResourceName = "StringLengthAttribute_InvalidMax", ErrorMessageResourceType = typeof(ValidationMessages))]
        [DisplayFormat(NullDisplayText = "[notes]")]
        [Display(Name = "Notes", ResourceType = typeof(Labels))]
        public virtual string Notes { get; set; }

        [Display(Name = "IsActive", ResourceType = typeof(Labels))]
        public virtual bool IsActive { get; set; }

        public virtual int AssemblyLoadOrder { get; set; }
    }
}
