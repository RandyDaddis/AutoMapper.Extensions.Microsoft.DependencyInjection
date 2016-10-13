using System;
using System.ComponentModel.DataAnnotations;

namespace NetCore.Core.BLL.Commands
{
	public abstract partial class BaseCommand
	{
        public virtual bool IsDeleted { get; set; }
        public virtual string AddedBy { get; set; }
        public virtual DateTime AddedDate { get; set; }
        public virtual string ChangedBy { get; set; }
        public virtual DateTime? ChangedDate { get; set; }
        public virtual byte[] RowVersion { get; set; }
	}
}
