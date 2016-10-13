using NetCore.Core.BLL.EntityMetadata.Common;
using NetCore.Core.Commands;
using System.ComponentModel.DataAnnotations;

namespace NetCore.Core.BLL.Commands.Common
{
#if NET462
    [MetadataType(typeof(AddressType_Metadata))]
#endif
    public partial class AddressTypeCmd : BaseCommand, ICommand
    {
        public virtual int Id { get; set; }
        public virtual string SystemName { get; set; }
        public virtual string DisplayName { get; set; }
        public virtual bool IsActive { get; set; }
    }
}
