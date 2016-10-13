using Dna.NetCore.Core.BLL.EntityMetadata.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dna.NetCore.Core.BLL.Entities.Common
{
    //[Table("Core_PhoneNumber", Schema = "dbo")]
#if NET462
    [MetadataType(typeof(PhoneNumberBase_Dao_Metadata))]
#endif
    public abstract partial class PhoneNumberBase : BaseEntity
    {
        #region Public Properties

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }

        //public virtual string AreaCode { get; set; }
        public virtual string Number { get; set; }
        public virtual string Extension { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual bool IsPrimary { get; set; }

        public virtual int CountryId { get; set; }
        public virtual int PhoneNumberTypeId { get; set; }

        #endregion

        #region Navigation Fields

        public virtual Country Country { get; set; }
        public virtual PhoneNumberType PhoneNumberType { get; set; }

        #endregion
    }
}
