using Dna.NetCore.Core.BLL.EntityMetadata.Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dna.NetCore.Core.BLL.Entities.Common
{
    // [Table("Core_Address", Schema = "dbo")]
#if NET462
    [MetadataType(typeof(AddressBase_Dao_Metadata))]
#endif
    public abstract partial class AddressBase : BaseEntity
	{
		#region Public Properties

        //[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public virtual int Id { get; set; }

        public virtual string AddressLine1 { get; set; }
		public virtual string AddressLine2 { get; set; }
		public virtual string AddressLine3 { get; set; }
		public virtual string PostalCode { get; set; }

        public virtual bool IsActive { get; set; }

        public virtual int AddressTypeId { get; set; }
        public virtual int CityId { get; set; }
        public virtual int? CountyId { get; set; }
        public virtual int StateOrProvinceId { get; set; }
        //public virtual int CountryId { get; set; }

        #endregion

        #region Navigation Fields

        public virtual AddressType AddressType { get; set; }
        public virtual City City { get; set; }
        public virtual County County { get; set; }
        public virtual StateOrProvince StateOrProvince { get; set; }

        //public virtual Country Country { get; set; }

        #endregion
    }
}
