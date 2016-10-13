using Dna.NetCore.Core.BLL.EntityMetadata.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
//using Dna.i18n.Model.Shipping; // DEVNOTE: use for restricting shipping to certain countries

namespace Dna.NetCore.Core.BLL.DataTransferObjects.Common
{
#if NET462
    [MetadataType(typeof(Country_Metadata))]
#endif
    public partial class CountryDto : BaseDataTransferObject
	{
        #region ctor

        public CountryDto()
        {
        }

        #endregion

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

        //public virtual CurrencyDto Currency { get; set; }
        //public virtual LocaleDto Locale { get; set; }

        private ICollection<StateOrProvinceDto> _stateProvinces;
		public virtual ICollection<StateOrProvinceDto> StateOrProvinces
		{
			get { return _stateProvinces ?? (_stateProvinces = new List<StateOrProvinceDto>()); }
			set { _stateProvinces = value; }
		}

		//private ICollection<Product_PropertyGroup_ShippingMethod> _restrictedShippingMethods;
		//public virtual ICollection<Product_PropertyGroup_ShippingMethod> RestrictedShippingMethods
		//{
		//    get { return _restrictedShippingMethods ?? (_restrictedShippingMethods = new List<Product_PropertyGroup_ShippingMethod>()); }
		//    set { _restrictedShippingMethods = value; }
		//}

		#endregion
	}
}
