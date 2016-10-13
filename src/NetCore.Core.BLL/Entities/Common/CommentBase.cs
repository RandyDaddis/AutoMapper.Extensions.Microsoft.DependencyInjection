using Dna.NetCore.Core.BLL.EntityMetadata.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dna.NetCore.Core.BLL.Entities.Common
{
    //[Table("Core_Comment", Schema = "dbo")]
#if NET462
    [MetadataType(typeof(CommentBase_Dao_Metadata))]
#endif
    public abstract partial class CommentBase : BaseEntity
	{
        #region Public Properties

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }

        public virtual string UserName { get; set; }

        public virtual string Subject { get; set; }
        public virtual string Notes { get; set; }
		public virtual bool IsActive { get; set; }
        public virtual bool IsApproved { get; set; }

        #endregion

        //#region Helper Methods

        //public virtual Comment Set(string userName, string subject, string notes,
        //                           bool isActive = true, bool isApproved = false)
        //{
        //    this.UserName = userName;
        //    this.Subject = subject;
        //    this.Notes = notes;
        //    this.IsActive = isActive;
        //    this.IsApproved = isApproved;

        //    return this;
        //}

        //#endregion
    }
}
