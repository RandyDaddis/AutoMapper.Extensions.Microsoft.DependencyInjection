using Dna.NetCore.Core.BLL.EntityMetadata.Localization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dna.NetCore.Core.BLL.Entities.Localization
{
    [Table("Core_Locale", Schema = "dbo")]
#if NET462
    [MetadataType(typeof(Locale_Dao_Metadata))]
#endif
    public partial class Locale : BaseEntity
    {
        // cref Ch.17 Professinal C# 2005
        //
        // http://www.science.co.il/Language/Locale-codes.asp
        //
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
