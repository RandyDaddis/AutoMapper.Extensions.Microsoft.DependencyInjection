using System;
using System.ComponentModel.DataAnnotations;

namespace Dna.NetCore.Core.BLL.Entities
{
    public abstract partial class BaseEntity
    {
        public virtual bool IsDeleted { get; set; }
        public virtual string AddedBy { get; set; }
        [DataType(DataType.DateTime)]
        public virtual DateTime AddedDate { get; set; }
        public virtual string ChangedBy { get; set; }
        [DataType(DataType.DateTime)]
        public virtual DateTime? ChangedDate { get; set; }
        [Timestamp]
        public virtual byte[] RowVersion { get; set; }
    }
}
