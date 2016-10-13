using Dna.NetCore.Core.BLL.EntityMetadata.Common;
using Dna.NetCore.Core.Commands;
using System.ComponentModel.DataAnnotations;

namespace Dna.NetCore.Core.BLL.Commands.Common
{
#if NET462
    [MetadataType(typeof(CountyCity_Metadata))]
#endif
    public partial class CountyCityCmd : BaseCommand, ICommand
	{
        #region Public Properties

        public virtual int CountyId { get; set; }
        public virtual int CityId { get; set; }

        #endregion

        #region Navigation Fields

        public virtual CountyCmd County { get; set; }
        public virtual CityCmd City { get; set; }

        #endregion
    }
}
