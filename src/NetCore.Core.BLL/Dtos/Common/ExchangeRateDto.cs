using Dna.NetCore.Core.BLL.EntityMetadata.Common;
using System.ComponentModel.DataAnnotations;

namespace Dna.NetCore.Core.BLL.DataTransferObjects.Common
{
    // TODO: http://en.wikipedia.org/wiki/Exchange_rate
    //
#if NET462
    [MetadataType(typeof(ExchangeRate_Metadata))]
#endif
    public partial class ExchangeRateDto : BaseDataTransferObject
	{
        #region Public Properties

        public virtual int Id { get; set; }

        public virtual string DisplayName { get; set; }
        public virtual decimal Rate { get; set; }
        public virtual bool IsActive { get; set; }

        public virtual int CurrencyId { get; set; }

        //public override string ToString()
        //{
        //    return string.Format("{0} {1}", this.CurrencyCode, this.Rate.ToString());
        //}

        #endregion

		#region Navigation Fields

        public virtual CurrencyDto Currency { get; set; }

		#endregion
	}
}
