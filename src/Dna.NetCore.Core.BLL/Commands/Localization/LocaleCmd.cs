using Dna.NetCore.Core.BLL.EntityMetadata.Localization;
using Dna.NetCore.Core.Commands;
using System.ComponentModel.DataAnnotations;

namespace Dna.NetCore.Core.BLL.Commands.Localization
{
#if NET462
    [MetadataType(typeof(Locale_Metadata))]
#endif
    public partial class LocaleCmd : BaseCommand, ICommand
    {
        //
        // http://www.science.co.il/Language/Locale-codes.asp
        //
        public virtual int Id { get; set; }

        public virtual string DisplayName { get; set; }
        public virtual string LanguageCode { get; set; }
        public virtual string LCIDString { get; set; }
        public virtual int LCIDDecimal { get; set; }
        public virtual int LCIDHexadecimal { get; set; }
        public virtual int CodePage { get; set; }
        public virtual bool IsActive { get; set; }
    }
}
