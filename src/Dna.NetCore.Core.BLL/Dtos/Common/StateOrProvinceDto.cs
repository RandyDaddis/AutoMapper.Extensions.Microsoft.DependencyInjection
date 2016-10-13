using Dna.NetCore.Core.BLL.EntityMetadata.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dna.NetCore.Core.BLL.DataTransferObjects.Common
{
#if NET462
    [MetadataType(typeof(StateOrProvince_Metadata))]
#endif
    public partial class StateOrProvinceDto : BaseDataTransferObject
	{
        #region Public Properties

        public virtual int Id { get; set; }

        public virtual string Abbreviation { get; set; }
        public virtual string DisplayName { get; set; }
        public virtual decimal SalesTaxRate { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual bool IsShippingAllowed { get; set; }

        public virtual int CountryId { get; set; }
        public virtual string CountryAbbreviation { get; set; }

        #endregion

        #region Navigation Fields

        public virtual CountryDto Country { get; set; }

        private ICollection<CityDto> _cities;
        public virtual ICollection<CityDto> Cities
        {
            get { return _cities ?? (_cities = new List<CityDto>()); }
            set { _cities = value; }
        }

        private ICollection<CountyDto> _counties;
        public virtual ICollection<CountyDto> Counties
        {
            get { return _counties ?? (_counties = new List<CountyDto>()); }
            set { _counties = value; }
        }

        private ICollection<TimeZoneDto> _timeZones;
        public virtual ICollection<TimeZoneDto> TimeZones
        {
            get { return _timeZones ?? (_timeZones = new List<TimeZoneDto>()); }
            set { _timeZones = value; }
        }

        #endregion
    }
}
