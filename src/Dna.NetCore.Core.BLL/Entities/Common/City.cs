using Dna.NetCore.Core.BLL.EntityMetadata.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dna.NetCore.Core.BLL.Entities.Common
{
    [Table("Core_City", Schema = "dbo")]
#if NET462
    [MetadataType(typeof(City_Dao_Metadata))]
#endif
    public partial class City : BaseEntity
	{
        #region Public Properties

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }

		public virtual string DisplayName { get; set; }
        public virtual bool IsActive { get; set; }

        public virtual int StateOrProvinceId { get; set; }

        #endregion

		#region Navigation Fields

        //public virtual StateOrProvince StateOrProvince { get; set; }

        private ICollection<CountyCity> _countiesCities;
        public virtual ICollection<CountyCity> CountiesCities
        {
            get { return _countiesCities ?? (_countiesCities = new List<CountyCity>()); }
            set { _countiesCities = value; }
        }

        #endregion
    }
}
