using Dna.NetCore.Core.BLL.EntityMetadata.Common;
using Dna.NetCore.Core.Commands;
using System.ComponentModel.DataAnnotations;

namespace Dna.NetCore.Core.BLL.Commands.Common
{
#if NET462
    [MetadataType(typeof(PhoneNumberType_Metadata))]
#endif
    public partial class PhoneNumberTypeCmd : BaseCommand, ICommand
    {
        public virtual int Id { get; set; }

        public virtual string SystemName { get; set; }
        public virtual string DisplayName { get; set; }
        public virtual bool IsActive { get; set; }
    }
}
