using Dna.NetCore.Core.BLL.Resources;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dna.NetCore.Core.BLL.EntityMetadata.Localization
{
    public partial class Language_Dao_Metadata : BaseMetadata
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Id", ResourceType = typeof(Labels))]
        public virtual string Id { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(ValidationMessages))]
        [StringLength(2, ErrorMessageResourceName = "StringLengthAttribute_InvalidMax", ErrorMessageResourceType = typeof(ValidationMessages))]
        [Display(Name = "Abbreviation", ResourceType = typeof(Labels))]
        public virtual string Abbreviation { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(ValidationMessages))]
        [StringLength(256, ErrorMessageResourceName = "StringLengthAttribute_InvalidMax", ErrorMessageResourceType = typeof(ValidationMessages))]
        [Display(Name = "Name", ResourceType = typeof(Labels))]
        public virtual string Name { get; set; }

        [Display(Name = "Subtag", ResourceType = typeof(Labels))]
        [StringLength(256, ErrorMessageResourceName = "StringLengthAttribute_InvalidMax", ErrorMessageResourceType = typeof(ValidationMessages))]
        public virtual string Subtag { get; set; }

        //public virtual string Tag { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(2048, ErrorMessageResourceName = "StringLengthAttribute_InvalidMax", ErrorMessageResourceType = typeof(ValidationMessages))]
        [DisplayFormat(NullDisplayText = "[notes]")]
        [Display(Name = "Notes", ResourceType = typeof(Labels))]
        public virtual string Notes { get; set; }

        [Display(Name = "Added", ResourceType = typeof(Labels))]
        public virtual string Added { get; set; }

        [Display(Name = "Depreciated", ResourceType = typeof(Labels))]
        public virtual string Depreciated { get; set; }

        [Display(Name = "PreferredValue", ResourceType = typeof(Labels))]
        public virtual string PreferredValue { get; set; }

        [Display(Name = "Prefix", ResourceType = typeof(Labels))]
        public virtual string Prefix { get; set; }

        [Display(Name = "SuppressScript", ResourceType = typeof(Labels))]
        public virtual string SuppressScript { get; set; }

        [Display(Name = "Macrolanguage", ResourceType = typeof(Labels))]
        public virtual string Macrolanguage { get; set; }

        [Display(Name = "Scope", ResourceType = typeof(Labels))]
        public virtual string Scope { get; set; }

        [Display(Name = "Comments", ResourceType = typeof(Labels))]
        public virtual string Comments { get; set; }

        [Display(Name = "IsActive", ResourceType = typeof(Labels))]
        public virtual bool IsActive { get; set; }

    }
}
