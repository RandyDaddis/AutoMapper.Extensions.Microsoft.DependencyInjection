using Dna.NetCore.Core.BLL.Resources;
using System;
using System.ComponentModel.DataAnnotations;

namespace Dna.NetCore.Core.BLL.EntityMetadata
{
    public class BaseMetadata
    {
        [Display(Name = "IsDeleted", ResourceType = typeof(Labels))]
        public virtual bool IsDeleted { get; set; }

        [Required(ErrorMessageResourceName = "AddedByIsRequired", ErrorMessageResourceType = typeof(ValidationMessages))]
        [DisplayFormat(NullDisplayText = "-")]
        [Display(Name = "AddedBy", ResourceType = typeof(Labels))]
        public virtual string AddedBy { get; set; }

        [Required(ErrorMessageResourceName = "AddedDateIsRequired", ErrorMessageResourceType = typeof(ValidationMessages))]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:g}", NullDisplayText = "-")]
        [Display(Name = "AddedDate", ResourceType = typeof(Labels))]
        public virtual DateTime AddedDate { get; set; }

        [DisplayFormat(NullDisplayText = "-")]
        [Display(Name = "ChangedBy", ResourceType = typeof(Labels))]
        public virtual string ChangedBy { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:g}", NullDisplayText = "-")]
        [Display(Name = "ChangedDate", ResourceType = typeof(Labels))]
        public virtual DateTime? ChangedDate { get; set; }

        [Timestamp]
        public virtual byte[] Timestamp { get; set; }
    }
}
