using Dna.NetCore.Core.BLL.EntityMetadata.Localization;
using System.ComponentModel.DataAnnotations;

namespace Dna.NetCore.Core.BLL.DataTransferObjects.Localization
{
#if NET462
    [MetadataType(typeof(Language_Metadata))]
#endif
    public partial class LanguageDto : BaseDataTransferObject
    {
        public virtual int Id { get; set; }

        public virtual string Abbreviation { get; set; }
        public virtual string Name { get; set; }
        public virtual string Subtag { get; set; }
        //public virtual string Tag { get; set; }
        public virtual string Notes { get; set; }
        public virtual string Added { get; set; }
        public virtual string Depreciated { get; set; }
        public virtual string PreferredValue { get; set; }
        public virtual string Prefix { get; set; }
        public virtual string SuppressScript { get; set; }
        public virtual string Macrolanguage { get; set; }
        public virtual string Scope { get; set; }
        public virtual string Comments { get; set; }
        public virtual bool IsActive { get; set; }
    }
}
