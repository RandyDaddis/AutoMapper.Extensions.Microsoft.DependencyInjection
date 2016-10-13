using Dna.NetCore.Core.BLL.Resources;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dna.NetCore.Core.BLL.EntityMetadata.Common
{
    public partial class CountyCity_Dao_Metadata : BaseMetadata
    {
       // [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "CountyId", ResourceType = typeof(Labels))]
        public virtual int CountyId { get; set; }

       // [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "CityId", ResourceType = typeof(Labels))]
        public virtual int CityId { get; set; }
    }
}
