using Dna.NetCore.Core.BLL.EntityMetadata.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using Dna.i18n.BLL.Shipping; // DEVNOTE: use for restricting shipping to certain countries

namespace Dna.NetCore.Core.BLL.Entities.Common
{
    [Table("Core_Country", Schema = "dbo")]
#if NET462
    [MetadataType(typeof(Country_Dao_Metadata))]
#endif
    public partial class Country : BaseEntity
    {
        #region Public Properties

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }

        public virtual string Abbreviation { get; set; }
        public virtual string DisplayName { get; set; }
        public virtual string PhoneNumberCountryCode { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual bool IsShippingAllowed { get; set; }
        public virtual bool IsVatEnabled { get; set; }

        public virtual int? CurrencyId { get; set; }
        public virtual int? LocaleId { get; set; }

        #endregion

        #region Navigation Fields

        private ICollection<StateOrProvince> _stateProvinces;
		public virtual ICollection<StateOrProvince> StateOrProvinces
		{
			get { return _stateProvinces ?? (_stateProvinces = new List<StateOrProvince>()); }
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
