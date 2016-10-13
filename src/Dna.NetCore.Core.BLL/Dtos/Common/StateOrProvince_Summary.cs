using Dna.NetCore.Core.BLL.EntityMetadata.Common;
using System.ComponentModel.DataAnnotations;

namespace Dna.NetCore.Core.BLL.DataTransferObjects.Common
{
#if NET462
    [MetadataType(typeof(StateOrProvince_Summary_Metadata))]
#endif
    public partial class StateOrProvince_Summary : BaseDataTransferObject
    {
        public virtual int Id { get; set; }

        public virtual string Abbreviation { get; set; }
        //public virtual string CountryAbbreviation { get; set; }
        public virtual bool IsShippingAllowed { get; set; }
        public virtual bool IsActive { get; set; }
    }
}
