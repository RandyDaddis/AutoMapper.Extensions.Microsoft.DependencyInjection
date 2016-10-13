using Dna.NetCore.Core.BLL.EntityMetadata.Common;
using Dna.NetCore.Core.Commands;
using System.ComponentModel.DataAnnotations;

namespace Dna.NetCore.Core.BLL.Commands.Common
{
#if NET462
    [MetadataType(typeof(Currency_Metadata))]
#endif
    public partial class CurrencyCmd : BaseCommand, ICommand
	{
        #region Public Properties

        public virtual int Id { get; set; }

        public virtual string DisplayName { get; set; }
        public virtual string Code { get; set; }
        public virtual string Locality { get; set; }
        public virtual string Format { get; set; }
        public virtual decimal Rate { get; set; }
        public virtual bool IsPublished { get; set; }
        public virtual bool IsActive { get; set; }

        #endregion
    }
}
