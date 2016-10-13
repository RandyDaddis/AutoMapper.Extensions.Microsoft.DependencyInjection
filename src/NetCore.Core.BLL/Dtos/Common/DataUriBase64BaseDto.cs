using Dna.NetCore.Core.BLL.EntityMetadata.Common;
using System.ComponentModel.DataAnnotations;

namespace Dna.NetCore.Core.BLL.DataTransferObjects.Common
{
#if NET462
    [MetadataType(typeof(DataUriBase64Base_Metadata))]
#endif
    public abstract partial class DataUriBase64BaseDto : BaseDataTransferObject
    {
        #region Public Properties

        public virtual byte[] Data { get; set; }
        //public virtual string ContentType { get; set; }

        #endregion
    }
}
