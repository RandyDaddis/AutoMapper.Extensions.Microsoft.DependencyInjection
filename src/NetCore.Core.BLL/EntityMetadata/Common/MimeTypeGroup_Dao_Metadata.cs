﻿using Dna.NetCore.Core.BLL.Resources;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dna.NetCore.Core.BLL.EntityMetadata.Common
{
    public partial class MimeTypeGroup_Dao_Metadata : BaseMetadata
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Id", ResourceType = typeof(Labels))]
        public virtual int Id { get; set; }

        [Required(ErrorMessageResourceName = "SystemNameIsRequired", ErrorMessageResourceType = typeof(ValidationMessages))]
        [DisplayFormat(NullDisplayText = "[Name]")]
        [StringLength(256, ErrorMessageResourceName = "StringLengthAttribute_InvalidMax", ErrorMessageResourceType = typeof(ValidationMessages))]
        [Display(Name = "SystemName", ResourceType = typeof(Labels))]
        public virtual string SystemName { get; set; }

        [Required(ErrorMessageResourceName = "DisplayNameIsRequired", ErrorMessageResourceType = typeof(ValidationMessages))]
        [DisplayFormat(NullDisplayText = "[Name]")]
        [StringLength(256, ErrorMessageResourceName = "StringLengthAttribute_InvalidMax", ErrorMessageResourceType = typeof(ValidationMessages))]
        [Display(Name = "DisplayName", ResourceType = typeof(Labels))]
        public virtual string DisplayName { get; set; }

        [Display(Name = "IsActive", ResourceType = typeof(Labels))]
        public virtual bool IsActive { get; set; }
    }
}
