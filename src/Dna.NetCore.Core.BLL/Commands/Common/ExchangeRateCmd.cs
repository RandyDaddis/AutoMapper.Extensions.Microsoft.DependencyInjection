using Dna.NetCore.Core.BLL.EntityMetadata.Common;
using Dna.NetCore.Core.Commands;
using System.ComponentModel.DataAnnotations;

namespace Dna.NetCore.Core.BLL.Commands.Common
{
#if NET462
    [MetadataType(typeof(ExchangeRate_Metadata))]
#endif
    public partial class ExchangeRateCmd : BaseCommand, ICommand
	{
        #region Properties

        public virtual int Id { get; set; }

        public virtual string DisplayName { get; set; }
        public virtual decimal Rate { get; set; }
        public virtual bool IsActive { get; set; }

        public virtual int CurrencyId { get; set; }

        #endregion

        #region Navigation Fields

        public virtual CurrencyCmd Currency { get; set; }

        #endregion
    }
}
