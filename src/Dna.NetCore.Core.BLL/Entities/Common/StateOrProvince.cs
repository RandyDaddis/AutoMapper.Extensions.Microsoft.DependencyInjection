using Dna.NetCore.Core.BLL.EntityMetadata.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dna.NetCore.Core.BLL.Entities.Common
{
    [Table("Core_StateOrProvince", Schema = "dbo")]
#if NET462
    [MetadataType(typeof(StateOrProvince_Dao_Metadata))]
#endif
    public partial class StateOrProvince : BaseEntity
	{
        #region Public Properties

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }

        public virtual string Abbreviation { get; set; }
		public virtual string DisplayName { get; set; }
        public virtual decimal SalesTaxRate { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual bool IsShippingAllowed { get; set; }

        public virtual int CountryId { get; set; }

        #endregion

        #region Navigation Fields

        public virtual Country Country { get; set; }

        private ICollection<City> _cities;
        public virtual ICollection<City> Cities
        {
            get { return _cities ?? (_cities = new List<City>()); }
            set { _cities = value; }
        }

        private ICollection<County> _counties;
        public virtual ICollection<County> Counties
        {
            get { return _counties ?? (_counties = new List<County>()); }
            set { _counties = value; }
        }

        private ICollection<Dna.NetCore.Core.BLL.Entities.Common.TimeZone> _timeZones;
        public virtual ICollection<Dna.NetCore.Core.BLL.Entities.Common.TimeZone> TimeZones
        {
            get { return _timeZones ?? (_timeZones = new List<Dna.NetCore.Core.BLL.Entities.Common.TimeZone>()); }
            set { _timeZones = value; }
        }

        #endregion
    }
}
