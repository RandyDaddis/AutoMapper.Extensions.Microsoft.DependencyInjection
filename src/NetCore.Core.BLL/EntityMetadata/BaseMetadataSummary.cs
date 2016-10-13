using System.ComponentModel.DataAnnotations;

namespace NetCore.Core.BLL.EntityMetadata
{
    public partial class BaseMetadataSummary
    {
        [Display(Name = "Id", ResourceType = typeof(Resources.Labels))]
        public int Id { get; set; }
    }
}
