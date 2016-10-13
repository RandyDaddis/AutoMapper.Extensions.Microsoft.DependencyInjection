using Dna.NetCore.Core.BLL.Resources;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dna.NetCore.Core.BLL.EntityMetadata.Common
{
    public partial class SystemSetting_Dao_Metadata : BaseMetadata
	{
		#region Public Properties

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Id", ResourceType = typeof(Labels))]
        public virtual int Id { get; set; }

        [Required(ErrorMessageResourceName = "SystemNameIsRequired", ErrorMessageResourceType = typeof(ValidationMessages))]
        //[RegularExpression(@"^[A-Z''-'\s]{1,2}$")]
        [StringLength(256, ErrorMessageResourceName = "StringLengthAttribute_InvalidMax", ErrorMessageResourceType = typeof(ValidationMessages))]
        [DisplayFormat(NullDisplayText = "[system name]")]
        [Display(Name = "SystemName", ResourceType = typeof(Labels))]
        public virtual string SystemName { get; set; }

        [Required(ErrorMessageResourceName = "DisplayNameIsRequired", ErrorMessageResourceType = typeof(ValidationMessages))]
        [StringLength(256, ErrorMessageResourceName = "StringLengthAttribute_InvalidMax", ErrorMessageResourceType = typeof(ValidationMessages))]
        [Display(Name = "DisplayName", ResourceType = typeof(Labels))]
        public virtual string DisplayName { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(1024, ErrorMessageResourceName = "StringLengthAttribute_InvalidMax", ErrorMessageResourceType = typeof(ValidationMessages))]
        [Display(Name = "Description", ResourceType = typeof(Labels))]
        public virtual string Description { get; set; }

        [Display(Name = "IsActive", ResourceType = typeof(Labels))]
        public virtual bool IsActive { get; set; }

        [Display(Name = "BooleanValue", ResourceType = typeof(Labels))]
        public virtual bool BooleanValue { get; set; }

        [Display(Name = "DecimalValue", ResourceType = typeof(Labels))]
        public virtual decimal DecimalValue { get; set; }

        [Display(Name = "IntegerValue", ResourceType = typeof(Labels))]
        public virtual int IntegerValue { get; set; }

        [Display(Name = "StringValue", ResourceType = typeof(Labels))]
        public virtual string StringValue { get; set; }

        [Display(Name = "PluginId", ResourceType = typeof(Labels))]
        public virtual int PluginId { get; set; }

        #endregion

    }
}
