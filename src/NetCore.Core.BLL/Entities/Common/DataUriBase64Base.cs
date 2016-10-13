using Dna.NetCore.Core.BLL.EntityMetadata.Common;
using System.ComponentModel.DataAnnotations;

namespace Dna.NetCore.Core.BLL.Entities.Common
{
    //[Table("Core_Image", Schema = "dbo")]
#if NET462
    [MetadataType(typeof(DataUriBase64Base_Dao_Metadata))]
#endif
    public abstract partial class DataUriBase64Base : BaseEntity
    {
        #region Public Properties

        // WARNING: base class cannot contain id due to EF contraint:
        //         - EF one-to-one relationships require the primary key of the dependent also be the foreign key
        //         - [Key)
        //         - [ForeignKey("xxxPicture")
        //[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public virtual int Id { get; set; }

        public virtual byte[] Data { get; set; }
        //public virtual string ContentType { get; set; }  // defaults to text/plain

        // ExAMPLE: "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAQAAAADCAIAAAA7ljmRAAAAGElEQVQIW2P4DwcMDAxAfBvMAhEQMYgcACEHG8ELxtbPAAAAAElFTkSuQmCC"
        //           "data:" = scheme
        //           "image/png" = content type
        //           ";base64" = type of encoding
        //           "," = delimiter between data:[<mediatype>][;base64] and <data>
        //
        //public virtual string Delimiter
        //{
        //    get
        //    {
        //        return ",";
        //    }
        //}
        //public virtual string Encoding
        //{
        //    get {
        //        return ";base64,";
        //    }
        //}
        //public virtual string Scheme
        //{
        //    get
        //    {
        //        return "data:";
        //    }
        //}

        #endregion

        //#region Navigation Members

        //public virtual MimeType MimeType { get; set; }

        //#endregion
    }
}
