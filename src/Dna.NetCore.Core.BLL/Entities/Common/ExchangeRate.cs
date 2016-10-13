using Dna.NetCore.Core.BLL.EntityMetadata.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dna.NetCore.Core.BLL.Entities.Common
{
    //
    // TODO: http://en.wikipedia.org/wiki/Exchange_rate
    //
    [Table("Core_ExchangeRate", Schema = "dbo")]
#if NET462
    [MetadataType(typeof(ExchangeRate_Dao_Metadata))]
#endif
    public partial class ExchangeRate : BaseEntity
	{
        #region Public Properties

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }

        public virtual string DisplayName { get; set; }
        public virtual decimal Rate { get; set; }
        public virtual bool IsActive { get; set; }

        public virtual int CurrencyId { get; set; }

        #endregion

        #region Navigation Fields

        public virtual Currency Currency { get; set; }

        #endregion
    }
}
