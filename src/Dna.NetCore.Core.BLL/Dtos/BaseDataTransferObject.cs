using System;

namespace Dna.NetCore.Core.BLL.DataTransferObjects
{
    public abstract partial class BaseDataTransferObject
    {
        public virtual bool IsDeleted { get; set; }
        public virtual string AddedBy { get; set; }
        public virtual DateTime AddedDate { get; set; }
        public virtual string ChangedBy { get; set; }
        public virtual DateTime? ChangedDate { get; set; }
        public virtual byte[] RowVersion { get; set; }
    }
}
