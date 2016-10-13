using Dna.NetCore.Core.BLL.EntityMetadata.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dna.NetCore.Core.BLL.Entities.Common
{
    // Currency Codes - ISO 4217  http://www.iso.org/iso/home/standards/currency_codes.htm
    //
    // Currency Codes - ISO 4217  http://en.wikipedia.org/wiki/ISO_4217
    //
    // Currency Signs http://en.wikipedia.org/wiki/Currency_sign  // ISO 4217 codes are used instead of currency signs for most use cases
    //
    // http://en.wikipedia.org/wiki/Currency_(typography)  // currency sign is a char used when the currency symbol is unavailable
    //
    // DEVNOTE: rename Currency to Currency = ambiguos reference to System.Currency
    //
    [Table("Core_Currency", Schema = "dbo")]
#if NET462
    [MetadataType(typeof(Currency_Dao_Metadata))]
#endif
    public partial class Currency : BaseEntity
	{
		#region Public Properties

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }

        public virtual string DisplayName { get; set; }
        public virtual string Code { get; set; }
		public virtual string Locality { get; set; }  // TODO: should this be LocaleId???
		public virtual string Format { get; set; }
		public virtual decimal Rate { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual bool IsPublished { get; set; }

		#endregion

        //#region Methods

        //public void GetExchangeRateFor(string currencyCode)
        //{
        //}

        //#endregion
	}
}
