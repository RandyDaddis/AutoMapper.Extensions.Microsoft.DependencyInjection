using Dna.NetCore.Core.BLL.EntityMetadata.Common;
using System.ComponentModel.DataAnnotations;
//using Dna.i18n.Model.Shipping; // DEVNOTE: use for restricting shipping to certain countries

namespace Dna.NetCore.Core.BLL.DataTransferObjects.Common
{
#if NET462
    [MetadataType(typeof(CountyCity_Metadata))]
#endif
    public partial class CountyCityDto : BaseDataTransferObject
	{
        #region Public Properties

        public virtual int CountyId { get; set; }
        public virtual int CityId { get; set; }

        #endregion

        #region Navigation Fields

        public virtual CountyDto County { get; set; }
        public virtual CityDto City { get; set; }

        #endregion
    }
}
