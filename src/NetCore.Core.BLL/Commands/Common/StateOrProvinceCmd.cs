using Dna.NetCore.Core.BLL.EntityMetadata.Common;
using Dna.NetCore.Core.Commands;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dna.NetCore.Core.BLL.Commands.Common
{
#if NET462
    [MetadataType(typeof(StateOrProvince_Metadata))]
#endif
    public partial class StateOrProvinceCmd : BaseCommand, ICommand
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

        public virtual CountryCmd Country { get; set; }

        private ICollection<CityCmd> _cities;
        public virtual ICollection<CityCmd> Cities
        {
            get { return _cities ?? (_cities = new List<CityCmd>()); }
            set { _cities = value; }
        }

        private ICollection<CountyCmd> _counties;
        public virtual ICollection<CountyCmd> Counties
        {
            get { return _counties ?? (_counties = new List<CountyCmd>()); }
            set { _counties = value; }
        }

        private ICollection<TimeZoneCmd> _timeZones;
        public virtual ICollection<TimeZoneCmd> TimeZones
        {
            get { return _timeZones ?? (_timeZones = new List<TimeZoneCmd>()); }
            set { _timeZones = value; }
        }

        #endregion
    }
}
