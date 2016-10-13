using Dna.NetCore.Core.BLL.EntityMetadata.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dna.NetCore.Core.BLL.Entities.Common
{
    [Table("Core_PersonType", Schema = "dbo")]
#if NET462
    [MetadataType(typeof(PersonType_Dao_Metadata))]
#endif
    public partial class PersonType : BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }

        //[Required(ErrorMessageResourceName = "SystemNameIsRequired", ErrorMessageResourceType = typeof(ValidationMessages))]
        ////[RegularExpression(@"^[A-Z''-'\s]{1,2}$")]
        //[StringLength(256, ErrorMessageResourceName = "StringLengthAttribute_InvalidMax", ErrorMessageResourceType = typeof(ValidationMessages))]
        //[DisplayFormat(NullDisplayText = "[system name]")]
        //[Display(Name = "SystemName", ResourceType = typeof(Labels))]
        public virtual string SystemName { get; set; }

        //[Required(ErrorMessageResourceName = "DisplayNameIsRequired", ErrorMessageResourceType = typeof(ValidationMessages))]
        //[StringLength(256, ErrorMessageResourceName = "StringLengthAttribute_InvalidMax", ErrorMessageResourceType = typeof(ValidationMessages))]
        //[DisplayFormat(NullDisplayText = "[display name]")]
        //[Display(Name = "DisplayName", ResourceType = typeof(Labels))]
        public virtual string DisplayName { get; set; }
        public virtual bool IsActive { get; set; }
    }
}
