namespace Dna.NetCore.Core.BLL.DataTransferObjects.Common
{
    //#if NET462
    //    [MetadataType(typeof(PersonTypeProfile_Metadata))]
    //#endif
    public partial class PersonTypeDto : BaseDataTransferObject
	{
		#region Public Properties

        public virtual int Id { get; set; }

        public virtual string SystemName { get; set; }
        public virtual string DisplayName { get; set; }
        public virtual bool IsActive { get; set; }

        #endregion
    }
}
