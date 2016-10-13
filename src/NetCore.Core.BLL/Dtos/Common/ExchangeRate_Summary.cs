using Dna.NetCore.Core.BLL.EntityMetadata.Common;
using System.ComponentModel.DataAnnotations;

namespace Dna.NetCore.Core.BLL.DataTransferObjects.Common
{
#if NET462
    [MetadataType(typeof(ExchangeRate_Summary_Metadata))]
#endif
    public partial class ExchangeRate_Summary : BaseDataTransferObjectSummary
    {
        public virtual int Id { get; set; }

        public virtual string CurrencyCode { get; set; }
        public virtual decimal Rate { get; set; }
        public virtual bool IsActive { get; set; }
    }
}
