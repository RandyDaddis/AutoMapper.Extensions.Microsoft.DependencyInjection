using Dna.NetCore.Core.BLL.EntityMetadata.Common;
using Dna.NetCore.Core.Commands;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dna.NetCore.Core.BLL.Commands.Common
{
#if NET462
    [MetadataType(typeof(Country_Metadata))]
#endif
    public partial class CountryCmd : BaseCommand, ICommand
	{
        #region Public Properties

        public virtual int Id { get; set; }

        public virtual string Abbreviation { get; set; }
        public virtual string DisplayName { get; set; }
        public virtual string PhoneNumberCountryCode { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual bool IsShippingAllowed { get; set; }
        public virtual bool IsVatEnabled { get; set; }

        public virtual int? CurrencyId { get; set; }
        //public virtual string CurrencyCode { get; set; }

        public virtual int? LocaleId { get; set; }
        //public virtual string LocaleName { get; set; }

        #endregion

        #region Navigation Fields

        //public virtual CurrencyCmd Currency { get; set; }
        //public virtual LocaleCmd Locale { get; set; }

        private ICollection<StateOrProvinceCmd> _stateProvinces;
		public virtual ICollection<StateOrProvinceCmd> StateOrProvinces
		{
			get { return _stateProvinces ?? (_stateProvinces = new List<StateOrProvinceCmd>()); }
			set { _stateProvinces = value; }
		}

		#endregion
	}
}
