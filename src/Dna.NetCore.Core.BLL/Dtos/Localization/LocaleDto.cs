using Dna.NetCore.Core.BLL.EntityMetadata.Localization;
using System.ComponentModel.DataAnnotations;

namespace Dna.NetCore.Core.BLL.DataTransferObjects.Localization
{
#if NET462
    [MetadataType(typeof(Locale_Metadata))]
#endif
    public partial class LocaleDto : BaseDataTransferObject
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
