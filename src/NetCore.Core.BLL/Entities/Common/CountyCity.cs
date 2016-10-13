using Dna.NetCore.Core.BLL.EntityMetadata.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dna.NetCore.Core.BLL.Entities.Common
{
    [Table("Core_CountyCity", Schema = "dbo")]
#if NET462
    [MetadataType(typeof(CountyCity_Dao_Metadata))]
#endif
    public partial class CountyCity : BaseEntity
    {
        #region Public Properties

        public virtual int CountyId { get; set; }
        public virtual int CityId { get; set; }

        #endregion

        #region Navigation Fields

        public virtual County County { get; set; }
        public virtual City City { get; set; }

        #endregion
    }
}
